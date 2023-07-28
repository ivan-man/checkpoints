namespace Hid.Checkpoint.Common.ViewModels;

public class MetaValueViewModel<TValue>
{
    public string? PropertyId { get; set; }
    public string? PropertyName { get; set; }
    public string? PropertyDisplayName { get; set; }
    
    public TValue? Value { get; set; }
    public bool IsVisible { get; set; } = true;
    public bool ColumnDefaultVisibility { get; set; } = true;
}
