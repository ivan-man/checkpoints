using System.Runtime.Serialization;

namespace Hid.Checkpoint.Common.ViewModels;

[DataContract]
public class PropertyMetadataViewModel
{
    [DataMember(Order = 1)] public string? InterfaceId { get; set; }
    [DataMember(Order = 2)] public string? Name { get; set; }
    [DataMember(Order = 3)] public string? FullName { get; set; }
    [DataMember(Order = 4)] public string? DisplayName { get; set; }
    [DataMember(Order = 5)] public bool? Required { get; set; }
    [DataMember(Order = 6)] public bool? Visible { get; set; }
    [DataMember(Order = 7)] public bool? ColumnDefaultVisibility { get; set; }
}
