using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the MTMOptions table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class MtmOptionsRepo : GenericRepository<MtmOptions> , IGenericRepository<IMtmOptions>
    {
		public MtmOptionsRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IMtmOptions Create()
        {
            return base.Create();
        }

		public new IMtmOptions Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IMtmOptions> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IMtmOptions> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IMtmOptions obj)
        {
            base.Insert((MtmOptions)obj);
        }

        public void Insert(IEnumerable<IMtmOptions> entities)
        {
			foreach (IMtmOptions entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IMtmOptions obj)
        {
            base.Update((MtmOptions)obj);
        }

        public void Update(IEnumerable<IMtmOptions> entities)
        {
			foreach (IMtmOptions entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IMtmOptions entity)
        {
            base.Delete((MtmOptions)entity);
        }

        public void Delete(IEnumerable<IMtmOptions> entities)
        {
			foreach (IMtmOptions entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
