using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the PhoneNumberType table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class PhoneNumberTypeRepo : GenericRepository<PhoneNumberType> , IGenericRepository<IPhoneNumberType>
    {
		public PhoneNumberTypeRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IPhoneNumberType Create()
        {
            return base.Create();
        }

		public new IPhoneNumberType Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IPhoneNumberType> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IPhoneNumberType> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IPhoneNumberType obj)
        {
            base.Insert((PhoneNumberType)obj);
        }

        public void Insert(IEnumerable<IPhoneNumberType> entities)
        {
			foreach (IPhoneNumberType entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IPhoneNumberType obj)
        {
            base.Update((PhoneNumberType)obj);
        }

        public void Update(IEnumerable<IPhoneNumberType> entities)
        {
			foreach (IPhoneNumberType entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IPhoneNumberType entity)
        {
            base.Delete((PhoneNumberType)entity);
        }

        public void Delete(IEnumerable<IPhoneNumberType> entities)
        {
			foreach (IPhoneNumberType entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
