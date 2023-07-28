using Hid.CheckPoint.Shared;
using Hid.CheckPoint.Shared.PaginationResult;
using Microsoft.AspNetCore.Mvc;

namespace Hid.Shared.Result.Mvc.Core.Response;

public static class ResultExtensions
{
    public static ObjectResult HttpResponse<T>(this IResult<T> result)
    {
        return new ObjectResult(result.Success ? result.Data : new { result.Message })
        {
            StatusCode = result.StatusCode,
        };
    }

    public static ObjectResult HttpResponse(this IResult result)
    {
        return new ObjectResult(result.Success ? String.Empty : new { result.Message })
        {
            StatusCode = result.StatusCode
        };
    }

    public static ObjectResult HttpResponse<T>(this PaginationResult<T> result)
    {
        return new ObjectResult(result.Success
            ? new
            {
                result.PageSize, result.PageNumber, result.Total, result.Data,
            }
            : new { result.Message }) { StatusCode = result.StatusCode, };
    }
}
