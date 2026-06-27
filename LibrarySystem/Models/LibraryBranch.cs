using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Contracts;
using LibrarySystem.Extenstions;

namespace LibrarySystem.Models
{
    public class LibraryBranch : IDisplayable
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OpenningHours { get; set; }
        public Librarian Manager { get; set; }

        private readonly List<Memeber> _memebers = new();
        private readonly List<BookCopy> _copies = new();

        public LibraryBranch(string branchId, string branchName, string address, string phone, string openingHours, Librarian manager)
        {
            BranchId = branchId;
            BranchName = branchName;
            Address = address;
            Phone = phone;
            OpenningHours = openingHours;
            Manager = manager;
        }

        public IReadOnlyList<Memeber> Members => _memebers;
        public IReadOnlyList<BookCopy> Copies => _copies;
        public IReadOnlyList<LibraryUser> User
        {
            get
            {
                List<LibraryUser> users = new();
                users.AddRange(_memebers);
                users.Add(Manager);
                return users;
            }
        }


        #region Methods
        //+RegisterMember() : Member
        public Memeber RegisterMember(string name, string phone)
        {
            Memeber member = new(name, phone);
            _memebers.Add(member);
            return member;
        }
        public Memeber RegisterMember(string name, string phone, DateOnly? dateOfBarth, string? email, DateOnly memberShipDate)
        {
            var member = new Memeber(name, phone, dateOfBarth, email, memberShipDate);
            _memebers.Add(member);
            return member;
        }


        //+FindMember(id) : Member
        public Memeber? FindMember(string memberShipId)
        {
            string normalizedId = memberShipId.Normalize();
            for (int i = 0; i < _memebers.Count; i++)
            {
                if (_memebers[i].MemberShipId == normalizedId)
                    return _memebers[i];
            }
            throw new KeyNotFoundException($"Member with ID {memberShipId} not found.");
        }

        //+FindCopy(id) : BookCopy
        public BookCopy? FindCopy(string copyId)
        {
            string normalizedId = copyId.Normalize();
            for (int i = 0; i < _copies.Count; i++)
            {
                if (_copies[i].CopyId == normalizedId)
                    return _copies[i];
            }
            throw new KeyNotFoundException($"Copy with ID {copyId} not found.");
        }

        //+AddBookCopy(copy) : void
        public void AddBookCopy(BookCopy copy)
        {
            _copies.Add(copy);
        }


        //+GetAvailableCopies() : List
        public List<BookCopy> GetAvailableCopies()
        {
            var availableCopies = new List<BookCopy>();
            for (int i = 0; i < _copies.Count; i++)
            {
                if (_copies[i].IsAvailable())
                    availableCopies.Add(_copies[i]);
            }
            return availableCopies;
        }

        public string ToDisplayString()
        {
            return $@"ID : {BranchId}
                     Name : {BranchName}
                     Address : {Address}
                     Phone : {Phone}
                     Opening Hours : {OpenningHours}
                     Manager : {Manager.Name}
                     Total Members : {_memebers.Count}
                     Total Book Copies : {_copies.Count}";
        } 
        #endregion

    }
}
