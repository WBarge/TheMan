using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the MTMOptionAttributes table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class MtmOptionAttributesRepo : GenericRepository<MtmOptionAttributes> , IGenericRepository<IMtmOptionAttributes>
    {
		public MtmOptionAttributesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IMtmOptionAttributes Create()
        {
            return base.Create();
        }

		public new IMtmOptionAttributes Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IMtmOptionAttributes> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IMtmOptionAttributes> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IMtmOptionAttributes obj)
        {
            base.Insert((MtmOptionAttributes)obj);
        }

        public void Insert(IEnumerable<IMtmOptionAttributes> entities)
        {
			foreach (IMtmOptionAttributes entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IMtmOptionAttributes obj)
        {
            base.Update((MtmOptionAttributes)obj);
        }

        public void Update(IEnumerable<IMtmOptionAttributes> entities)
        {
			foreach (IMtmOptionAttributes entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IMtmOptionAttributes entity)
        {
            base.Delete((MtmOptionAttributes)entity);
        }

        public void Delete(IEnumerable<IMtmOptionAttributes> entities)
        {
			foreach (IMtmOptionAttributes entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
