using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer
{
    public interface IDbRepository
    {
        void EditReader(Reader reader, string lName, string fName, string mName, int ticketNum);
        void DeleteReader(int id);
        void AddRecord(int readerId, int bookId, string date);
        void AddReader(string firstName, string lastName, string middleName, string ticketNumber);
    }
}
