using System.Collections.Generic;
using System.Linq;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.DB_DTOs;
using OrderInvoice_DL.ConcretePocos;

namespace OrderInvoice_DL.ConcreteRepos
{
    /// <summary>
    /// Represents a repository for the Employees table.
    /// NOTE:	Basic Gets, Inserts and Updates are handled by the base class.
	///			Extend this class to add any custom gets.
    /// </summary>
    internal class EmployeesRepo : GenericRepository<Employees> , IGenericRepository<IEmployees>
    {
		public EmployeesRepo (IConnectionFactory connectionFactory, Queue<QueueItem> queue,IPrimaryKeyRetriever primaryKeyRetriever) : base(connectionFactory,queue,primaryKeyRetriever) { }

		public new IEmployees Create()
        {
            return base.Create();
        }

		public new IEmployees Get(int id)
		{
			return base.Get(id);
		}

        public new IQueryable<IEmployees> GetAll()
        {
            return base.GetAll();
        }

		public IEnumerable<IEmployees> GetPaged(int pageNumber,int itemsPerPage)
        {
            return base.GetPaged(pageNumber, itemsPerPage, null, null);
        }


        public void Insert(IEmployees obj)
        {
            base.Insert((Employees)obj);
        }

        public void Insert(IEnumerable<IEmployees> entities)
        {
			foreach (IEmployees entity in entities)
			{
				Insert(entity);
			}
        }

        public void Update(IEmployees obj)
        {
            base.Update((Employees)obj);
        }

        public void Update(IEnumerable<IEmployees> entities)
        {
			foreach (IEmployees entity in entities)
			{
				Update(entity);
			}
        }

        public void Delete(IEmployees entity)
        {
            base.Delete((Employees)entity);
        }

        public void Delete(IEnumerable<IEmployees> entities)
        {
			foreach (IEmployees entity in entities)
			{
				Delete(entity);
			}
        }
    }
}
