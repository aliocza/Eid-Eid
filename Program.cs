using System.Collections.Generic;
using System;
using System.Threading;

namespace Eid
{
    public class Program
    {

        
        // test only
        static void Main(string[] args)
        {

            try {
                EidData data = new EidData();
                foreach (KeyValuePair<String, String> kvp in data.GetAllValues())
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
                Thread.Sleep(20000);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: {0}",ex.Message.ToString());
            }

        }
    }
}
