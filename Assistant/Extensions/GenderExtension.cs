using PersianAssistant.Enum;
using PersianAssistant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersianAssistant.Extensions
{
    public static class GenderExtension
    {
        public static string GetGenderVal(this int value)
        {
            return value switch
            {
                1 => "مرد",
                2 => "زن",
                _ => ""
            };
        }
        public static int GetGenderId(this string value)
        {
            if (value == null)
            {
                return 0;
            }

            return value.Trim() switch
            {
                "مرد" => 1,
                "زن" => 2,
                _ => 0
            };
        }
        public static List<DropDownModels> GenderList()
        {
            return new List<DropDownModels>()
            {
                new DropDownModels()
                {
                    Id = (int)Gender.Male,
                    Title = ((int)Gender.Male).GetGenderVal()
                },
                new DropDownModels()
                {
                    Id = (int)Gender.Female,
                    Title = ((int)Gender.Female).GetGenderVal()
                }
            };
        }
    }
}
