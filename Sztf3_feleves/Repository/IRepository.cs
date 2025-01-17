﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IRepository<T> where T: new() 
    {
        void Insert(T item);

        void Delete(string uid);

        IQueryable<T> Print();

        void Update(string oldid, T newitem);

        T GetOneObj(string uid);

        void Save();
    }
}
