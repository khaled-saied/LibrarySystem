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
    }
}
