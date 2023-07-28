namespace Hid.CheckPoint.Shared;

public static class ResultExtensions
{
    public static async Task<Result<T>> ToFailedResultAsync<T>(this HttpResponseMessage response)
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        return Result<T>.Failed(
            $"{response.StatusCode}: {response.ReasonPhrase}.{Environment.NewLine}{responseContent}",
            (int)response.StatusCode);
    }

    public static async Task<Result> ToFailedResultAsync(this HttpResponseMessage response)
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        return Result.Failed($"{response.StatusCode}: {response.ReasonPhrase}.{Environment.NewLine}{responseContent}",
            (int)response.StatusCode);
    }

    public static async Task<ResultList<T>> ToFailedResultListAsync<T>(this HttpResponseMessage response)
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        return ResultList<T>.Failed(
            $"{response.StatusCode}: {response.ReasonPhrase}{Environment.NewLine}{responseContent}",
            (int)response.StatusCode);
    }
}
