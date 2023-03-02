using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the MTMProductAttributes table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class MtmProductAttributesRepo : GenericRepository<MtmProductAttributes> , IGenericRepository<IMtmProductAttributes>
    {
		public MtmProductAttributesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IMtmProductAttributes Create()
        {
            return base.Create();
        }

		public new IMtmProductAttributes Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IMtmProductAttributes> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IMtmProductAttributes> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IMtmProductAttributes obj)
        {
            base.Insert((MtmProductAttributes)obj);
        }

        public void Insert(IEnumerable<IMtmProductAttributes> entities)
        {
			foreach (IMtmProductAttributes entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IMtmProductAttributes obj)
        {
            base.Update((MtmProductAttributes)obj);
        }

        public void Update(IEnumerable<IMtmProductAttributes> entities)
        {
			foreach (IMtmProductAttributes entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IMtmProductAttributes entity)
        {
            base.Delete((MtmProductAttributes)entity);
        }

        public void Delete(IEnumerable<IMtmProductAttributes> entities)
        {
			foreach (IMtmProductAttributes entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
