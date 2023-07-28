namespace Hid.CheckPoint.Shared
{
    public interface IResult
    {
        public const string AccessDenied = "Access denied";
        public const string NotFound = "Not found";
        
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }

    public interface IResult<T> : IResult
    {
        T Data { get; set; }
    }
}
