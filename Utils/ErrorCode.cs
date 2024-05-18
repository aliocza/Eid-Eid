using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eid.Utils
{
    public class ErrorCode
    {
        public enum Code
        {
            [Description("No smart card")]
            NO_SMARTCARD,
            [Description("No card")]
            NO_CARD,
            [Description("Unknown")]
            UNKNOW,
            [Description("Unable to read label")]
            LABEL_NO_READABLE
        };

        public static string GetDescription(ErrorCode.Code value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
