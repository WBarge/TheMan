using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the Customers table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class CustomersRepo : GenericRepository<Customers> , IGenericRepository<ICustomers>
    {
		public CustomersRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new ICustomers Create()
        {
            return base.Create();
        }

		public new ICustomers Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<ICustomers> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<ICustomers> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(ICustomers obj)
        {
            base.Insert((Customers)obj);
        }

        public void Insert(IEnumerable<ICustomers> entities)
        {
			foreach (ICustomers entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(ICustomers obj)
        {
            base.Update((Customers)obj);
        }

        public void Update(IEnumerable<ICustomers> entities)
        {
			foreach (ICustomers entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(ICustomers entity)
        {
            base.Delete((Customers)entity);
        }

        public void Delete(IEnumerable<ICustomers> entities)
        {
			foreach (ICustomers entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
