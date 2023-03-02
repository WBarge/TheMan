using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the OptionPrice table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class OptionPriceRepo : GenericRepository<OptionPrice> , IGenericRepository<IOptionPrice>
    {
		public OptionPriceRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IOptionPrice Create()
        {
            return base.Create();
        }

		public new IOptionPrice Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IOptionPrice> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IOptionPrice> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IOptionPrice obj)
        {
            base.Insert((OptionPrice)obj);
        }

        public void Insert(IEnumerable<IOptionPrice> entities)
        {
			foreach (IOptionPrice entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IOptionPrice obj)
        {
            base.Update((OptionPrice)obj);
        }

        public void Update(IEnumerable<IOptionPrice> entities)
        {
			foreach (IOptionPrice entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IOptionPrice entity)
        {
            base.Delete((OptionPrice)entity);
        }

        public void Delete(IEnumerable<IOptionPrice> entities)
        {
			foreach (IOptionPrice entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
