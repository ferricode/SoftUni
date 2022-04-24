﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        int SaveChanges();
        IQueryable<T> All<T>() where T : class;
    }
}
