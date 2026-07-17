using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.BaseEntity
{
    internal class PaginateResualt<T>
    {
      
            public List<T> Items { get; set; } = new();

            public int TotalCount { get; set; }

            public int PageNumber { get; set; }

            public int PageSize { get; set; }

            public int TotalPages =>
                (int)Math.Ceiling((double)TotalCount / PageSize);
        
    }
}
