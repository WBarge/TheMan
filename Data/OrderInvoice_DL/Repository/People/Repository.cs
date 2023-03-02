// ***********************************************************************
// Assembly         : OrderInvoice_DL
// Author           : Bill Barge
// Created          : 01-14-2017
//
// Last Modified By : Bill Barge
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="Repository.cs" company="N/A">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;

using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_DL.Repository

{
    /// <summary>
    /// This part of the class will hold all methods needed by the people area of the system
    /// </summary>
    /// <seealso cref="IRepository" />
    public partial class Repository : IRepository
    {
        #region User
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IUsers.</returns>
        public IUsers GetUser(int id)
        {
            return Context.Users.Get(id);
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>IEnumerable&lt;IUsers&gt;.</returns>
        public IEnumerable<IUsers> GetUsers()
        {
            return Enumerable.ToList<IUsers>(Context.Users.GetAll());
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>IUsers.</returns>
        public IUsers CreateUser()
        {
            return Context.Users.Create();
        }

        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertUser(IUsers newObj)
        {
            Context.Users.Insert(newObj);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateUser(IUsers obj)
        {
            Context.Users.Update(obj);
        }

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteUser(int id)
        {
            Context.Users.Delete(GetUser(id));
        }
        #endregion User

        #region Employee
        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IEmployees.</returns>
        public IEmployees GetEmployee(int id)
        {
            return Context.Employees.Get(id);
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>IEnumerable&lt;IEmployees&gt;.</returns>
        public IEnumerable<IEmployees> GetEmployees ()
        {
            return Enumerable.ToList<IEmployees>(Context.Employees.GetAll());
        }

        /// <summary>
        /// Creates the employee.
        /// </summary>
        /// <returns>IEmployees.</returns>
        public IEmployees CreateEmployee ()
        {
            return Context.Employees.Create();
        }

        /// <summary>
        /// Inserts the employee.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertEmployee (IEmployees newObj)
        {
            Context.Employees.Insert(newObj);
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateEmployee(IEmployees obj)
        {
            Context.Employees.Update(obj);
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteEmployee(int id)
        {
            Context.Employees.Delete(GetEmployee(id));
        }
        #endregion Employee

        #region Customer
        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomers.</returns>
        public ICustomers GetCustomer(int id)
        {
            return Context.Customers.Get(id);
        }

        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <returns>IEnumerable&lt;ICustomers&gt;.</returns>
        public IEnumerable<ICustomers> GetCustomers()
        {
            return Enumerable.ToList<ICustomers>(Context.Customers.GetAll());
        }

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <returns>ICustomers.</returns>
        public ICustomers CreateCustomer()
        {
            return Context.Customers.Create();
        }

        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertCustomer(ICustomers newObj)
        {
            Context.Customers.Insert(newObj);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateCustomer(ICustomers obj)
        {
            Context.Customers.Update(obj);
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteCustomer(int id)
        {
            Context.Customers.Delete(GetCustomer(id));
        }
        #endregion Customer
    }
}
