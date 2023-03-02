using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the CustomItemAttributes table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class CustomItemAttributesRepo : GenericRepository<CustomItemAttributes> , IGenericRepository<ICustomItemAttributes>
    {
		public CustomItemAttributesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new ICustomItemAttributes Create()
        {
            return base.Create();
        }

		public new ICustomItemAttributes Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<ICustomItemAttributes> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<ICustomItemAttributes> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(ICustomItemAttributes obj)
        {
            base.Insert((CustomItemAttributes)obj);
        }

        public void Insert(IEnumerable<ICustomItemAttributes> entities)
        {
			foreach (ICustomItemAttributes entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(ICustomItemAttributes obj)
        {
            base.Update((CustomItemAttributes)obj);
        }

        public void Update(IEnumerable<ICustomItemAttributes> entities)
        {
			foreach (ICustomItemAttributes entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(ICustomItemAttributes entity)
        {
            base.Delete((CustomItemAttributes)entity);
        }

        public void Delete(IEnumerable<ICustomItemAttributes> entities)
        {
			foreach (ICustomItemAttributes entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
