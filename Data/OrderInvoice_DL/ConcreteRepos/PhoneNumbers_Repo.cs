using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the PhoneNumbers table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class PhoneNumbersRepo : GenericRepository<PhoneNumbers> , IGenericRepository<IPhoneNumbers>
    {
		public PhoneNumbersRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IPhoneNumbers Create()
        {
            return base.Create();
        }

		public new IPhoneNumbers Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IPhoneNumbers> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IPhoneNumbers> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IPhoneNumbers obj)
        {
            base.Insert((PhoneNumbers)obj);
        }

        public void Insert(IEnumerable<IPhoneNumbers> entities)
        {
			foreach (IPhoneNumbers entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IPhoneNumbers obj)
        {
            base.Update((PhoneNumbers)obj);
        }

        public void Update(IEnumerable<IPhoneNumbers> entities)
        {
			foreach (IPhoneNumbers entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IPhoneNumbers entity)
        {
            base.Delete((PhoneNumbers)entity);
        }

        public void Delete(IEnumerable<IPhoneNumbers> entities)
        {
			foreach (IPhoneNumbers entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
