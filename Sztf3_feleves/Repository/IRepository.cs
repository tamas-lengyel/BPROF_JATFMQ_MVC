using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    interface IRepository<T> where T: new() 
    {
        void Insert(T item);

        void Delete(T item);

        void Delete(string uid);

        T FindItem(string uid);

        IQueryable<T> Print();

        void Update(string oldid, T newitem);

        void SaveDb();
    }
}
