using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the ProductAttributeValues table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class ProductAttributeValuesRepo : GenericRepository<ProductAttributeValues> , IGenericRepository<IProductAttributeValues>
    {
		public ProductAttributeValuesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IProductAttributeValues Create()
        {
            return base.Create();
        }

		public new IProductAttributeValues Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IProductAttributeValues> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IProductAttributeValues> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IProductAttributeValues obj)
        {
            base.Insert((ProductAttributeValues)obj);
        }

        public void Insert(IEnumerable<IProductAttributeValues> entities)
        {
			foreach (IProductAttributeValues entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IProductAttributeValues obj)
        {
            base.Update((ProductAttributeValues)obj);
        }

        public void Update(IEnumerable<IProductAttributeValues> entities)
        {
			foreach (IProductAttributeValues entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IProductAttributeValues entity)
        {
            base.Delete((ProductAttributeValues)entity);
        }

        public void Delete(IEnumerable<IProductAttributeValues> entities)
        {
			foreach (IProductAttributeValues entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
