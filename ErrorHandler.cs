using Eid.Utils;
using System;

namespace Eid
{
    public class ErrorHandler
    {
        public void Subscribe()
        {
            EventManager.EventEid.ErrorOccurred += HandleErrorOccurred;
        }

        private void HandleErrorOccurred(object sender, ErrorCode.Code code, string message)
        {
            Console.WriteLine($"Code: {code}, message: {ErrorCode.GetDescription(code)}, detail: {message}");

        }

        public void Unsubscribe()
            {
                EventManager.EventEid.ErrorOccurred -= HandleErrorOccurred;
            }
        }
}
