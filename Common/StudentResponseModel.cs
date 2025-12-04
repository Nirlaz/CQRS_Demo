namespace Common
{

    public record StudentResponseModel<T>(bool Success, string Message, T data)
    {
        public static StudentResponseModel<T> Fail(string message) => new(false, message, default);

        public static StudentResponseModel<T> Ok(string message,T data) => new(true, message , data);
    }
}
