using ConsoleTheme;
using LibrarySystem.Models;

namespace LibrarySystem.Service
{
    public class DisplayService
    {
        //ShowBranchInfo(LibraryBranch branch)  void
        public void ShowBranchInfo(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("LIBRARY BRANCH INFO");
            Console.WriteLine(branch.ToDisplayString());
        }

        //ShowAllUsers(LibraryBranch branch) void
        public void ShowAllUsers(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Registered Users");
            foreach(var user in branch.User)
            {
                var header = user is Memeber ? "LIBRARIAN PROFILE" : "MEMBER PROFILE ";
                ThemeHelper.PrintSectionTitle(header);
                Console.WriteLine(user.ToDisplayString());
            }
        }

        //ShowAllAvailableCopies(LibraryBranch branch) void
        public void ShowAllAvailableCopies(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("Available Book Copies:");
            var availableCopies = branch.GetAvailableCopies();
            if (availableCopies.Count == 0)
            {
                ThemeHelper.Prompt("No available copies at the moment.");
                return;
            }
            foreach (var c in availableCopies)
            {
                Console.WriteLine(c.ToDisplayString());
            }
        }

        //ShowAllCopies(LibraryBranch branch) void
        public void ShowAllCopies(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Book Copies:");
            if (branch.Copies.Count == 0)
            {
                ThemeHelper.PrintWarning("No book copies found.");
                return;
            }
            foreach(var c in branch.Copies)
            {
                Console.WriteLine(c.ToDisplayString());
            }
        }

        //ShowMemberHistory(Member member) void
        public void ShowMemberHistory(Memeber member)
        {
            ThemeHelper.PrintSectionTitle($"Borrowing History for {member.Name} ");
            Console.WriteLine(member.GetHistoryDisplayString());
        }

        //ShowBorrowSuccess(BookCopy copy , Member member) void
        public void ShowBorrowSuccess(BookCopy copy, Memeber member)
        {
            ThemeHelper.PrintSuccess($"Copy [{copy.CopyId}] \"{copy.Book.Title}\" borrowed by {member.Name}.");
            ThemeHelper.PrintSuccess($"Due date: {copy.ActiveTransaction!.DueDate:dd/MM/YYYY}");
        }

        //ShowReturnSuccess(BookCopy copy, decimal fine) void
        public void ShowReturnSuccess(BookCopy copy, decimal fine)
        {
            ThemeHelper.PrintSuccess($"Copy [{copy.CopyId}]: {copy.Book.Title} returned.");
            if (fine > 0)
                ThemeHelper.PrintWarning($"Late return fine: ${fine:F2} EGP");
            else
                ThemeHelper.PrintSuccess("Returned on time. No fine.");
        }

        //ShowRegistrationSuccess(Member member) void
        public void ShowRegistrationSuccess(Memeber member)
        {
            ThemeHelper.PrintSuccess($"Member: {member.Name} - [{member.MemberShipId}] registered.");
        }

        //ShowAddCopySuccess(BookCopy copy) void
        public void ShowAddCopySuccess(BookCopy copy)
        {
            ThemeHelper.PrintSuccess($"Book Copy [{copy.CopyId}] - \"{copy.Book.Title}\" added to the library.");
        }

    }
}
