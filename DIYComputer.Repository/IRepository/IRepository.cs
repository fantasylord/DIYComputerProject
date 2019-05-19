﻿using DIYComputer.Entity.SysEntity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DIYComputer.Repository.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
