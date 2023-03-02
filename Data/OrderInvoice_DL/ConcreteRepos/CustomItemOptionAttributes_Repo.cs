using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the CustomItemOptionAttributes table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class CustomItemOptionAttributesRepo : GenericRepository<CustomItemOptionAttributes> , IGenericRepository<ICustomItemOptionAttributes>
    {
		public CustomItemOptionAttributesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new ICustomItemOptionAttributes Create()
        {
            return base.Create();
        }

		public new ICustomItemOptionAttributes Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<ICustomItemOptionAttributes> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<ICustomItemOptionAttributes> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(ICustomItemOptionAttributes obj)
        {
            base.Insert((CustomItemOptionAttributes)obj);
        }

        public void Insert(IEnumerable<ICustomItemOptionAttributes> entities)
        {
			foreach (ICustomItemOptionAttributes entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(ICustomItemOptionAttributes obj)
        {
            base.Update((CustomItemOptionAttributes)obj);
        }

        public void Update(IEnumerable<ICustomItemOptionAttributes> entities)
        {
			foreach (ICustomItemOptionAttributes entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(ICustomItemOptionAttributes entity)
        {
            base.Delete((CustomItemOptionAttributes)entity);
        }

        public void Delete(IEnumerable<ICustomItemOptionAttributes> entities)
        {
			foreach (ICustomItemOptionAttributes entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
