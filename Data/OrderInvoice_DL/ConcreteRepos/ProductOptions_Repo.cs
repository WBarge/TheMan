using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the ProductOptions table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class ProductOptionsRepo : GenericRepository<ProductOptions> , IGenericRepository<IProductOptions>
    {
		public ProductOptionsRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IProductOptions Create()
        {
            return base.Create();
        }

		public new IProductOptions Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IProductOptions> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IProductOptions> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IProductOptions obj)
        {
            base.Insert((ProductOptions)obj);
        }

        public void Insert(IEnumerable<IProductOptions> entities)
        {
			foreach (IProductOptions entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IProductOptions obj)
        {
            base.Update((ProductOptions)obj);
        }

        public void Update(IEnumerable<IProductOptions> entities)
        {
			foreach (IProductOptions entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IProductOptions entity)
        {
            base.Delete((ProductOptions)entity);
        }

        public void Delete(IEnumerable<IProductOptions> entities)
        {
			foreach (IProductOptions entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
