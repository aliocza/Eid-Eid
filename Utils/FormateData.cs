using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eid.Utils
{
    public class FormateData
    {

        public static String FormatDate(String date)
        {

            String[] dateExplosed = date.Split('.');

            String day = dateExplosed[0];
            String month = dateExplosed[1];
            String year = dateExplosed[2];

            return year + "-" + month + "-" + day;
        }



        public static String FormatBirthdate(String date)
        {

            // Step 1: create new Regex.
            Regex regex = new Regex(@"^[0-9]{2}\.(.?){3}\.[0-9]{4}$");
            // Step 2: call Match on Regex instance.
            Match match = regex.Match(date);

            string format = "( ){1,}";
            // Step 3: test for Success.
            if (match.Success)
            {
                format = "(\\.){1,}";
            }
            date = Regex.Replace(date, format, "/"); // prevent double nbsp

            String[] dateExplosed = date.Split('/');

            String day = dateExplosed[0];
            String month = dateExplosed[1];
            String year = dateExplosed[2];

            switch (month)
            {
                case "JAN":
                    month = "01";
                    break;
                case "FEV":
                case "FEB":
                    month = "02";
                    break;
                case "MARS":
                case "MAAR":
                case "MÄR":
                    month = "03";
                    break;
                case "AVR":
                case "APR":
                    month = "04";
                    break;
                case "MAI":
                case "MEI":
                    month = "05";
                    break;
                case "JUIN":
                case "JUN":
                    month = "06";
                    break;
                case "JUIL":
                case "JUL":
                    month = "07";
                    break;
                case "AOUT":
                case "AUG":
                    month = "08";
                    break;
                case "SEPT":
                case "SEP":
                    month = "09";
                    break;
                case "OCT":
                case "OKT":
                    month = "10";
                    break;
                case "NOV":
                    month = "11";
                    break;
                case "DEC":
                case "DEZ":
                    month = "12";
                    break;
                default:
                    break;
            }

            return year + "-" + month + "-" + day;
        }

    }
}
