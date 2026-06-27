using LibrarySystem.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibrarySystem.Models
{
    public class BorrowTransaction : IDisplayable
    {
        public BorrowTransaction( Memeber memeber, BookCopy bookCopy,int loanDay)
        {
            TransactionId = ++_transactionCounter;
            Memeber = memeber;
            BookCopy = bookCopy;
            BorrowDate = DateOnly.FromDateTime(DateTime.Now);
            DueDate = BorrowDate.AddDays(loanDay);
            ReturnDate = null;
        }

        private static int _transactionCounter = 1000;
        private const decimal FinePerDay = 10m;

        public int TransactionId { get; set; }
        public Memeber Memeber { get; set; }
        public BookCopy BookCopy { get; set; }
        public DateOnly BorrowDate { get; set; }
        public DateOnly DueDate { get; set; }
        public DateOnly? ReturnDate { get; set; }
        


        //IsReturned() : bool
        public bool IsReturned()
        {
            return ReturnDate.HasValue;
        }

        //+MarkReturned(date) : void
        public void MarkReturned(DateOnly returnDate)
        {
            ReturnDate = returnDate;
        }


        //+CalculateFine() : decimal
        public decimal CalculateFine()
        {
            DateOnly date = ReturnDate ?? DateOnly.FromDateTime(DateTime.Now);
            int overdueDays = (date.DayNumber - DueDate.DayNumber);
            return overdueDays > 0 ? overdueDays * FinePerDay : 0m;
        }

        public decimal CalculateFine(DateOnly returnDate)
        {
            int overdueDays = (returnDate.DayNumber - DueDate.DayNumber);
            return overdueDays > 0 ? overdueDays * FinePerDay : 0m;
        }


        public string ToDisplayString()
        {
            string status = ReturnDate.HasValue ? "Returned" : "Active";
            decimal fine = CalculateFine();
            string returnInfo = ReturnDate.HasValue ? $"Returned On: {ReturnDate.Value.ToString("dd/MM/yyyy")}" : $"Not Retunes Yet";
            string fineInfo = fine > 0 ? $" | Fine: {fine:f2}  EGP" : "None";

            return $@"── Transaction #{TransactionId} ──────────────
                      Book : {BookCopy.Book.Title}
                      Copy ID : {BookCopy.CopyId}
                      Borrowed : {BorrowDate.ToString("dd/MM/yyyy")}
                      Due : {DueDate.ToString("dd/MM/yyyy")}
                      Returned : {returnInfo}
                      Status : {status}
                      Fine : {fineInfo}";

        }
    }
}