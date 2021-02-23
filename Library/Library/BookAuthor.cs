using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookAuthor
    {
        [Key]
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}