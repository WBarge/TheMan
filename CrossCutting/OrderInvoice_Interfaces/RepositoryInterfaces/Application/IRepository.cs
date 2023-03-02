using System.Collections.Generic;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    public partial interface IRepository
    {
        #region Application

        IApplicationConfiguration GetApplicationConfiguration(int id);
        void UpdateApplicationConfiguration(IApplicationConfiguration obj);
        IApplicationConfiguration CreateApplicationConfiguration();
        void InsertApplicationConfiguration(IApplicationConfiguration newObj);
        IEnumerable<IApplicationConfiguration> GetApplicationConfigurations();
        void DeleteApplicationConfiguration(int id);

        #endregion Application

        #region Role Methods

        IRoles GetRole(int id);
        IEnumerable<IRoles> GetRoles();
        IRoles CreateRole();
        void InsertRole(IRoles newObj);
        void UpdateRole(IRoles obj);
        void DeleteRole(int id);
        IEnumerable<IRoles> GetUserRoles(int userId);
        void AddRoleToUser(int userId, int roleId);
        bool RemoveRoleFromUser(int userId, int roleId);

        #endregion Role Methods

        #region UploadedFiles

        IUploadedFiles GetUploadedFiles(int id);
        void UpdateUploadedFiles(IUploadedFiles obj);
        IUploadedFiles CreateUploadedFiles();
        void InsertUploadedFiles(IUploadedFiles newObj);
        IEnumerable<IUploadedFiles> GetUploadedFiles();
        void DeleteUploadedFiles(int id);

        #endregion UploadedFiles


    }
}
