using Eid.Service;
using Eid.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eid.Controller
{
    internal class ReadEidController
    {

        public static Dictionary<string, string> GetEid()
        {
            return GetEid(null, null);
        }
        public static Dictionary<string, string> GetEid(String smartCardName)
        {
            return GetEid(smartCardName, null);
        }

        public static Dictionary<string, string> GetEid(String smartCardName, List<String> labels)
        {
            try
            {
                EidService data = new EidService(smartCardName);
                if (labels == null || labels.Count == 0)
                {
                    return data.GetAllValues();
                }
                else
                {
                    return data.GetValues(labels);
                }
            }
            catch (Exception e)
             {
                new EventManager().RaiseErrorOccurred(ErrorCode.Code.UNKNOW, e.Message.ToString());
                return null;
            }
        }

    }
}
