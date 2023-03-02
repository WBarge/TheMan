using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the Products table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class ProductsRepo : GenericRepository<Products> , IGenericRepository<IProducts>
    {
		public ProductsRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IProducts Create()
        {
            return base.Create();
        }

		public new IProducts Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IProducts> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IProducts> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IProducts obj)
        {
            base.Insert((Products)obj);
        }

        public void Insert(IEnumerable<IProducts> entities)
        {
			foreach (IProducts entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IProducts obj)
        {
            base.Update((Products)obj);
        }

        public void Update(IEnumerable<IProducts> entities)
        {
			foreach (IProducts entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IProducts entity)
        {
            base.Delete((Products)entity);
        }

        public void Delete(IEnumerable<IProducts> entities)
        {
			foreach (IProducts entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
