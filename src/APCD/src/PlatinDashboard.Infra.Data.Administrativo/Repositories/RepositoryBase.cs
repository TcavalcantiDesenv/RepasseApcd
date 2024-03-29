﻿using PlatinDashboard.Domain.Administrativo.Interfaces.Repositories;
using PlatinDashboard.Infra.Data.Administrativo.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PlatinDashboard.Infra.Data.Administrativo.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected AdministrativoContext Db = new AdministrativoContext();
        public virtual TEntity Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
            return obj;
        }

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual TEntity Update(TEntity obj)
        {
            Db.Set<TEntity>().Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
            return obj;
        }

        public virtual void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
