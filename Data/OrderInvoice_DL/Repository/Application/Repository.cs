// ***********************************************************************
// Assembly         : OrderInvoice_DL
// Author           : Bill Barge
// Created          : 01-14-2017
//
// Last Modified By : Admin
// Last Modified On : 01-14-2017
// ***********************************************************************
// <copyright file="Repository.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using Utilites;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_DL.Repository
{
    /// <summary>
    /// This part of the class will hold all methods needed by the application area of the system
    /// </summary>
    /// <seealso cref="IRepository" />
    public partial class Repository
    {
        #region ApplicationConfiguration Methods
        
        /// <summary>
        /// Gets the application configuration.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IApplicationConfiguration.</returns>
        public IApplicationConfiguration GetApplicationConfiguration(int id)
        {
            return this.Context.ApplicationConfiguration.Get(id);
        }

        /// <summary>
        /// Updates the application configuration.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateApplicationConfiguration(IApplicationConfiguration obj)
        {
            Context.ApplicationConfiguration.Update(obj);
        }

        /// <summary>
        /// Creates the application configuration.
        /// </summary>
        /// <returns>IApplicationConfiguration.</returns>
        public IApplicationConfiguration CreateApplicationConfiguration()
        {
            return Context.ApplicationConfiguration.Create();
        }

        /// <summary>
        /// Inserts the application configuration.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertApplicationConfiguration(IApplicationConfiguration newObj)
        {
            Context.ApplicationConfiguration.Insert(newObj);
        }

        /// <summary>
        /// Gets the application configurations.
        /// </summary>
        /// <returns>IEnumerable&lt;IApplicationConfiguration&gt;.</returns>
        public IEnumerable<IApplicationConfiguration> GetApplicationConfigurations()
        {
            return Enumerable.ToList<IApplicationConfiguration>(Context.ApplicationConfiguration.GetAll());
        }

        /// <summary>
        /// Deletes the application configuration.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteApplicationConfiguration(int id)
        {
            Context.ApplicationConfiguration.Delete(GetApplicationConfiguration(id));
        }
        
        #endregion ApplicationConfiguration Methods

        #region Role Methods

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IStates.</returns>
        public IRoles GetRole(int id)
        {
            return Context.Roles.Get(id);
        }

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <returns>IEnumerable&lt;IStates&gt;.</returns>
        public IEnumerable<IRoles> GetRoles()
        {
            return Enumerable.ToList<IRoles>(Context.Roles.GetAll());
        }

        /// <summary>
        /// Creates the state.
        /// </summary>
        /// <returns>IStates.</returns>
        public IRoles CreateRole()
        {
            return Context.Roles.Create();
        }

        /// <summary>
        /// Inserts the state.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertRole(IRoles newObj)
        {
            Context.Roles.Insert(newObj);
        }

        /// <summary>
        /// Updates the state.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateRole(IRoles obj)
        {
            Context.Roles.Update(obj);
        }

        /// <summary>
        /// Deletes the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteRole(int id)
        {
            Context.Roles.Delete(GetRole(id));
        }

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>IEnumerable&lt;IRoles&gt;.</returns>
        public IEnumerable<IRoles> GetUserRoles(int userId)
        {
            List<IRoles> returnValue = new List<IRoles>();
            List<IMtmUserRoles> connectingTable = Queryable.Where<IMtmUserRoles>(Context.MtmUserRoles.GetAll(), c => c.UserObjid == userId).ToList();
            if (connectingTable.IsNotEmpty())
            {
                foreach (IMtmUserRoles obj in connectingTable)
                {
                    var ph = GetRole(obj.RoleObjid);
                    returnValue.Add(ph);
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Adds the role to user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        public void AddRoleToUser(int userId, int roleId)
        {
            IMtmUserRoles connectionTable = Context.MtmUserRoles.Create();
            connectionTable.UserObjid = userId;
            connectionTable.RoleObjid = roleId;
            Context.MtmUserRoles.Insert(connectionTable);
        }

        /// <summary>
        /// Removes the role from user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveRoleFromUser(int userId, int roleId)
        {
            bool returnValue = false;
            IMtmUserRoles connectionTable = Queryable.Where<IMtmUserRoles>(Context.MtmUserRoles.GetAll(), mp => mp.UserObjid == userId && mp.RoleObjid == roleId).FirstOrDefault();
            if (connectionTable.IsNotEmpty())
            {
                Context.MtmUserRoles.Delete(connectionTable);
                returnValue = true;
            }
            return returnValue;
        }

        #endregion Role Methods

        #region UploadedFiles

        /// <summary>
        /// Gets the uploaded files.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IUploadedFiles.</returns>
        public IUploadedFiles GetUploadedFiles(int id)
        {
            return Context.UploadedFiles.Get(id);
        }

        /// <summary>
        /// Updates the uploaded files.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateUploadedFiles(IUploadedFiles obj)
        {
            Context.UploadedFiles.Update(obj);
        }

        /// <summary>
        /// Creates the uploaded files.
        /// </summary>
        /// <returns>IUploadedFiles.</returns>
        public IUploadedFiles CreateUploadedFiles()
        {
            return Context.UploadedFiles.Create();
        }

        /// <summary>
        /// Inserts the uploaded files.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertUploadedFiles(IUploadedFiles newObj)
        {
            Context.UploadedFiles.Insert(newObj);
        }

        /// <summary>
        /// Gets the uploaded files.
        /// </summary>
        /// <returns>IEnumerable&lt;IUploadedFiles&gt;.</returns>
        public IEnumerable<IUploadedFiles> GetUploadedFiles()
        {
            return Enumerable.ToList<IUploadedFiles>(Context.UploadedFiles.GetAll());
        }

        /// <summary>
        /// Deletes the uploaded files.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteUploadedFiles(int id)
        {
            Context.UploadedFiles.Delete(GetUploadedFiles(id));
        }

        #endregion UploadedFiles


    }
}
