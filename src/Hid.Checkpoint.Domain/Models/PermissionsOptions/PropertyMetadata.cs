using Hid.CheckPoint.Shared.Domain;
using Hid.Checkpoint.Audit.Abstractions.Attributes;
using Hid.Checkpoint.Audit.Abstractions.Enums;
using Hid.Checkpoint.Common.Enums;
using Hid.Checkpoint.Domain.Attributes;

namespace Hid.Checkpoint.Domain.Models;

[AuditedEntity(EntityChangesTypes.All)]
public class PropertyMetadata : BaseEntity<int>
{
    public int? RequestTypeId { get; init; }
    public PassRequestType? RequestType { get; init; }

    public RoleFlags? Role { get; init; }

    public int? EmployeeId { get; init; }
    public Person? Employee { get; init; }

    [VisibilityRequired] public bool Required { get; set; }
    public bool Visible { get; set; }

    /// <summary>
    /// Настройка видимости колонки для пользователя в таблицах по умолчанию.
    /// </summary>
    [VisibilityRequired]
    public bool ColumnDefaultVisibility { get; set; }

    public int PropertyId { get; set; }
    public CustomizableProperty Property { get; set; }
    
    [Obsolete("Only for ef")]
    public PropertyMetadata()
    {
    }
    
    public PropertyMetadata(CustomizableProperty propertyDescription)
    {
        Property = propertyDescription;
    }
}

// public class PropertyMetadata<TModel> : PropertyMetadata
//     where TModel : BaseEntity, new()
// {
// }

public class RequestMetadata : PropertyMetadata
{
}

public class PersonMetadata : PropertyMetadata
{
}

public class ProfileMetadata : PropertyMetadata
{
}

public class OrganizationMetadata : PropertyMetadata
{
}
