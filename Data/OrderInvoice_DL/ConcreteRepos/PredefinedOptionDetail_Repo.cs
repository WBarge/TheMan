using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the PredefinedOptionDetail table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class PredefinedOptionDetailRepo : GenericRepository<PredefinedOptionDetail> , IGenericRepository<IPredefinedOptionDetail>
    {
		public PredefinedOptionDetailRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IPredefinedOptionDetail Create()
        {
            return base.Create();
        }

		public new IPredefinedOptionDetail Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IPredefinedOptionDetail> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IPredefinedOptionDetail> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IPredefinedOptionDetail obj)
        {
            base.Insert((PredefinedOptionDetail)obj);
        }

        public void Insert(IEnumerable<IPredefinedOptionDetail> entities)
        {
			foreach (IPredefinedOptionDetail entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IPredefinedOptionDetail obj)
        {
            base.Update((PredefinedOptionDetail)obj);
        }

        public void Update(IEnumerable<IPredefinedOptionDetail> entities)
        {
			foreach (IPredefinedOptionDetail entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IPredefinedOptionDetail entity)
        {
            base.Delete((PredefinedOptionDetail)entity);
        }

        public void Delete(IEnumerable<IPredefinedOptionDetail> entities)
        {
			foreach (IPredefinedOptionDetail entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
