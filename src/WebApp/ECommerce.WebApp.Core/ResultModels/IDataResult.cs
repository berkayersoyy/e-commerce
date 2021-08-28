namespace ECommerce.WebApp.Core.ResultModels
{
    public interface IDataResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}