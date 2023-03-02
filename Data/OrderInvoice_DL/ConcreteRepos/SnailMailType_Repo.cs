using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the SnailMailType table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class SnailMailTypeRepo : GenericRepository<SnailMailType> , IGenericRepository<ISnailMailType>
    {
		public SnailMailTypeRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new ISnailMailType Create()
        {
            return base.Create();
        }

		public new ISnailMailType Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<ISnailMailType> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<ISnailMailType> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(ISnailMailType obj)
        {
            base.Insert((SnailMailType)obj);
        }

        public void Insert(IEnumerable<ISnailMailType> entities)
        {
			foreach (ISnailMailType entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(ISnailMailType obj)
        {
            base.Update((SnailMailType)obj);
        }

        public void Update(IEnumerable<ISnailMailType> entities)
        {
			foreach (ISnailMailType entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(ISnailMailType entity)
        {
            base.Delete((SnailMailType)entity);
        }

        public void Delete(IEnumerable<ISnailMailType> entities)
        {
			foreach (ISnailMailType entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
