using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the States table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class StatesRepo : GenericRepository<States> , IGenericRepository<IStates>
    {
		public StatesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IStates Create()
        {
            return base.Create();
        }

		public new IStates Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IStates> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IStates> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IStates obj)
        {
            base.Insert((States)obj);
        }

        public void Insert(IEnumerable<IStates> entities)
        {
			foreach (IStates entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IStates obj)
        {
            base.Update((States)obj);
        }

        public void Update(IEnumerable<IStates> entities)
        {
			foreach (IStates entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IStates entity)
        {
            base.Delete((States)entity);
        }

        public void Delete(IEnumerable<IStates> entities)
        {
			foreach (IStates entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
