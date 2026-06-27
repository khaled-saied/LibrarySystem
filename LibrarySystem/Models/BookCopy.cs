using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Contracts;
using LibrarySystem.Models.Enums;

namespace LibrarySystem.Models
{
    public class BookCopy : IDisplayable
    {
        public BookCopy(string copyId, Book book, string condition="Good")
        {
            CopyId = copyId;
            Condition = condition;
            Status = CopyStatus.Available;
            Book = book;
            ActiveTransaction = null;
        }

        public string CopyId { get; set; }
        public string Condition { get; set; }
        public CopyStatus Status { get; set; }
        public Book Book { get; set; }
        public BorrowTransaction? ActiveTransaction { get; set; }



        //+IsAvailable() : bool
        public bool IsAvailable()
        {
            return Status == CopyStatus.Available;
        }


        //+Borrow(member, loanDays) : void
        //TO DO
        public void Borrow(Memeber memeber ,int loanDays)
        {
            if(!IsAvailable())
                throw new InvalidOperationException($"Copy {CopyId} is not available (Status: {Status}).");

            Status = CopyStatus.Borrowed;
            ActiveTransaction = new(); //TO Do
            memeber.AddTransaction(ActiveTransaction);
        }

        //+Return() : decimal
        //TO DO
        public decimal Return()
        {
            if(ActiveTransaction == null)
                throw new InvalidOperationException($"No active transaction for this copy.");
            if(Status != CopyStatus.Borrowed)
                throw new InvalidOperationException($"Copy {CopyId} is not currently borrowed.");

            //TO Do To Cala The Fine



            return 0;
        }


        public string ToDisplayString()
        {
            return $@"Copy [{CopyId}] - {Book.Title} | Condition: {Condition} | {Status.ToString()}";
        }
    }
}
