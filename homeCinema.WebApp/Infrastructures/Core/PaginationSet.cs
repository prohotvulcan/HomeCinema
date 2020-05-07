using System;
using System.Collections.Generic;
using System.Linq;

namespace homeCinema.WebApp.Infrastructures.Core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }

        public int Count
        {
            get
            {
                return Items != null ? Items.Count() : 0;
            }
        }

        public int PageSize { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalCount / PageSize);
            }
        }

        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
