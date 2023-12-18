using Assistant.Enum;
using Assistant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assistant.Extensions
{
    public static class StatusExtension
    {
        public static List<DropDownModels> StatusList()
        {
            return new List<DropDownModels>()
            {
                new DropDownModels()
                {
                    Id = (int)Status.Active,
                    Title = ((int)Status.Active).GetStatusVal()
                },
                new DropDownModels()
                {
                    Id = (int)Status.DeActive,
                    Title = ((int)Status.DeActive).GetStatusVal()
                }
            };
        }
        public static string GetStatusVal(this int value)
        {
            return value switch
            {
                1 => "فعال",
                2 => "غیرفعال",
                3 => "حذف شده",
                _ => ""
            };
        }
    }
}
