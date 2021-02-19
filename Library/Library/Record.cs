using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Record
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfIssue { get; set; } // Date when the book was given to a reader
        public DateTime DateOfReturn { get; set; } // Date when the book should be returned
        public bool Returned { get; set; } // Is the book returned?
    }
}
