using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the Roles table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class RolesRepo : GenericRepository<Roles> , IGenericRepository<IRoles>
    {
		public RolesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IRoles Create()
        {
            return base.Create();
        }

		public new IRoles Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IRoles> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IRoles> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IRoles obj)
        {
            base.Insert((Roles)obj);
        }

        public void Insert(IEnumerable<IRoles> entities)
        {
			foreach (IRoles entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IRoles obj)
        {
            base.Update((Roles)obj);
        }

        public void Update(IEnumerable<IRoles> entities)
        {
			foreach (IRoles entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IRoles entity)
        {
            base.Delete((Roles)entity);
        }

        public void Delete(IEnumerable<IRoles> entities)
        {
			foreach (IRoles entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
