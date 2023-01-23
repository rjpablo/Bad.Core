using System;
using System.Collections.Generic;
using System.Text;

namespace Bad.Core.Models
{
    public class PagedGetRequestInputModel
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}
