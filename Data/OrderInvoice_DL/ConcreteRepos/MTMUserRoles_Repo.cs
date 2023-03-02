using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the MTMUserRoles table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class MtmUserRolesRepo : GenericRepository<MtmUserRoles> , IGenericRepository<IMtmUserRoles>
    {
		public MtmUserRolesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IMtmUserRoles Create()
        {
            return base.Create();
        }

		public new IMtmUserRoles Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IMtmUserRoles> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IMtmUserRoles> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IMtmUserRoles obj)
        {
            base.Insert((MtmUserRoles)obj);
        }

        public void Insert(IEnumerable<IMtmUserRoles> entities)
        {
			foreach (IMtmUserRoles entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IMtmUserRoles obj)
        {
            base.Update((MtmUserRoles)obj);
        }

        public void Update(IEnumerable<IMtmUserRoles> entities)
        {
			foreach (IMtmUserRoles entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IMtmUserRoles entity)
        {
            base.Delete((MtmUserRoles)entity);
        }

        public void Delete(IEnumerable<IMtmUserRoles> entities)
        {
			foreach (IMtmUserRoles entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
