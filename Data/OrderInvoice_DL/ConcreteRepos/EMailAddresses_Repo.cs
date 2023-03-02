using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the EMailAddresses table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class EMailAddressesRepo : GenericRepository<EMailAddresses> , IGenericRepository<IEMailAddresses>
    {
		public EMailAddressesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IEMailAddresses Create()
        {
            return base.Create();
        }

		public new IEMailAddresses Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IEMailAddresses> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IEMailAddresses> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IEMailAddresses obj)
        {
            base.Insert((EMailAddresses)obj);
        }

        public void Insert(IEnumerable<IEMailAddresses> entities)
        {
			foreach (IEMailAddresses entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IEMailAddresses obj)
        {
            base.Update((EMailAddresses)obj);
        }

        public void Update(IEnumerable<IEMailAddresses> entities)
        {
			foreach (IEMailAddresses entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IEMailAddresses entity)
        {
            base.Delete((EMailAddresses)entity);
        }

        public void Delete(IEnumerable<IEMailAddresses> entities)
        {
			foreach (IEMailAddresses entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
