using System;
using System.Collections.Generic;
using System.Text;

namespace MobileV1.Models
{
    class Pagination<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PagesCount { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }
    }
}
