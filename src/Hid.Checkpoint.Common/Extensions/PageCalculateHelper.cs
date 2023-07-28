namespace Hid.Checkpoint.Common.Extensions
{
    public static class PageCalculateHelper
    {
        public static int CalculatePageNumber(int? take, int? skip)
        {
            if (take is null or 0 || skip is 0 or null)
                return 1;
        
            var pageNumber = (int)Math.Ceiling((decimal)skip.Value / take.Value) + 1;
        
            return pageNumber;
        }
    }
}
