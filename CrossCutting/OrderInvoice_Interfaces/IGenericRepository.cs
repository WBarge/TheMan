using System.Collections.Generic;
using System.Linq;

namespace OrderInvoice_Interfaces
{
    public interface IGenericRepository<T>
    {
        T Create();
        T Get(int id);
        IQueryable<T> GetAll();
		IEnumerable<T> GetPaged(int pageNumber, int itemsPerPage);
        void Insert(T obj);
        void Insert(IEnumerable<T> list);
        void Update(T obj);
        void Update(IEnumerable<T> list);
        void Delete(T obj);
        void Delete(IEnumerable<T> list);
    }
}