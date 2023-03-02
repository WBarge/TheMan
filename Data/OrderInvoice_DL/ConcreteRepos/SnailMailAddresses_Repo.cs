using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the SnailMailAddresses table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class SnailMailAddressesRepo : GenericRepository<SnailMailAddresses> , IGenericRepository<ISnailMailAddresses>
    {
		public SnailMailAddressesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new ISnailMailAddresses Create()
        {
            return base.Create();
        }

		public new ISnailMailAddresses Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<ISnailMailAddresses> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<ISnailMailAddresses> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(ISnailMailAddresses obj)
        {
            base.Insert((SnailMailAddresses)obj);
        }

        public void Insert(IEnumerable<ISnailMailAddresses> entities)
        {
			foreach (ISnailMailAddresses entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(ISnailMailAddresses obj)
        {
            base.Update((SnailMailAddresses)obj);
        }

        public void Update(IEnumerable<ISnailMailAddresses> entities)
        {
			foreach (ISnailMailAddresses entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(ISnailMailAddresses entity)
        {
            base.Delete((SnailMailAddresses)entity);
        }

        public void Delete(IEnumerable<ISnailMailAddresses> entities)
        {
			foreach (ISnailMailAddresses entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
