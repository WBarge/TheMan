using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the PredefinedProducts table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class PredefinedProductsRepo : GenericRepository<PredefinedProducts> , IGenericRepository<IPredefinedProducts>
    {
		public PredefinedProductsRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IPredefinedProducts Create()
        {
            return base.Create();
        }

		public new IPredefinedProducts Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IPredefinedProducts> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IPredefinedProducts> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IPredefinedProducts obj)
        {
            base.Insert((PredefinedProducts)obj);
        }

        public void Insert(IEnumerable<IPredefinedProducts> entities)
        {
			foreach (IPredefinedProducts entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IPredefinedProducts obj)
        {
            base.Update((PredefinedProducts)obj);
        }

        public void Update(IEnumerable<IPredefinedProducts> entities)
        {
			foreach (IPredefinedProducts entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IPredefinedProducts entity)
        {
            base.Delete((PredefinedProducts)entity);
        }

        public void Delete(IEnumerable<IPredefinedProducts> entities)
        {
			foreach (IPredefinedProducts entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
