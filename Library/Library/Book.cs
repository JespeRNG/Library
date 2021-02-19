using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } // Book name
        public string Authors { get; set; } // Authors of the book
        public string LibraryCode { get; set; } // Library code of the book
        public int PublicationYear { get; set; } // Year of publication
        public string PublicationPlace { get; set; } // Place of publication
        public string PublishingName { get; set; } // Name of publishing
        public int TotalAmount { get; set; } // Total amount of the book in library
        public int AvailableAmount { get; set; } // Available amount for readers
    }
}
