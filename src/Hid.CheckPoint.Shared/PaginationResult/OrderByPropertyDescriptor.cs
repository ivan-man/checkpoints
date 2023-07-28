using System.ComponentModel;
using System.Linq.Expressions;

namespace Hid.CheckPoint.Shared.PaginationResult
{
    /// <summary>
    /// Describes sorting for requests.
    /// </summary>
    /// <typeparam name="TEntity">Type of domain entity</typeparam>
    public class OrderByPropertyDescriptor<TEntity>
    {
        /// <summary>
        /// Expression of sorting
        /// </summary>
        public Expression<Func<TEntity, object>> Expression { get; set; }

        /// <summary>
        /// Sorting direction
        /// </summary>
        public EnumSortDirection Direction { get; set; }

        public OrderByPropertyDescriptor(
            Expression<Func<TEntity, object>> expression,
            EnumSortDirection direction = EnumSortDirection.Desc)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            Direction = direction != EnumSortDirection.None
                ? direction
                : throw new InvalidEnumArgumentException(nameof(direction), (int)direction, typeof(EnumSortDirection));
        }
    }
}
