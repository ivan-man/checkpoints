using Hid.Checkpoint.Business.Handlers.PassRequests;
using Hid.CheckPoint.Shared;
using Hid.Checkpoint.DataAccess.Ef;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hid.Checkpoint.Business.PipelineBehaviors;

public class CreatePassRequestPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    //ToDo replace CreatePassRequestCommand with interface
    where TRequest : CreatePassRequestCommand, IRequest<TResponse>
    where TResponse : IResult
{
    private readonly IUnitOfWork _uow;
    private readonly ILogger<CreatePassRequestPipelineBehavior<TRequest, TResponse>> _logger;

    public CreatePassRequestPipelineBehavior(
        IUnitOfWork uow,
        ILogger<CreatePassRequestPipelineBehavior<TRequest, TResponse>> logger)
    {
        _uow = uow;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requiredSpecs = await _uow.RequestsMetadata
            .AsQueryable()
            .Where(q => q.RequestTypeId == request.TypeId)
            .Include(q => q.Property)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        if (!requiredSpecs.Any())
            return await next();

        var failures = new List<string>();

        var propertyInfos = typeof(CreatePassRequestCommand).GetProperties();
        var missingProperties = requiredSpecs.Where(q =>
                !propertyInfos.Any(pi => pi.Name.Equals(q.Property.Name, StringComparison.InvariantCultureIgnoreCase)))
            .Select(q => string.IsNullOrWhiteSpace(q.Property.DisplayName) ? q.Property.Name : q.Property.DisplayName)
            .ToArray();

        if (missingProperties.Any())
        {
            failures.Add($"Invalid command. Missing properties: {string.Join(",", missingProperties)}.");
        }

        foreach (var propertyInfo in propertyInfos)
        {
            var spec = requiredSpecs.FirstOrDefault(q =>
                q.Property.Name.Equals(propertyInfo.Name, StringComparison.InvariantCultureIgnoreCase));

            if (spec == null)
                continue;

            var value = propertyInfo.GetValue(request);
            var propertyType = propertyInfo.PropertyType;

            var defaultValue = propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;

            var isPropertyHasValue = value is not null && value != defaultValue;

            if (!isPropertyHasValue)
                failures.Add($"{spec.Property.DisplayName} not set.");
        }

        return failures.Count != 0
            ? Result.Validation(string.Join(". ", failures)).Adapt<TResponse>()
            : await next();
    }
}
