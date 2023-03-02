using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the OrderInvoice table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class OrderInvoiceRepo : GenericRepository<OrderInvoice> , IGenericRepository<IOrderInvoice>
    {
		public OrderInvoiceRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IOrderInvoice Create()
        {
            return base.Create();
        }

		public new IOrderInvoice Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IOrderInvoice> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IOrderInvoice> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IOrderInvoice obj)
        {
            base.Insert((OrderInvoice)obj);
        }

        public void Insert(IEnumerable<IOrderInvoice> entities)
        {
			foreach (IOrderInvoice entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IOrderInvoice obj)
        {
            base.Update((OrderInvoice)obj);
        }

        public void Update(IEnumerable<IOrderInvoice> entities)
        {
			foreach (IOrderInvoice entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IOrderInvoice entity)
        {
            base.Delete((OrderInvoice)entity);
        }

        public void Delete(IEnumerable<IOrderInvoice> entities)
        {
			foreach (IOrderInvoice entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
