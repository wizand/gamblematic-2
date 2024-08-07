
namespace GambleMaticCommLib
{
    public class ApiResult<T>
    {
        public ApiResult( T[]? payload, bool success = true, ApiError? error = null)
        {
            Success = success;
            Error = error;

            Payload = payload;
        }

        public bool Success = false;
        public bool Failed => !Success;
        public ApiError? Error = null;
        public T[]? Payload = null;
    }

    public class ApiError
    {
        public string? Message { get; set; } = null;
        public Exception? Exception { get; set; } = null;


        public override string ToString()
        {
         
            string errMessage = string.Empty;
            if (Message != null)
            {
                errMessage = Message.ToString();
            }

            if (Exception != null) 
            {
                errMessage += Exception.ToString();
            }

            return errMessage;

        }


    }
}
