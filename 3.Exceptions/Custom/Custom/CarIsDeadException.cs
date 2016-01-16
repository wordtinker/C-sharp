using System;

namespace Custom
{
    [Serializable]
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }

        // Feed message to parent constructor.
        public CarIsDeadException(string message, string cause, DateTime time)
            : base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        public CarIsDeadException(string message) : base(message) { }
        public CarIsDeadException(string message,
                                  System.Exception inner)
            : base(message, inner)
        { }
        protected CarIsDeadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

        // Any additional custom properties, constructors and data members...
    }
}
