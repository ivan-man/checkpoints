using Hid.CheckPoint.Shared;
using Hid.Checkpoint.Common.ViewModels;
using Hid.Checkpoint.DataAccess.Ef;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.PipelineBehaviors;

public class PropertyFilteringBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUnitOfWork _uow;
    private readonly IHttpContextAccessor _accessor;
    private readonly ILogger<PropertyFilteringBehavior<TRequest, TResponse>> _logger;

    public PropertyFilteringBehavior(
        IUnitOfWork uow, 
        IHttpContextAccessor httpContextAccessor, 
        IMemoryCache memoryCache, 
        ILogger<PropertyFilteringBehavior<TRequest, TResponse>> logger)
    {
        _uow = uow;
        _accessor = httpContextAccessor;
        _memoryCache = memoryCache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        var response = await next();
        
        try
        {
            if (response is IRequest<IResult<EmployeeViewModel>> employee)
            {
                
            }

            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to change response by user permissions. {@Response}", response);
            return response;
        }
    }
    
    
}
