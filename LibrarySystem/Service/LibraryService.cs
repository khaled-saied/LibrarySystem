using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTheme;
using LibrarySystem.Extenstions;
using LibrarySystem.Models;

namespace LibrarySystem.Service
{
    public class LibraryService
    {
        private readonly LibraryBranch _branch;
        private readonly DisplayService _display;

        public LibraryService(LibraryBranch branch , DisplayService display)
        {
            this._branch = branch;
            this._display = display;
        }

        //HandleBorrow() Void
        public void HandleBorrow()
        {
            var memberShipId = ThemeHelper.Prompt("Enter Member ID:").Normalize();
            var member = _branch.FindMember(memberShipId);
            _display.ShowAllAvailableCopies(_branch);

            string copyId = ThemeHelper.Prompt("Enter Copy ID to borrow:").Normalize();
            var copy = _branch.FindCopy(copyId);
            copy!.Borrow(member!);
            _display.ShowBorrowSuccess(copy, member!);
        }

        //HandleReturn() Void
        public void HandleReturn()
        {
            var copyId = ThemeHelper.Prompt("Enter Copy ID:").Normalize();
            var bookCopy = _branch.FindCopy(copyId);

            var fine = bookCopy!.Return();
            _display.ShowReturnSuccess(bookCopy, fine);
        }

        //HandleHistory() Void
        public void HandleHistory()
        {
            var memberShipId = ThemeHelper.Prompt("Enter Member ID:").Normalize();
            var member = _branch.FindMember(memberShipId);
            _display.ShowMemberHistory(member!);
        }

        //HandleRegisterMember() Void
        public void HandleRegisterMember()
        {
            var name = ThemeHelper.Prompt("Enter Member Name:");
            var phone = ThemeHelper.Prompt("Enter Member Phone:");
            if (!phone.ContainDigit())
                throw new InvalidOperationException("Phone number must contain at least one digit.");
            var email = ThemeHelper.Prompt("Enter Email Address:");
            if (!email.IsValidEmail())
                throw new InvalidOperationException("Invalid email format. Must contain '@' and '.'.");

            var member = _branch.RegisterMember(name, phone, null, email, DateOnly.FromDateTime(DateTime.Today));
            _display.ShowRegistrationSuccess(member);
        }

    }
}
