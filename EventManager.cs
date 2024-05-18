using Eid.Utils;
using static Eid.Utils.ErrorCode;

namespace Eid
{
    public class EventManager
    {

        private static EventManager _eventEid;

        public static EventManager EventEid
        {
            get
            {
                if (_eventEid == null)
                {
                    _eventEid = new EventManager();
                }
                return _eventEid;
            }
            private set
            {
                _eventEid = value;
            }
        }

        // Definition of Delegates
        public delegate void ErrorEventHandler(object sender, ErrorCode.Code code, string message);




        // Declaration of Events
        public event ErrorEventHandler ErrorOccurred;


        // Methods to Trigger Events
        protected virtual void OnErrorOccurred(ErrorCode.Code code)
        {
            ErrorOccurred?.Invoke(this, code, null);
        }

        protected virtual void OnErrorOccurred(ErrorCode.Code code, string message)
        {
            ErrorOccurred?.Invoke(this, code, message);
        }



        public void RaiseErrorOccurred(ErrorCode.Code code) { 
            OnErrorOccurred(code);
        }

        public void RaiseErrorOccurred(ErrorCode.Code code, string message)
        {
            OnErrorOccurred(code, message);
        }

    }
}
