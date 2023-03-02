using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the Country table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class CountryRepo : GenericRepository<Country> , IGenericRepository<ICountry>
    {
		public CountryRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new ICountry Create()
        {
            return base.Create();
        }

		public new ICountry Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<ICountry> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<ICountry> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(ICountry obj)
        {
            base.Insert((Country)obj);
        }

        public void Insert(IEnumerable<ICountry> entities)
        {
			foreach (ICountry entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(ICountry obj)
        {
            base.Update((Country)obj);
        }

        public void Update(IEnumerable<ICountry> entities)
        {
			foreach (ICountry entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(ICountry entity)
        {
            base.Delete((Country)entity);
        }

        public void Delete(IEnumerable<ICountry> entities)
        {
			foreach (ICountry entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
