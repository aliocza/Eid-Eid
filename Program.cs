using System.Collections.Generic;
using System;
using System.Threading;
using Eid.Service;
using Eid.Controller;

namespace Eid
{
    public class Program
    {

        
        // test only
        static void Main(string[] args)
        {

            ErrorHandler errorHandler = new ErrorHandler();
            errorHandler.Subscribe();

            try {
                foreach (KeyValuePair<String, String> kvp in ReadEidController.GetEid())
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
