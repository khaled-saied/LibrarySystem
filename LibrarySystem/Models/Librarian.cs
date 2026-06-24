using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Librarian : LibraryUser
    {
        public string LibrarianId { get; set; } = string.Empty;
        public decimal Salary { get; set; } 
        public DateOnly HireDate { get; set; }



        public Librarian(string name, string phone, decimal salary, DateOnly hireDate, string librarianId) : base(name, phone)
        {
            Salary = salary;
            HireDate = hireDate;
            LibrarianId = librarianId;
        }

        public override string ToDisplayString()
        {
            return $@"ID : {LibrarianId}
                    Name : {Name} 
                    Phone : {Phone}
                    Salary : {Salary:c}
                    Hired : {HireDate:dd/MM/yyy}";
        }
    }
}
