using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the CustomItemOptions table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class CustomItemOptionsRepo : GenericRepository<CustomItemOptions> , IGenericRepository<ICustomItemOptions>
    {
		public CustomItemOptionsRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new ICustomItemOptions Create()
        {
            return base.Create();
        }

		public new ICustomItemOptions Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<ICustomItemOptions> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<ICustomItemOptions> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(ICustomItemOptions obj)
        {
            base.Insert((CustomItemOptions)obj);
        }

        public void Insert(IEnumerable<ICustomItemOptions> entities)
        {
			foreach (ICustomItemOptions entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(ICustomItemOptions obj)
        {
            base.Update((CustomItemOptions)obj);
        }

        public void Update(IEnumerable<ICustomItemOptions> entities)
        {
			foreach (ICustomItemOptions entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(ICustomItemOptions entity)
        {
            base.Delete((CustomItemOptions)entity);
        }

        public void Delete(IEnumerable<ICustomItemOptions> entities)
        {
			foreach (ICustomItemOptions entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
