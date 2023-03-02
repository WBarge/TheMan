using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the OptionsAttributeValues table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class OptionsAttributeValuesRepo : GenericRepository<OptionsAttributeValues> , IGenericRepository<IOptionsAttributeValues>
    {
		public OptionsAttributeValuesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IOptionsAttributeValues Create()
        {
            return base.Create();
        }

		public new IOptionsAttributeValues Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IOptionsAttributeValues> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IOptionsAttributeValues> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IOptionsAttributeValues obj)
        {
            base.Insert((OptionsAttributeValues)obj);
        }

        public void Insert(IEnumerable<IOptionsAttributeValues> entities)
        {
			foreach (IOptionsAttributeValues entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IOptionsAttributeValues obj)
        {
            base.Update((OptionsAttributeValues)obj);
        }

        public void Update(IEnumerable<IOptionsAttributeValues> entities)
        {
			foreach (IOptionsAttributeValues entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IOptionsAttributeValues entity)
        {
            base.Delete((OptionsAttributeValues)entity);
        }

        public void Delete(IEnumerable<IOptionsAttributeValues> entities)
        {
			foreach (IOptionsAttributeValues entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
