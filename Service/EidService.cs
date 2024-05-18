using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bridge;
using Eid.Model;
using Eid.Utils;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;

namespace Eid.Service
{
    internal class EidService
    {
        public enum Model
        {
            BelgianEidModel
        }

        public BelgianEidModel belgianEid = new BelgianEidModel();

        private String smartCardName;

        private String eidModel;
        private Type eidModelType;
        private Type eidAttributesType;

        public EidService()
        {
            InitEidData(null, null);
        }
        public EidService(String smartCardName)
        {
            InitEidData(smartCardName, null);
        }

        public EidService(String smartCardName, List<String> labels)
        {
            InitEidData(smartCardName, labels);
        }


        private void InitEidData(String smartCardName, List<String> labels)
        {
            this.eidModel = (Model.BelgianEidModel).ToString();
            this.smartCardName = smartCardName;

            string typeName = "Eid.Model." + this.eidModel;
            this.eidModelType = Type.GetType(typeName);
            this.eidAttributesType = eidModelType.GetNestedType("EidAttributes");

            // fetch all labels if labels is empty
            if (labels == null)
            {
                labels = new List<string>();
                if (eidAttributesType != null && eidAttributesType.IsEnum)
                {
                    Array enumValues = Enum.GetValues(eidAttributesType);

                    foreach (var value in enumValues)
                    {
                        labels.Add(value.ToString());
                    }
                }
                else
                {
                    // Handle the case where 'EidAttributes' is not found or is not an enum
                    Console.WriteLine("EidAttributes enum type not found in the specified model.");
                }
            }

            // populate eid data
            GetDatas(labels);

        }




        private void GetDatas(List<String> names)
        {
            Pkcs11InteropFactories factories = new Pkcs11InteropFactories();

            using IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, BelgiumLibrary.ModuleFileName, AppType.SingleThreaded);
            // Show general information about loaded library
            ILibraryInfo libraryInfo = pkcs11Library.GetInfo();


            ISlot selectedSlot = null;

            Boolean hasCard = false;
            Boolean hasSmartCard = false;

            // Get list of all available slots and take the first with card insert, if smartCardName is defined it ignore other smartcard
            foreach (ISlot slot in pkcs11Library.GetSlotList(SlotsType.WithOrWithoutTokenPresent))
            {
                hasSmartCard = true;
                // Show basic information about slot
                ISlotInfo slotInfo = slot.GetSlotInfo();

                if (this.smartCardName != null && this.smartCardName != slot.GetSlotInfo().SlotDescription)
                {
                    continue;
                }

                if (slotInfo.SlotFlags.TokenPresent)
                {
                    hasCard = true;
                    ITokenInfo tokenInfo = slot.GetTokenInfo();
                    selectedSlot = slot;
                    break;
                }
            }

            
            if (!hasSmartCard)
            {
                EventManager.EventEid.RaiseErrorOccurred(ErrorCode.Code.NO_SMARTCARD);
                return;
            }

            if (!hasCard)
            {
                EventManager.EventEid.RaiseErrorOccurred(ErrorCode.Code.NO_CARD);
                return;
            }

            if (selectedSlot != null)
            {
                // Open RW session
                using ISession session = selectedSlot.OpenSession(SessionType.ReadWrite);

                // Prepare attribute template that defines search criteria
                List<IObjectAttribute> objectAttributes = new List<IObjectAttribute>
                {
                    session.Factories.ObjectAttributeFactory.Create(CKA.CKA_CLASS, CKO.CKO_DATA),
                    session.Factories.ObjectAttributeFactory.Create(CKA.CKA_TOKEN, true)
                };

                // Find all objects that match provided attributes
                List<IObjectHandle> foundObjects = session.FindAllObjects(objectAttributes);


                int sizeOfList = 0;
                foreach (IObjectHandle obj in foundObjects)
                {
                    sizeOfList++;
                    var key = obj;
                    byte[] plainKeyValue = null;

                    List<IObjectAttribute> readAttrs = session.GetAttributeValue(key, new List<CKA>() { CKA.CKA_VALUE, CKA.CKA_LABEL });


                    if (readAttrs[0].CannotBeRead)
                        throw new Exception("Key cannot be exported");
                    else
                        plainKeyValue = readAttrs[0].GetValueAsByteArray();

                    String label = readAttrs[1].GetValueAsString();


                    if (plainKeyValue != null && plainKeyValue.Length > 0)
                    {

                        try
                        {
                            BelgianEidModel.EidAttributes eidAttributes = (BelgianEidModel.EidAttributes)Enum.Parse(typeof(BelgianEidModel.EidAttributes), label);

                            // Assume belgianEid is an instance of BelgianEidModel and it's already initialized.
                            Type belgianEidType = belgianEid.GetType();
                            MethodInfo methodToInvoke = belgianEidType.GetMethod("Set" + label);

                            // Assuming 'plainKeyValue' is already defined elsewhere in your code
                            methodToInvoke.Invoke(belgianEid, new object[] { plainKeyValue });

                            //this.GetType().GetMethod("Set" + label).Invoke(this, new object[] { plainKeyValue });
                        }
                        catch (Exception e)
                        {
                            EventManager.EventEid.RaiseErrorOccurred(ErrorCode.Code.LABEL_NO_READABLE, e.Message.ToString());
                        }


                    }


                }
            }
            else
            {
                EventManager.EventEid.RaiseErrorOccurred(ErrorCode.Code.NO_CARD);
            }
        }








        public Dictionary<String, String> GetAllValues()
        {

            Dictionary<String, String> data = new Dictionary<String, String>();

            List<BelgianEidModel.EidAttributes> eidAttributes = Enum.GetValues(typeof(BelgianEidModel.EidAttributes))
                            .Cast<BelgianEidModel.EidAttributes>()
                            .ToList();
            foreach (BelgianEidModel.EidAttributes attrib in eidAttributes)
            {

                // todo

                try
                {
                    Type belgianEidType = belgianEid.GetType();
                    MethodInfo getMethod = belgianEidType.GetMethod("Get" + attrib.ToString());

                    data.Add(attrib.ToString(), (String)getMethod.Invoke(belgianEid, null));
                }
                catch (Exception e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            }

            return data;
        }


        public Dictionary<String, String> GetValues(List<String> labels)
        {

            String labelsJoin = String.Join(", ", labels.ToArray());
            try
            {
                BelgianEidModel.EidAttributes eidAttributes = (BelgianEidModel.EidAttributes)Enum.Parse(typeof(BelgianEidModel.EidAttributes), labelsJoin);
            }
            catch (Exception e)
            {
                throw e;
            }
            Dictionary<String, String> data = new Dictionary<String, String>();


            foreach (String label in labels)
            {

                data.Add(label, (String)this.GetType().GetMethod("Get" + label).Invoke(this, null));
            }

            return data;
        }
    }
}
