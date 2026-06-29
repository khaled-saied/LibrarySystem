using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;

namespace LibrarySystem.Helper
{
    public class DataSeedind
    {
        public static LibraryBranch Seed()
        {
            // Librarians
            var librarian1 = new Librarian(
                name: "Alice Johnson",
                phone: "555-1234",
                librarianId: "LIB001",
                salary: 50000m,
                hireDate: new DateOnly(2020, 1, 15)
            );
            var librarian2 = new Librarian(
                name: "Bob Smith",
                phone: "555-2345",
                librarianId: "LIB002",
                salary: 48000m,
                hireDate: new DateOnly(2021, 3, 10)
            );

            // Branch (managed by librarian1)
            var branch = new LibraryBranch(
                branchId: "BR001",
                branchName: "Central Library",
                address: "123 Main St",
                phone: "555-5678",
                openingHours: "9am - 5pm",
                manager: librarian1
            );

            // Books
            var book1 = new Book(
                iSBN: "978-3-16-148410-0",
                title: "C# in Depth",
                autherName: "Jon Skeet",
                category: "Programming",
                publicationYear: 2019
            );
            var book2 = new Book(
                iSBN: "978-0-13-110362-7",
                title: "The C Programming Language",
                autherName: "Kernighan & Ritchie",
                category: "Programming",
                publicationYear: 1988
            );
            var book3 = new Book(
                iSBN: "978-1-491-92428-6",
                title: "Fluent Python",
                autherName: "Luciano Ramalho",
                category: "Programming",
                publicationYear: 2015
            );

            // BookCopies
            var copy1 = new BookCopy("CPY001", book1, "New");
            var copy2 = new BookCopy("CPY002", book1, "Good");
            var copy3 = new BookCopy("CPY003", book2, "Fair");
            var copy4 = new BookCopy("CPY004", book3, "New");

            // Add BookCopies to Branch
            branch.AddBookCopy(copy1);
            branch.AddBookCopy(copy2);
            branch.AddBookCopy(copy3);
            branch.AddBookCopy(copy4);

            // Register Members
            branch.RegisterMember("Charlie Brown", "555-3456");
            branch.RegisterMember("Diana Prince", "555-4567");
            branch.RegisterMember("Eve Adams", "555-5679");

            return branch;
        }
    }
}
