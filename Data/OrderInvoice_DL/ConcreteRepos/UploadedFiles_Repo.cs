using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the UploadedFiles table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class UploadedFilesRepo : GenericRepository<UploadedFiles> , IGenericRepository<IUploadedFiles>
    {
		public UploadedFilesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IUploadedFiles Create()
        {
            return base.Create();
        }

		public new IUploadedFiles Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IUploadedFiles> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IUploadedFiles> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IUploadedFiles obj)
        {
            base.Insert((UploadedFiles)obj);
        }

        public void Insert(IEnumerable<IUploadedFiles> entities)
        {
			foreach (IUploadedFiles entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IUploadedFiles obj)
        {
            base.Update((UploadedFiles)obj);
        }

        public void Update(IEnumerable<IUploadedFiles> entities)
        {
			foreach (IUploadedFiles entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IUploadedFiles entity)
        {
            base.Delete((UploadedFiles)entity);
        }

        public void Delete(IEnumerable<IUploadedFiles> entities)
        {
			foreach (IUploadedFiles entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
