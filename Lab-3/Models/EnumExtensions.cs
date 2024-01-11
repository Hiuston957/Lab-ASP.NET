
﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Laboratorium3.Models
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if (attrs != null)
                {
                    return attrs.GetName();
                }
            }

            // Zwraca wartość domyślną, jeśli nie znaleziono atrybutu Display
            return enumValue.ToString();
        }
    }
}