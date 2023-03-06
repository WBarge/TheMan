// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IRepository.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using OrderInvoice_Interfaces.DB_DTOs;

// ReSharper disable once CheckNamespace
namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    public partial interface IRepository
    {
        #region User
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IUsers.</returns>
        IUsers GetUser(int id);
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>IEnumerable&lt;IUsers&gt;.</returns>
        IEnumerable<IUsers> GetUsers();
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <returns>IUsers.</returns>
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
        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IEmployees.</returns>
        IEmployees GetEmployee(int id);
        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns>IEnumerable&lt;IEmployees&gt;.</returns>
        IEnumerable<IEmployees> GetEmployees();
        /// <summary>
        /// Creates the employee.
        /// </summary>
        /// <returns>IEmployees.</returns>
        IEmployees CreateEmployee();
        /// <summary>
        /// Inserts the employee.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertEmployee(IEmployees newObj);
        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateEmployee(IEmployees obj);
        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteEmployee(int id);
        #endregion Employee

        #region Customer
        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICustomers.</returns>
        ICustomers GetCustomer(int id);
        /// <summary>
        /// Gets the customers.
        /// </summary>
        /// <returns>IEnumerable&lt;ICustomers&gt;.</returns>
        IEnumerable<ICustomers> GetCustomers();
        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <returns>ICustomers.</returns>
        ICustomers CreateCustomer();
        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertCustomer(ICustomers newObj);
        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateCustomer(ICustomers obj);
        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCustomer(int id);
        #endregion Employee
    }
}
