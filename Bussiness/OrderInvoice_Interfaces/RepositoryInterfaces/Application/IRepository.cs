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

namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    public partial interface IRepository
    {
        #region Application

        /// <summary>
        /// Gets the application configuration.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IApplicationConfiguration.</returns>
        IApplicationConfiguration GetApplicationConfiguration(int id);
        /// <summary>
        /// Updates the application configuration.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateApplicationConfiguration(IApplicationConfiguration obj);
        /// <summary>
        /// Creates the application configuration.
        /// </summary>
        /// <returns>IApplicationConfiguration.</returns>
        IApplicationConfiguration CreateApplicationConfiguration();
        /// <summary>
        /// Inserts the application configuration.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertApplicationConfiguration(IApplicationConfiguration newObj);
        /// <summary>
        /// Gets the application configurations.
        /// </summary>
        /// <returns>IEnumerable&lt;IApplicationConfiguration&gt;.</returns>
        IEnumerable<IApplicationConfiguration> GetApplicationConfigurations();
        /// <summary>
        /// Deletes the application configuration.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteApplicationConfiguration(int id);

        #endregion Application

        #region Role Methods

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IRoles.</returns>
        IRoles GetRole(int id);
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns>IEnumerable&lt;IRoles&gt;.</returns>
        IEnumerable<IRoles> GetRoles();
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <returns>IRoles.</returns>
        IRoles CreateRole();
        /// <summary>
        /// Inserts the role.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertRole(IRoles newObj);
        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateRole(IRoles obj);
        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteRole(int id);
        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>IEnumerable&lt;IRoles&gt;.</returns>
        IEnumerable<IRoles> GetUserRoles(int userId);
        /// <summary>
        /// Adds the role to user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        void AddRoleToUser(int userId, int roleId);
        /// <summary>
        /// Removes the role from user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool RemoveRoleFromUser(int userId, int roleId);

        #endregion Role Methods

        #region UploadedFiles

        /// <summary>
        /// Gets the uploaded files.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IUploadedFiles.</returns>
        IUploadedFiles GetUploadedFiles(int id);
        /// <summary>
        /// Updates the uploaded files.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateUploadedFiles(IUploadedFiles obj);
        /// <summary>
        /// Creates the uploaded files.
        /// </summary>
        /// <returns>IUploadedFiles.</returns>
        IUploadedFiles CreateUploadedFiles();
        /// <summary>
        /// Inserts the uploaded files.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertUploadedFiles(IUploadedFiles newObj);
        /// <summary>
        /// Gets the uploaded files.
        /// </summary>
        /// <returns>IEnumerable&lt;IUploadedFiles&gt;.</returns>
        IEnumerable<IUploadedFiles> GetUploadedFiles();
        /// <summary>
        /// Deletes the uploaded files.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteUploadedFiles(int id);

        #endregion UploadedFiles


    }
}
