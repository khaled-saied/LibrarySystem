using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Extenstions
{
    public static class StringExtenstions
    {
        public static string Normalize(this string input)
        {
            return input?.Trim().ToUpperInvariant() ?? string.Empty;
        }

        public static bool ContainDigit(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                    return true;
            }
            return false;
        }

        public static bool IsValidEmail(this string input)
        {
            bool hasAt = false;
            bool hasDot = false;
            foreach (char c in input)
            {
                if (c == '.')
                    hasDot = true;
                else if (c == '@')
                    hasAt = true;
            }
            return hasAt && hasDot;
        }
    }
}
