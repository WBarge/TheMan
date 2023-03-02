using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the OrderItem table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class OrderItemRepo : GenericRepository<OrderItem> , IGenericRepository<IOrderItem>
    {
		public OrderItemRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IOrderItem Create()
        {
            return base.Create();
        }

		public new IOrderItem Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IOrderItem> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IOrderItem> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IOrderItem obj)
        {
            base.Insert((OrderItem)obj);
        }

        public void Insert(IEnumerable<IOrderItem> entities)
        {
			foreach (IOrderItem entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IOrderItem obj)
        {
            base.Update((OrderItem)obj);
        }

        public void Update(IEnumerable<IOrderItem> entities)
        {
			foreach (IOrderItem entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IOrderItem entity)
        {
            base.Delete((OrderItem)entity);
        }

        public void Delete(IEnumerable<IOrderItem> entities)
        {
			foreach (IOrderItem entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
