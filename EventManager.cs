namespace Eid
{
    public class EventManager
    {

        // Definition of Delegates
        public delegate void ErrorEventHandler(object sender, string message);
        public delegate void WarningEventHandler(object sender, string message);
        public delegate void InfoEventHandler(object sender, string message);

        // Declaration of Events
        public event ErrorEventHandler ErrorOccurred;
        public event WarningEventHandler WarningOccurred;
        public event InfoEventHandler InfoOccurred;

        // Methods to Trigger Events
        protected virtual void OnErrorOccurred(string message)
        {
            ErrorOccurred?.Invoke(this, message);
        }

        protected virtual void OnWarningOccurred(string message)
        {
            WarningOccurred?.Invoke(this, message);
        }

        protected virtual void OnInfoOccurred(string message)
        {
            InfoOccurred?.Invoke(this, message);
        }


    }
}
