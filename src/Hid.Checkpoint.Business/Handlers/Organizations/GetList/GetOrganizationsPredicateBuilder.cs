using System.Linq.Expressions;
using Hid.Checkpoint.Domain.Models;
using Hid.CheckPoint.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hid.Checkpoint.Business.Handlers.Organizations.GetList;

public static class GetOrganizationsPredicateBuilder
{
    public static Expression<Func<Organization, bool>> GetPredicate(this GetOrganizationsListCommand filter)
    {
        filter = filter ?? throw new ArgumentNullException(nameof(filter));

        Expression<Func<Organization, bool>> predicate = filter.IncludeRemoved is true
            ? q => true
            : q => !q.Removed;

        if (filter.Id?.Any() == true)
            predicate = predicate.And(item => filter.Id.Any(q => q == item.Id));

        if (filter.Id?.Any() == true)
            predicate = predicate.And(item => filter.ExternalId!.Any(q => q == item.ExternalId));

        if (!string.IsNullOrWhiteSpace(filter.Search))
            predicate = predicate.And(item => EF.Functions.ILike(item.Name, $"%{filter.Search}%"));

        if (!string.IsNullOrWhiteSpace(filter.Inn))
            predicate = predicate.And(item => EF.Functions.ILike(item.Inn, $"%{filter.Inn}%"));

        if (!string.IsNullOrWhiteSpace(filter.Kpp))
            predicate = predicate.And(item => EF.Functions.ILike(item.Kpp, $"%{filter.Kpp}%"));

        if (!string.IsNullOrWhiteSpace(filter.Okpo))
            predicate = predicate.And(item => EF.Functions.ILike(item.Okpo, $"%{filter.Okpo}%"));

        if (!string.IsNullOrWhiteSpace(filter.Okato))
            predicate = predicate.And(item => EF.Functions.ILike(item.Okato, $"%{filter.Okato}%"));

        if (!string.IsNullOrWhiteSpace(filter.Imns))
            predicate = predicate.And(item => EF.Functions.ILike(item.Imns, $"%{filter.Imns}%"));

        if (filter.Type.HasValue)
            predicate = predicate.And(item => item.Type == filter.Type.Value);

        return predicate;
    }
}
