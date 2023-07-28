using System.Runtime.Serialization;

namespace Hid.CheckPoint.Shared
{
    [DataContract]
    public class ResultList<T> : IResult<IEnumerable<T>>
    {
        [DataMember(Order = 1)] public bool Success { get; set; }
        [DataMember(Order = 2)] public string? Message { get; set; }
        [DataMember(Order = 3)] public IEnumerable<T>? Data { get; set; }
        [DataMember(Order = 4)] public int StatusCode { get; set; }
        
        public static ResultList<T> Ok(IEnumerable<T>? data, string? message = null)
            => New(message, 200, data, true);

        public static ResultList<T> Created(IEnumerable<T>? data, string? message = null)
            => New(message, 201, data, true);

        public static ResultList<T> Accepted(IEnumerable<T>? data, string? message = null)
            => New(message, 202, data, true);

        public static ResultList<T> NoContent(string? message = null)
            => New(message, 204);

        public static ResultList<T> Bad(string message)
            => New(message, 400);

        public static ResultList<T> UnAuthorized(string message)
            => New(message, 401);

        public static ResultList<T> Forbidden(string message = IResult.AccessDenied)
            => New(message, 403);

        public static ResultList<T> NotFound(string message = IResult.NotFound)
            => New(message, 404);

        public static ResultList<T> Failed(string message, int code = 500)
            => New(message, code);

        public static ResultList<T> Failed(IResult result)
            => New(result.Message, result.StatusCode);

        public static ResultList<T> Internal(string message)
            => New(message, 500);

        public static ResultList<T> Validation(string message)
            => New(message, 600);

        private static ResultList<T> New(
            string? message,
            int code = 422,
            IEnumerable<T>? data = default,
            bool success = false)
        {
            return new ResultList<T> { Message = message, StatusCode = code, Success = success, Data = data };
        }
    }
}
