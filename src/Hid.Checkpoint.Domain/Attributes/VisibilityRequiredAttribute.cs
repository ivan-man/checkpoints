using System.ComponentModel.DataAnnotations;
using Hid.Checkpoint.Domain.Models;

namespace Hid.Checkpoint.Domain.Attributes;

public class VisibilityRequiredAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var propertyMetadata = (PropertyMetadata)validationContext.ObjectInstance;

        return propertyMetadata switch
        {
            { Required: true, Visible: false } 
                => new ValidationResult("'Visible' cannot be 'false' when 'Required' is true"),
            { ColumnDefaultVisibility: true, Visible: false }
                => new ValidationResult("'Visible' cannot be 'false' when 'ColumnDefaultVisibility' is true"),
            _ => ValidationResult.Success
        };
    }
}
