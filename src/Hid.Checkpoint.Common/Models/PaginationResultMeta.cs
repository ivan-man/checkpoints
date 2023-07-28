using System.Runtime.Serialization;
using Hid.Checkpoint.Common.ViewModels;

namespace Hid.Checkpoint.Common.Models;

[DataContract]
public class PaginationResultMeta<T> : IResultMeta<IEnumerable<T>>
{
    [DataMember(Order = 1)] public bool Success { get; set; }
    [DataMember(Order = 2)] public string? Message { get; set; }
    [DataMember(Order = 3)] public int Count { get; set; }
    [DataMember(Order = 4)] public int Page { get; set; }
    [DataMember(Order = 5)] public int Total { get; set; }
    [DataMember(Order = 6)] public IEnumerable<T>? Data { get; set; }
    [DataMember(Order = 7)] public int StatusCode { get; set; }
    
    [DataMember(Order = 8)] public Dictionary<string, PropertyMetadataViewModel?>? Metadata { get; set; } = new();
}
