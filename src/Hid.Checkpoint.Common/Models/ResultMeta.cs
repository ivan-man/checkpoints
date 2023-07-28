using System.Runtime.Serialization;
using Hid.CheckPoint.Shared;
using Hid.Checkpoint.Common.ViewModels;

namespace Hid.Checkpoint.Common.Models;

public interface IResultMeta<T> : IResult<T>
{
    Dictionary<string, PropertyMetadataViewModel?>? Metadata { get; set; }
}

[DataContract]
public class ResultMeta<T> : IResultMeta<T>
{
    [DataMember(Order = 1)] public bool Success { get; set; }
    [DataMember(Order = 2)] public string? Message { get; set; }
    [DataMember(Order = 3)] public T? Data { get; set; }
    [DataMember(Order = 4)] public int StatusCode { get; set; }

    [DataMember(Order = 5)] public Dictionary<string, PropertyMetadataViewModel?>? Metadata { get; set; } = new();

    public static ResultMeta<T> Ok(T data, string? message = null)
        => New(message, 200, data, true);

    public static ResultMeta<T> Created(T data, string? message = null)
        => New(message, 201, data, true);

    public static ResultMeta<T> Accepted(T? data = default, string? message = null)
        => New(message, 202, data, true);

    public static ResultMeta<T> NoContent(string? message = null)
        => New(message, 204);

    public static ResultMeta<T> Bad(string? message)
        => New(message, 400);

    public static ResultMeta<T> UnAuthorized(string? message)
        => New(message, 401);

    public static ResultMeta<T> Forbidden(string? message)
        => New(message, 403);

    public static ResultMeta<T> NotFound(string? message)
        => New(message, 404);

    public static ResultMeta<T> ImTeapot(string? message = default)
        => New(message, 418);

    public static ResultMeta<T> Failed(string? message, int code = 500)
        => New(message, code);

    public static ResultMeta<T> Failed(IResult result)
        => New(result.Message, result.StatusCode);

    public static ResultMeta<T> Internal(string message)
        => New(message, 500);

    public static ResultMeta<T> Validation(string message)
        => New(message, 600);

    private static ResultMeta<T> New(
        string? message,
        int code = 422,
        T? data = default,
        bool success = false)
    {
        return new ResultMeta<T> { Message = message, StatusCode = code, Success = success, Data = data };
    }
}
