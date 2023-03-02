using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;
using OrderInvoice_Interfaces;

namespace OrderInvoice_DL
{
    internal class GenericRepository<T> where T : class
    {
        protected IConnectionFactory conFact;
        internal Queue<QueueItem> queueForAllRepositories;
        readonly IPrimaryKeyRetriever _primaryKeyRetriever;

        public GenericRepository(IConnectionFactory conFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever)
        {
            if (conFactory == null) { throw new ArgumentException("connection factory is mandatory"); }
            if (conFact == null) { conFact = conFactory; }
            if (queueForAllRepositories == null) { queueForAllRepositories = queue; }
			if (primaryKeyRetriever!= null) {this._primaryKeyRetriever = primaryKeyRetriever;}
        }

        internal virtual T Create()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        internal virtual T Get(int id)
        {
            using (var cn = conFact.GetConnection())
            {
                return cn.Get<T>(id);
            }
        }

        internal virtual IQueryable<T> GetAll()
        {
            using (var cn = conFact.GetConnection())
            {
                return cn.GetList<T>().AsQueryable();
            }
        }

        internal virtual IEnumerable<T> GetPaged(int pageNumber, int itemPerPage, string conditions, string order)
        {
            using (var cn = conFact.GetConnection())
            {
                return cn.GetListPaged<T>(pageNumber, itemPerPage, conditions, order);
            }
        }

        internal virtual void Insert(T obj)
        {
			if (this._primaryKeyRetriever != null)
			{
				PropertyInfo keyProp = null;
				foreach (PropertyInfo prop in typeof(T).GetProperties())
				{
					IEnumerable<Attribute> att = prop.GetCustomAttributes(typeof(KeyAttribute));
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    if (att != null && prop.PropertyType.Name == nameof(Int32))
					{
						keyProp = prop;
						break;
					}
				}
				if (keyProp != null && (keyProp.GetValue(obj) == null || ((int)keyProp.GetValue(obj)) == 0 ))
				{
					int newKeyValue = this._primaryKeyRetriever.GetNextPrimaryKey(obj);
					keyProp.SetValue(obj, newKeyValue);
				}
			}
            InsertInQueue(obj, TypeOfWork.Insert);
        }

        internal virtual void Insert(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Insert(entity);
            }
        }

        internal virtual void Update(T obj)
        {
            InsertInQueue(obj, TypeOfWork.Update);
        }

        internal virtual void Update(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Update(entity);
            }
        }

        internal virtual void Delete(T entity)
        {
            InsertInQueue(entity, TypeOfWork.Delete);
        }

        internal virtual void Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                this.Delete(entity);
            }
        }

        internal void InsertInQueue (T obj, TypeOfWork whatToDo)
        {
            QueueItem itemToInsert = new QueueItem()
            {
                ItemToWorkOn = obj,
                WorkType = whatToDo
            };
            queueForAllRepositories.Enqueue(itemToInsert);
        }
    }
}
