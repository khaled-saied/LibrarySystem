using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Contracts;

namespace LibrarySystem.Models
{
    public class Book : IDisplayable
    {
        public Book(string iSBN, string title, string autherName, string category, int publicationYear)
        {
            ISBN = iSBN;
            Title = title;
            AuthorName = autherName;
            Category = category;
            PublicationYear = publicationYear;
        }
        public Book(string iSBN, string title):this(iSBN,title,"UnKnown","General",0)
        {
        }

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Category {  get; set; }
        public int PublicationYear { get; set; }


        public string ToDisplayString()
        {
            return $@"ISBN : {ISBN}
                    Title : {Title} 
                    Author : {AuthorName}
                    Category : {Category}
                    Publication Year : {(PublicationYear > 0 ? PublicationYear.ToString() : "N/A")}";
        }
    }
}
