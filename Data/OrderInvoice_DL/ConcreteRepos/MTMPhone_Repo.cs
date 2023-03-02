using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the MTMPhone table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class MtmPhoneRepo : GenericRepository<MtmPhone> , IGenericRepository<IMtmPhone>
    {
		public MtmPhoneRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IMtmPhone Create()
        {
            return base.Create();
        }

		public new IMtmPhone Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IMtmPhone> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IMtmPhone> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IMtmPhone obj)
        {
            base.Insert((MtmPhone)obj);
        }

        public void Insert(IEnumerable<IMtmPhone> entities)
        {
			foreach (IMtmPhone entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IMtmPhone obj)
        {
            base.Update((MtmPhone)obj);
        }

        public void Update(IEnumerable<IMtmPhone> entities)
        {
			foreach (IMtmPhone entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IMtmPhone entity)
        {
            base.Delete((MtmPhone)entity);
        }

        public void Delete(IEnumerable<IMtmPhone> entities)
        {
			foreach (IMtmPhone entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
