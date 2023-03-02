using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the SystemKeys table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class SystemKeysRepo : GenericRepository<SystemKeys> , IGenericRepository<ISystemKeys>
    {
		public SystemKeysRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new ISystemKeys Create()
        {
            return base.Create();
        }

		public new ISystemKeys Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<ISystemKeys> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<ISystemKeys> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(ISystemKeys obj)
        {
            base.Insert((SystemKeys)obj);
        }

        public void Insert(IEnumerable<ISystemKeys> entities)
        {
			foreach (ISystemKeys entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(ISystemKeys obj)
        {
            base.Update((SystemKeys)obj);
        }

        public void Update(IEnumerable<ISystemKeys> entities)
        {
			foreach (ISystemKeys entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(ISystemKeys entity)
        {
            base.Delete((SystemKeys)entity);
        }

        public void Delete(IEnumerable<ISystemKeys> entities)
        {
			foreach (ISystemKeys entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
