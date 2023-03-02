using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the Users table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class UsersRepo : GenericRepository<Users> , IGenericRepository<IUsers>
    {
		public UsersRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IUsers Create()
        {
            return base.Create();
        }

		public new IUsers Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IUsers> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IUsers> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IUsers obj)
        {
            base.Insert((Users)obj);
        }

        public void Insert(IEnumerable<IUsers> entities)
        {
			foreach (IUsers entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IUsers obj)
        {
            base.Update((Users)obj);
        }

        public void Update(IEnumerable<IUsers> entities)
        {
			foreach (IUsers entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IUsers entity)
        {
            base.Delete((Users)entity);
        }

        public void Delete(IEnumerable<IUsers> entities)
        {
			foreach (IUsers entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
