using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Reflection;
using Hid.CheckPoint.Shared.Attributes;
using Hid.CheckPoint.Shared.Domain;

namespace Hid.Checkpoint.Domain.Models;

public class CustomizableProperty : BaseEntity<string>
{
    public string InterfaceId { get; set; }

    public string TypeName { get; init; }

    public string TypeFullName { get; init; }
    public string Name { get; set; }
    public string? DisplayName { get; set; }
    public bool IsHidden { get; set; }

    [NotMapped] public string? FullName => Id;

    [Obsolete("Only for ef. Use 'CreateModel' method")]
    public CustomizableProperty()
    {
    }

    public static TProperty CreateModel<TModel, TResult, TProperty>(
        Expression<Func<TModel, TResult>> propertyExpression,
        string interfaceId)
        where TProperty : CustomizableProperty, new()
    {
        if (propertyExpression == null)
            throw new ArgumentNullException(nameof(propertyExpression));

        if (propertyExpression.Body is not MemberExpression memberExpression)
            throw new ArgumentException("Invalid property expression", nameof(propertyExpression));

        if (memberExpression.Member is not PropertyInfo propertyInfo)
            throw new ArgumentException("Invalid property expression", nameof(propertyExpression));

        return CreateModel<TModel, TProperty>(propertyInfo, interfaceId);
    }

    public static TProperty CreateModel<TModel, TProperty>(
        PropertyInfo propertyInfo,
        string? interfaceId = null)
    where TProperty : CustomizableProperty, new()
    {
        var model = new TProperty
        {
            TypeName = typeof(TModel).Name,
            TypeFullName = typeof(TModel).FullName ?? throw new ValidationException("Invalid type of model"),
        };

        if (propertyInfo == null)
            throw new ArgumentNullException(nameof(propertyInfo));

        model.Name = propertyInfo.Name;
        model.Id = $"{model.TypeFullName}.{model.Name}";
        var metadataAttribute = propertyInfo.GetCustomAttributes<MetadataAttribute>().FirstOrDefault();
        model.DisplayName = metadataAttribute?.DisplayName;
        model.IsHidden = metadataAttribute?.IsHidden ?? false;
        interfaceId ??= $"{model.TypeFullName}.{model.Name}";
        model.InterfaceId = interfaceId;

        return model;
    }
}

public class RequestProperty : CustomizableProperty
{
    public static RequestProperty CreateModel<TResult>(
        Expression<Func<PassRequest, TResult>> propertyExpression,
        string interfaceId)
        => CustomizableProperty.CreateModel<PassRequest, TResult, RequestProperty>(propertyExpression, interfaceId);
    
    public static RequestProperty CreateModel(
        PropertyInfo propertyInfo,
        string? interfaceId = null)
        => CustomizableProperty.CreateModel<PassRequest, RequestProperty>(propertyInfo, interfaceId);
}

public class PersonProperty : CustomizableProperty
{
    public static PersonProperty CreateModel<TResult>(
        Expression<Func<Person, TResult>> propertyExpression,
        string interfaceId)
        => CustomizableProperty.CreateModel<Person, TResult, PersonProperty>(propertyExpression, interfaceId);
    
    public static PersonProperty CreateModel(
        PropertyInfo propertyInfo,
        string? interfaceId = null)
        => CustomizableProperty.CreateModel<Person, PersonProperty>(propertyInfo, interfaceId);
}

public class ProfileProperty : CustomizableProperty
{
    public static CustomizableProperty CreateModel<TResult>(
        Expression<Func<Profile, TResult>> propertyExpression,
        string interfaceId)
        => CustomizableProperty.CreateModel<Profile, TResult, CustomizableProperty>(propertyExpression, interfaceId);
    
    public static ProfileProperty CreateModel(
        PropertyInfo propertyInfo,
        string? interfaceId = null)
        => CustomizableProperty.CreateModel<Profile, ProfileProperty>(propertyInfo, interfaceId);
}

public class OrganizationProperty : CustomizableProperty
{
    public static CustomizableProperty CreateModel<TResult>(
        Expression<Func<Organization, TResult>> propertyExpression,
        string interfaceId)
        => CustomizableProperty.CreateModel<Organization, TResult, OrganizationProperty>(propertyExpression, interfaceId);
    
    public static OrganizationProperty CreateModel(
        PropertyInfo propertyInfo,
        string? interfaceId = null)
        => CustomizableProperty.CreateModel<Organization, OrganizationProperty>(propertyInfo, interfaceId);
}



// public class CustomizableProperty<TModel> : CustomizableProperty
//     where TModel : BaseEntity, new()
// {
//     [Obsolete("Only for ef")]
//     public CustomizableProperty()
//     {
//     }
//
//     protected static CustomizableProperty<TModel> CreateModel<TChild, TResult>(
//         Expression<Func<TModel, TResult>> propertyExpression,
//         string? interfaceId = null)
//         where TChild : CustomizableProperty<TModel>, new()
//     {
// #pragma warning disable CS0618
//         var model = new TChild();
// #pragma warning restore CS0618
//
//         if (propertyExpression == null)
//             throw new ArgumentNullException(nameof(propertyExpression));
//
//         if (string.IsNullOrWhiteSpace(interfaceId))
//             throw new ArgumentNullException(nameof(interfaceId));
//
//         if (propertyExpression.Body is not MemberExpression memberExpression)
//             throw new ArgumentException("Invalid property expression", nameof(propertyExpression));
//
//         if (memberExpression.Member is not PropertyInfo propertyInfo)
//             throw new ArgumentException("Invalid property expression", nameof(propertyExpression));
//
//         model.Name = propertyInfo.Name;
//         var display = propertyInfo.GetCustomAttributes<DisplayAttribute>().FirstOrDefault();
//         model.DisplayName = display?.Name;
//         model.FullName = $"{model.TypeFullName}.{model.Name}";
//         model.InterfaceId = interfaceId;
//
//         throw new ArgumentException("Invalid property expression", nameof(propertyExpression));
//     }
// }
