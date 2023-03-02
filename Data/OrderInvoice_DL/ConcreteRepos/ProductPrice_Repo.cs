using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the ProductPrice table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class ProductPriceRepo : GenericRepository<ProductPrice> , IGenericRepository<IProductPrice>
    {
		public ProductPriceRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IProductPrice Create()
        {
            return base.Create();
        }

		public new IProductPrice Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IProductPrice> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IProductPrice> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IProductPrice obj)
        {
            base.Insert((ProductPrice)obj);
        }

        public void Insert(IEnumerable<IProductPrice> entities)
        {
			foreach (IProductPrice entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IProductPrice obj)
        {
            base.Update((ProductPrice)obj);
        }

        public void Update(IEnumerable<IProductPrice> entities)
        {
			foreach (IProductPrice entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IProductPrice entity)
        {
            base.Delete((ProductPrice)entity);
        }

        public void Delete(IEnumerable<IProductPrice> entities)
        {
			foreach (IProductPrice entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
