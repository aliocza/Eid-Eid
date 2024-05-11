using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bridge;
using Eid.Model;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;


namespace Eid
{
    class EidData
    {


        private String smartCardName;
        public BelgianEidModel belgianEid = new BelgianEidModel();

        public EidData()
        {
            InitData(smartCardName, null);
        }
        public EidData(String smartCardName)
        {
            InitData(smartCardName, null);
        }

        public EidData(String smartCardName, List<String> labels)
        {
            InitData(smartCardName, labels);
        }


        private void InitData(String smartCardName, List<String> labels) {

            this.smartCardName = smartCardName;

            if (labels == null) {
                labels = new List<string>();

                List<BelgianEidModel.EidAttributes> eidAttributes = Enum.GetValues(typeof(BelgianEidModel.EidAttributes))
                                .Cast<BelgianEidModel.EidAttributes>()
                                .ToList();
                foreach (BelgianEidModel.EidAttributes attrib in eidAttributes)
                {
                    labels.Add(attrib.ToString());
                }
            }

            GetDatas(labels);

        }

        


        private void GetDatas(List<String> names)
        {
            Pkcs11InteropFactories factories = new Pkcs11InteropFactories();

            using IPkcs11Library pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, BelgiumLibrary.ModuleFileName, AppType.SingleThreaded);
            // Show general information about loaded library
            ILibraryInfo libraryInfo = pkcs11Library.GetInfo();


            ISlot selectedSlot = null;

            // Get list of all available slots
            foreach (ISlot slot in pkcs11Library.GetSlotList(SlotsType.WithOrWithoutTokenPresent))
            {
                // Show basic information about slot
                ISlotInfo slotInfo = slot.GetSlotInfo();



                if (slotInfo.SlotFlags.TokenPresent)
                {

                    // Show basic information about token present in the slot
                    ITokenInfo tokenInfo = slot.GetTokenInfo();
                    selectedSlot = slot;

                    Console.WriteLine("selectedSlot");
                    Console.WriteLine(selectedSlot);

                }
                else
                {
                    throw new Exception("No Eid present");
                }
            }

            if (selectedSlot != null)
            {
                // Open RW session
                using ISession session = selectedSlot.OpenSession(SessionType.ReadWrite);
                // Login as normal user
                //session.Login(CKU.CKU_USER, "3264");


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
                            //throw e; 
                            // todo linux error
                        }


                    }


                }
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
                }catch (Exception e)
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
