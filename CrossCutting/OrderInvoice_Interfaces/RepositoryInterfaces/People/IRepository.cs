using System.Collections.Generic;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    public partial interface IRepository
    {
        #region User
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IUsers GetUser(int id);
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IUsers> GetUsers();
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns></returns>
        IUsers CreateUser();
        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertUser(IUsers newObj);
        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateUser(IUsers obj);
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteUser(int id);
        #endregion User

        #region Employee
        IEmployees GetEmployee(int id);
        IEnumerable<IEmployees> GetEmployees();
        IEmployees CreateEmployee();
        void InsertEmployee(IEmployees newObj);
        void UpdateEmployee(IEmployees obj);
        void DeleteEmployee(int id);
        #endregion Employee

        #region Customer
        ICustomers GetCustomer(int id);
        IEnumerable<ICustomers> GetCustomers();
        ICustomers CreateCustomer();
        void InsertCustomer(ICustomers newObj);
        void UpdateCustomer(ICustomers obj);
        void DeleteCustomer(int id);
        #endregion Employee
    }
}
