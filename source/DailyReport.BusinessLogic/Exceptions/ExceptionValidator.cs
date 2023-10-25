using System.Runtime.Serialization;

namespace DailyReport.BusinessLogic.Exceptions
{
    public class ExceptionValidator
    {
        [Serializable]
        public class ValidationException : ApplicationException
        {
            public ValidationException()
            {
            }

            public ValidationException(string message)
                : base(message)
            {
            }

            public ValidationException(string message, Exception inner)
                : base(message, inner)
            {
            }

            protected ValidationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
}
