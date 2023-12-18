using System;
using System.Collections.Generic;
using System.Text;
using Assistant.Models;

namespace Assistant.Extensions
{
    public static class PageExtension
    {
        public static PageModel Paging(this int pageId, int count , int take)
        {
            var div = count / take;
            var check = count - (div * take);
            return new PageModel()
            {
                Skip = (pageId - 1) * take,
                PageCount = (check == 0) ? div : div + 1,
                Take = take
            };


        }
    }
}
