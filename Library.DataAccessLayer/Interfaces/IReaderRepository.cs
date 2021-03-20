using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public interface IReaderRepository
    {
        void AddReader(Reader reader);
        void DeleteReader(Reader reader);
        void EditReader(Reader reader, string lName, string fName, string mName, int ticketNum);
        DbSet<Reader> Readers();
    }
}
