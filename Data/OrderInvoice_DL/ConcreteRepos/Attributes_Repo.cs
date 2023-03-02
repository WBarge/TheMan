using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the Attributes table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class AttributesRepo : GenericRepository<Attributes> , IGenericRepository<IAttributes>
    {
		public AttributesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IAttributes Create()
        {
            return base.Create();
        }

		public new IAttributes Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IAttributes> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IAttributes> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IAttributes obj)
        {
            base.Insert((Attributes)obj);
        }

        public void Insert(IEnumerable<IAttributes> entities)
        {
			foreach (IAttributes entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IAttributes obj)
        {
            base.Update((Attributes)obj);
        }

        public void Update(IEnumerable<IAttributes> entities)
        {
			foreach (IAttributes entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IAttributes entity)
        {
            base.Delete((Attributes)entity);
        }

        public void Delete(IEnumerable<IAttributes> entities)
        {
			foreach (IAttributes entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
