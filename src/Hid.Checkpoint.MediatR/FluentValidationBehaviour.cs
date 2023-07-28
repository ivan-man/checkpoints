using FluentValidation;
using Hid.CheckPoint.Shared;
using Mapster;
using MediatR;

namespace Hid.Checkpoint.MediatR;

public class FluentValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public FluentValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(s => s.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .Select(e => e.ErrorMessage)
            .ToList();

        return failures.Count != 0
            ? Task.FromResult(Result.Bad(string.Join(". ", failures)).Adapt<TResponse>())
            : next();
    }
}
