/* ****************************************************************************

 * eID Middleware Project.
 * Copyright (C) 2010-2010 FedICT.
 *
 * This is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License version
 * 3.0 as published by the Free Software Foundation.
 *
 * This software is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this software; if not, see
 * http://www.gnu.org/licenses/.

**************************************************************************** */
using System.Collections.Generic;
using System;
using System.Threading;

namespace Eid
{
    public class Program
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
            /*try
            {*/
                EidData data = new EidData(smartCardName);
                if (labels == null || labels.Count == 0)
                {
                    return data.GetAllValues();
                }
                else
                {
                    return data.GetValues(labels);
                }
                

           /* }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }*/
        }

        static void Main(string[] args)
        {
            //System.Diagnostics.Stopwatch duurtijd = new System.Diagnostics.Stopwatch();
            //duurtijd.Start();

            //Console.WriteLine(EidData.ModuleFileName);

            Console.WriteLine("mypack");
            EidData data = new EidData();


            foreach (KeyValuePair<String, String> kvp in data.GetAllValues())
            {
                //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            Thread.Sleep(20000);
            //Console.WriteLine("testAli");
            //Console.WriteLine(new EidData());
            //Thread.Sleep(20000);

            /*  Console.WriteLine(data.GetDATA_FILE());
              Console.WriteLine(data.GetADDRESS_FILE());
              Console.WriteLine(data.GetPHOTO_FILE());
              Console.WriteLine(data.GetSIGN_DATA_FILE());
              Console.WriteLine(data.GetSIGN_ADDRESS_FILE());
              Console.WriteLine(data.Getcard_number());
              Console.WriteLine(data.Getchip_number());
              Console.WriteLine(data.Getvalidity_begin_date());
              Console.WriteLine(data.Getvalidity_end_date());
              Console.WriteLine(data.Getissuing_municipality());
              Console.WriteLine(data.Getnational_number());
              Console.WriteLine(data.Getsurname());
              Console.WriteLine(data.Getfirstnames());
              Console.WriteLine(data.Getfirst_letter_of_third_given_name());
              Console.WriteLine(data.Getnationality());
              Console.WriteLine(data.Getlocation_of_birth());
              Console.WriteLine(data.Getdate_of_birth());
              Console.WriteLine(data.Getgender());
              Console.WriteLine(data.Getnobility());
              Console.WriteLine(data.Getdocument_type());
              Console.WriteLine(data.Getspecial_status());
              Console.WriteLine(data.Getphoto_hash());
              Console.WriteLine(data.Getduplicata());
              Console.WriteLine(data.Getspecial_organization());
              Console.WriteLine(data.Getmember_of_family());
              Console.WriteLine(data.Getdate_and_country_of_protection());
              Console.WriteLine(data.Getwork_permit_mention());
              Console.WriteLine(data.Getemployer_vat_1());
              Console.WriteLine(data.Getemployer_vat_2());
              Console.WriteLine(data.Getregional_file_number());
              Console.WriteLine(data.Getbasic_key_hash());
              Console.WriteLine(data.Getaddress_street_and_number());
              Console.WriteLine(data.Getaddress_zip());
              Console.WriteLine(data.Getaddress_municipality());
              Console.WriteLine(data.GetCERT_RN_FILE());*/
            /*Console.WriteLine("end");

            Thread.Sleep(20000);
        */

        }
    }
}
