using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the MTMSnailMail table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class MtmSnailMailRepo : GenericRepository<MtmSnailMail> , IGenericRepository<IMtmSnailMail>
    {
		public MtmSnailMailRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IMtmSnailMail Create()
        {
            return base.Create();
        }

		public new IMtmSnailMail Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IMtmSnailMail> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IMtmSnailMail> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IMtmSnailMail obj)
        {
            base.Insert((MtmSnailMail)obj);
        }

        public void Insert(IEnumerable<IMtmSnailMail> entities)
        {
			foreach (IMtmSnailMail entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IMtmSnailMail obj)
        {
            base.Update((MtmSnailMail)obj);
        }

        public void Update(IEnumerable<IMtmSnailMail> entities)
        {
			foreach (IMtmSnailMail entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IMtmSnailMail entity)
        {
            base.Delete((MtmSnailMail)entity);
        }

        public void Delete(IEnumerable<IMtmSnailMail> entities)
        {
			foreach (IMtmSnailMail entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
