using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the PredefinedOptions table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class PredefinedOptionsRepo : GenericRepository<PredefinedOptions> , IGenericRepository<IPredefinedOptions>
    {
		public PredefinedOptionsRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IPredefinedOptions Create()
        {
            return base.Create();
        }

		public new IPredefinedOptions Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IPredefinedOptions> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IPredefinedOptions> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IPredefinedOptions obj)
        {
            base.Insert((PredefinedOptions)obj);
        }

        public void Insert(IEnumerable<IPredefinedOptions> entities)
        {
			foreach (IPredefinedOptions entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IPredefinedOptions obj)
        {
            base.Update((PredefinedOptions)obj);
        }

        public void Update(IEnumerable<IPredefinedOptions> entities)
        {
			foreach (IPredefinedOptions entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IPredefinedOptions entity)
        {
            base.Delete((PredefinedOptions)entity);
        }

        public void Delete(IEnumerable<IPredefinedOptions> entities)
        {
			foreach (IPredefinedOptions entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
