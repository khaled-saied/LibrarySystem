using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.Contracts
{
    public interface IBorrowable
    {
        void Borrow(Memeber member, int loanDays = 14);
        decimal Return();
        bool IsAvailable();
    }
}
