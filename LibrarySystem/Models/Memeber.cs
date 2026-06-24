using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Memeber : LibraryUser
    {
        private static int _counter = 0;

        public string MemberShipId { get; set; } = string.Empty;
        public DateOnly? DateOfBarth { get; set; }
        public string? Email { get; set; }
        public DateOnly MemberShipDate { get; set; }

        private readonly List<BorrowTransaction> _transactions = new ();
        public IReadOnlyList<BorrowTransaction> Transactions => _transactions;


        public Memeber(string name, string phone, DateOnly? dateOfBarth, string? email, DateOnly memberShipDate) : base(name, phone)
        {
            MemberShipId = $"MEM-{_counter++:D3}";
            DateOfBarth = dateOfBarth;
            Email = email;
            MemberShipDate = memberShipDate;
        }

        public Memeber(string name, string phone) : this(name,phone,null, null,DateOnly.FromDateTime(DateTime.Now))
        {
        }


        //Add Transaction(BorrowTransaction)
        public void AddTransaction(BorrowTransaction transaction)
        {
            _transactions.Add(transaction);
        }

        //Get History of Transactions()
        public string GetHistoryDisplayString()
        {
            if(Transactions.Count==0)
                return "No borrowing history found.";
            StringBuilder result = new();
            for (int i = 0; i < Transactions.Count; i++)
            {
                result.Append( Transactions[i].ToDisplayString());
            }
            return result.ToString();
        }


        public override string ToDisplayString()
        {
            return $@"ID : {MemberShipId}
                    Name : {Name} 
                    Phone : {Phone}
                    Date of Birth : {(DateOfBarth.HasValue ? DateOfBarth.Value.ToString("dd/MM/yyyy") : "N/A")}
                    Email : {(string.IsNullOrEmpty(Email) ? "N/A" : Email)}
                    Joined : {MemberShipDate:dd/MM/yyyy}
                    Borrows : {Transactions.Count}";
        }
    }
}
