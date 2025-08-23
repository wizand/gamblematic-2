
namespace GambleMaticCommLib
{
    public class ApiResult<T>
    {

        public ApiResult(ApiError? error = null)
        {
            Error = error;
        }

        public ApiResult( T? payload, ApiError? error = null)
        {
            Error = error;
            Payload = payload;
        }

        public bool Success { get => Error == null; }
        public bool Failed { get => !Success; }
        public ApiError? Error { get; set; } = null;
        public T? Payload { get; set; } = default;
        private string? _message = null;
        public string? Message
        {
            get
            {
                //Prefer explicitly set message
                if (_message != null) 
                { 
                    return _message; 
                }
                //If no explicit message, use error message if available
                if (Error != null) 
                { 
                    _message = Error.ErrorMessage;
                }
                return _message;

            }
            set { _message = value; }
        }
    }

    public class ApiError
    {
        public ApiError(string? errorMessage = "Unknown error", Exception? exception = null)
        {
            ErrorMessage = errorMessage;
            Exception = exception;
        }   

        public ApiError(string? errorMessage = "Unknown error")
        {
            ErrorMessage = errorMessage;
            Exception = null;
        }

        public ApiError(Exception exception)
        {
            ErrorMessage = exception.Message;
            Exception = exception;
        }

        public string? ErrorMessage { get; set; } = null;
        public Exception? Exception { get; set; } = null;


        public override string ToString()
        {
         
            string errMessage = string.Empty;
            if (ErrorMessage != null)
            {
                errMessage = ErrorMessage.ToString();
            }

            if (Exception != null) 
            {
                errMessage += Exception.ToString();
            }

            return errMessage;

        }


    }
}
