using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the Contacts table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class ContactsRepo : GenericRepository<Contacts> , IGenericRepository<IContacts>
    {
		public ContactsRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IContacts Create()
        {
            return base.Create();
        }

		public new IContacts Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IContacts> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IContacts> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }

        public void Insert(IContacts obj)
        {
            base.Insert((Contacts)obj);
        }

        public void Insert(IEnumerable<IContacts> entities)
        {
			foreach (IContacts entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IContacts obj)
        {
            base.Update((Contacts)obj);
        }

        public void Update(IEnumerable<IContacts> entities)
        {
			foreach (IContacts entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IContacts entity)
        {
            base.Delete((Contacts)entity);
        }

        public void Delete(IEnumerable<IContacts> entities)
        {
			foreach (IContacts entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
