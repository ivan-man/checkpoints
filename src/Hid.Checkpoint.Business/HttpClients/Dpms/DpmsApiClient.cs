using System.Net.Http.Json;
using System.Web;
using Hid.Checkpoint.Business.HttpClients.Dpms.Dto;
using Hid.CheckPoint.Shared;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.HttpClients.Dpms;

internal class DpmsApiClient : IDpmsApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<DpmsApiClient> _logger;

    public DpmsApiClient(IHttpClientFactory clientFactory,
        ILogger<DpmsApiClient> logger)
    {
        _httpClient = clientFactory.CreateDpmsApiClient();
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task<ResultList<EmployeeDto>> GetEmployeesAsync(
        DateTime? modifiedAfter,
        Guid? uid,
        CancellationToken cancellationToken = default)
    {
        return await BaseGetAsync(
            "/external/staffing/employees", 
            "Employees", 
            modifiedAfter, 
            uid,
            cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ResultList<EmployeeDto>> GetOrganizationsAsync(
        DateTime? modifiedAfter,
        Guid? uid,
        CancellationToken cancellationToken = default)
    {
        return await BaseGetAsync(
            "/external/staffing/organizations",
            "Organizations",
            modifiedAfter,
            uid,
            cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ResultList<EmployeeDto>> GetSubdivisionsAsync(
        DateTime? modifiedAfter,
        Guid? uid,
        CancellationToken cancellationToken = default)
    {
        return await BaseGetAsync(
            "/external/staffing/units",
            "Subdivisions",
            modifiedAfter,
            uid,
            cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ResultList<EmployeeDto>> GetAccessLevelsAsync(
        DateTime? modifiedAfter,
        CancellationToken cancellationToken = default)
    {
        return await BaseGetAsync(
            "/internal/accessControl/accessLevels",
            "AccessLevels",
            modifiedAfter,
            null,
            cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ResultList<EmployeeDto>> GetAccessPointsAsync(
        CancellationToken cancellationToken = default)
    {
        return await BaseGetAsync(
            "/external/accessControl/accessPoints",
            "AccessLevels",
            null,
            null,
            cancellationToken);
    }
    
    /// <inheritdoc/>
    public async Task<Result> EditAccessLevelListAsync(
        IEnumerable<AccessLevel> accessLevels,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (accessLevels?.Any() != true)
                return Result.Bad("Empty list of access levels");
            
            var httpRequest = new HttpRequestMessage(HttpMethod.Put, "/internal/accessControl/accessLevels")
            {
                Content = JsonContent.Create(accessLevels),
            };

            var httpResponse = await _httpClient.SendAsync(httpRequest, cancellationToken);

            var responseContent = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

            if (httpResponse.IsSuccessStatusCode) 
                return Result.Ok();
            
            _logger.LogError("Failed to edit AccessLevels on Dpms. {@AccessLevels} {Response}",
                accessLevels,  responseContent);
            
            return await httpResponse.ToFailedResultAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to edit AccessLevels on Dpms. {@AccessLevels}", accessLevels);
            return Result.Internal($"Failed to edit AccessLevels on Dpms");
        }
    }

    private async Task<ResultList<EmployeeDto>> BaseGetAsync(
        string apiMethodAddress,
        string dtoName,
        DateTime? modifiedAfter,
        Guid? uid,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var builder = new UriBuilder(apiMethodAddress);
            var query = HttpUtility.ParseQueryString(builder.Query);

            if (modifiedAfter.HasValue)
                query["modifiedAfter"] = modifiedAfter.Value.ToString("yyyy-MM-dd");

            if (uid.HasValue)
                query["uid"] = uid.Value.ToString();

            builder.Query = query.ToString();
            var url = builder.ToString();

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);

            var httpResponse = await _httpClient.SendAsync(httpRequest, cancellationToken);

            var responseContent = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

            if (!httpResponse.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to get {dtoName} from Dpms. {Response}",
                    dtoName, responseContent);
                return await httpResponse.ToFailedResultListAsync<EmployeeDto>();
            }

            var data = Newtonsoft.Json.JsonConvert
                .DeserializeObject<List<EmployeeDto>>(responseContent);

            if (data == null)
                _logger.LogError("Failed to deserialize Dpms service response {response}", responseContent);

            return data != null
                ? ResultList<EmployeeDto>.Ok(data)
                : ResultList<EmployeeDto>.NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get {dtoName} from Dpms. {modifiedAfter} {uid}",
                dtoName, modifiedAfter, uid);
            return ResultList<EmployeeDto>.Internal($"Failed to get {dtoName} from Dpms");
        }
    }
}
