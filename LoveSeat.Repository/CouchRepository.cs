﻿using System;

namespace LoveSeat.Repository
{
    public class CouchRepository<T> : IRepository<T> where T : IBaseObject
    {
        protected readonly CouchDatabase db = null;
        protected CouchRepository(CouchDatabase db)
        {
            this.db = db;
        }

        public virtual void Save(T item)
        {
            if (item.Id == Guid.Empty)
                item.Id = Guid.NewGuid();
            var doc = new Document<T>(item);
            db.SaveDocument(doc);
        }

        public virtual T Find(Guid id)
        {
            return db.GetDocument<T>(id.ToString());
        }

        /// <summary>
        /// Repository methods don't have the business validation.  Use the service methods to enforce.
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Delete(T obj)
        {
            db.DeleteDocument(obj.Id.ToString(), obj.Rev);
        }
    }
}