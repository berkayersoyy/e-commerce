namespace ECommerce.WebApp.Core.ResultModels
{
    public class Result:IResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}