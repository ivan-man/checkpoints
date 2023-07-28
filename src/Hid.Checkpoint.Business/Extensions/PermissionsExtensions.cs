using System.Linq.Expressions;
using System.Reflection;
using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.Business.Extensions;

public static class PermissionsExtensions
{
    public static TResult? ReturnByPermissions<TModel, TResult>(
        this TModel model,
        IReadOnlyDictionary<string, PropertyMetadata>? permissions,
        Expression<Func<TModel, TResult>> propertyExpression)
        where TModel : BaseEntity
    {
        if (permissions == null)
            return default;

        if (propertyExpression == null)
            throw new ArgumentNullException(nameof(propertyExpression));

        if (propertyExpression.Body is not MemberExpression memberExpression)
            throw new ArgumentException("Invalid property expression", nameof(propertyExpression));

        if (memberExpression.Member is not PropertyInfo propertyInfo)
            throw new ArgumentException("Invalid property expression", nameof(propertyExpression));

        var fullName = $"{typeof(TModel).FullName}.{propertyInfo.Name}";

        if (!permissions.TryGetValue(fullName, out var permissionModel) || permissionModel.Visible is not true)
        {
            return default;
        }

        var value = propertyInfo.GetValue(model);
        return value != null ? (TResult)value : default;
    }
}
