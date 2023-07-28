using System.Runtime.Serialization;

namespace Hid.CheckPoint.Shared.PaginationResult
{
    [DataContract]
    public class PaginationResult<T> : IResult<IEnumerable<T>>
    {
        [DataMember(Order = 1)] public bool Success { get; set; }
        [DataMember(Order = 2)] public string? Message { get; set; }
        [DataMember(Order = 3)] public int PageSize { get; set; }
        [DataMember(Order = 4)] public int PageNumber { get; set; }
        [DataMember(Order = 5)] public int Total { get; set; }
        [DataMember(Order = 6)] public IEnumerable<T>? Data { get; set; }
        [DataMember(Order = 7)] public int StatusCode { get; set; }

        public static PaginationResult<T> Ok(IEnumerable<T> data, int pageSize = 0, int pageNumber = 0, int total = 0)
            => New(null, 200, data, true, pageSize, pageNumber, total);

        public static PaginationResult<T> NoContent()
            => New(null, 204, default, true);

        public static PaginationResult<T> Bad(string message)
            => New(message, 400);

        public static PaginationResult<T> Forbidden(string message)
            => New(message, 401);

        public static PaginationResult<T> UnAuthorized(string message)
            => New(message, 403);

        public static PaginationResult<T> NotFound(string message)
            => New(message, 404);

        public static PaginationResult<T> Failed(string message, int code = 500)
            => New(message, code);

        public static PaginationResult<T> Failed(IResult result)
            => New(result.Message, result.StatusCode);

        public static PaginationResult<T> Internal(string message)
            => New(message, 500);

        public static PaginationResult<T> Validation(string message)
            => New(message, 600);

        private static PaginationResult<T> New(
            string message,
            int code = 422,
            IEnumerable<T>? data = default,
            bool success = false,
            int pageSize = 0,
            int pageNumber = 0,
            int total = 0)
        {
            return new PaginationResult<T>
            {
                Message = message,
                StatusCode = code,
                Success = success,
                Data = data,
                PageSize = pageSize,
                PageNumber = pageNumber,
                Total = total
            };
        }
    }
}
