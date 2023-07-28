namespace Hid.Checkpoint.Business.Handlers;

public class PaginationBaseCommand
{
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    
    public bool? IncludeRemoved { get; set; }
}
