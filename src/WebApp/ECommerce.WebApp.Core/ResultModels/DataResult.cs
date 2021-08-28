namespace ECommerce.WebApp.Core.ResultModels
{
    public class DataResult<T>:IDataResult<T>,IResult
    {
        public DataResult(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }
        public DataResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}