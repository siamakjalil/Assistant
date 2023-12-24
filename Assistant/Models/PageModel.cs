using System;
using System.Collections.Generic;
using System.Text;

namespace PersianAssistant.Models
{
    public class PageModel
    {
        public int Skip { get; set; }
        public int PageCount { get; set; }
        public int Take { get; set; }
    }
}
