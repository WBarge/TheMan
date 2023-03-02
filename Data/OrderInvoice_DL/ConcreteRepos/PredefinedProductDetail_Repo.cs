using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the PredefinedProductDetail table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class PredefinedProductDetailRepo : GenericRepository<PredefinedProductDetail> , IGenericRepository<IPredefinedProductDetail>
    {
		public PredefinedProductDetailRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IPredefinedProductDetail Create()
        {
            return base.Create();
        }

		public new IPredefinedProductDetail Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IPredefinedProductDetail> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IPredefinedProductDetail> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IPredefinedProductDetail obj)
        {
            base.Insert((PredefinedProductDetail)obj);
        }

        public void Insert(IEnumerable<IPredefinedProductDetail> entities)
        {
			foreach (IPredefinedProductDetail entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IPredefinedProductDetail obj)
        {
            base.Update((PredefinedProductDetail)obj);
        }

        public void Update(IEnumerable<IPredefinedProductDetail> entities)
        {
			foreach (IPredefinedProductDetail entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IPredefinedProductDetail entity)
        {
            base.Delete((PredefinedProductDetail)entity);
        }

        public void Delete(IEnumerable<IPredefinedProductDetail> entities)
        {
			foreach (IPredefinedProductDetail entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
