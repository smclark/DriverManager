using DriverManager.Models.Interfaces.Messages;

namespace DriverManager.Models.Messages
{
    public class ErrorMessage : IErrorMessage
    {
        public int ErrorCode { get; private set; }

        public ErrorMessage(int errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
