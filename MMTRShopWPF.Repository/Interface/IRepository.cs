﻿using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MMTRShopWPF.Repository.Interface
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Save();
    }
}
