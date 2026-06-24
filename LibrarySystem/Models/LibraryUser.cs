using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Contracts;

namespace LibrarySystem.Models
{
    public abstract class LibraryUser : IDisplayable
    {
        protected LibraryUser(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public abstract string ToDisplayString();

    }
}
