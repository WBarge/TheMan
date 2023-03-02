// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="SystemDataController.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderInvoice_BL.Application;
using OrderInvoice_BL.People;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Logic;
using OrderInvoiceService.Models.API;
using Utilites;

namespace OrderInvoiceService.Controllers
{
    /// <summary>
    /// Class SystemDataController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    public class SystemDataController : Controller
    {
        /// <summary>
        /// The environment
        /// </summary>
        private readonly IWebHostEnvironment _environment;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemDataController" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="repository">The repository.</param>
        /// <exception cref="ArgumentNullException">
        /// environment
        /// or
        /// repository
        /// </exception>
        public SystemDataController(IWebHostEnvironment environment, IRepository repository)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Gets the location of the services to be used by the application
        /// </summary>
        /// <returns>JsonResult.</returns>
        [HttpGet]
        [Route("GetServiceLocation")]
        public JsonResult GetServiceLocation()
        {
            //*******************************************************************************************************
            //  The point of this is to off load all of the service calls to a different server than the one
            //  serving the pages (applications since they are SPAs).  We will want to pull the hostLocation from
            //  a configuration file.  Currently this is pointing to the local web server for now
            //  To off load we need to set the hostLocation of the server that hosts the API.
            //  The client will need to call this point to get the locations
            //*******************************************************************************************************


            string hostLocation = Request.Scheme + @"://" + Request.Host;


            //************************************************************************
            //  these service points needs to be moved to the web api service 
            //  if we are to off-load and have the client use GetServiceLocation 
            //  to get the service locations
            //************************************************************************
            //this list is not uptodate with all possible api calls
            //TODO update this list with all the possible api calls minus this method
            // see ClientApp\commonComponents\service\serviceLocator.service.ts and ClientApp\commonComponents\models\serviceLocations.ts 
            // for the current list of API calls
            const string bannerFileUploadPathUploadPath = @"/api/systemdata/BannerFileUpload";
            const string bannerFileListPath = @"/api/systemdata/GetBannerFiles";
            const string footerFileUploadPath = @"/api/systemdata/FooterFileUpload";
            const string footerFileListPath = @"/api/systemdata/GetFooterFiles";
            const string getSystemConfigurationPath = @"/api/systemdata/GetSystemConfiguration";
            const string setSystemConfigurationPath = @"/api/systemdata/SetSystemConfiguration";
            const string userServicePath = @"/api/systemdata/GetUsers";
            const string addUserServicePath = @"/api/systemdata/AddNewUser";
            const string rolesServicePath = @"/api/systemdata/GetRoles";
            const string setUserRolesPath = @"/api/systemdata/SetUserRoles";

            const string getContactsPath = @"/api/People/GetContacts";
            const string getContactPath = @"/api/People/GetContact";
            const string getCustomersPath = @"/api/People/GetCustomers";
            const string setCustomerPath = @"/api/People/SetCustomer";
            const string getStatesPath = @"/api/People/GetStates";
            const string getPhoneNumberTypesPath = @"/api/People/GetPhoneNumberTypes";
            const string getProductsPath = @"/api/Product/GetProducts";
            const string setProductPath = @"/api/Product/SetProduct";
            const string getProductOptionsPath = @"/api/Product/GetProductOptions";
            const string setProductOptionPath = @"/api/Product/SetProductOption";
            const string getAttributePath = @"/api/Product/GetAttributes";
            const string setAttributePath = @"/api/Product/SetAttribute";

            ServicesLocationModel returnValue = new ServicesLocationModel
            {
                BannerFileUploadServiceLocation = hostLocation + bannerFileUploadPathUploadPath,
                BannerFileListServiceLocation = hostLocation + bannerFileListPath,
                FooterFileUploadServiceLocation = hostLocation + footerFileUploadPath,
                FooterFileListServiceLocation = hostLocation + footerFileListPath,
                GetSystemConfigurationServiceLocation = hostLocation + getSystemConfigurationPath,
                SetSystemConfigurationServiceLocation = hostLocation + setSystemConfigurationPath,
                UsersServiceLocation = hostLocation + userServicePath,
                AddUserServiceLocation = hostLocation + addUserServicePath,
                RolesServiceLocation = hostLocation + rolesServicePath,
                SetUserRolesLocation = hostLocation + setUserRolesPath,
                GetContactsLocation = hostLocation + getContactsPath,
                GetContactLocation = hostLocation + getContactPath,
                GetCustomersLocation = hostLocation + getCustomersPath,
                SetCustomerLocation = hostLocation + setCustomerPath,
                GetStatesLocation = hostLocation + getStatesPath,
                GetPhoneNumberTypesLocation = hostLocation + getPhoneNumberTypesPath,
                GetProductsLocation = hostLocation + getProductsPath,
                SetProductLocation = hostLocation + setProductPath,
                GetProductOptionsLocation = hostLocation + getProductOptionsPath,
                SetProductOptionLocation = hostLocation + setProductOptionPath,
                GetAttributesLocation = hostLocation + getAttributePath,
                SetAttributeLocation = hostLocation + setAttributePath
            };

            return new JsonResult(returnValue);
        }

        /// <summary>
        /// Upload a file to be used as a banner
        /// </summary>
        /// <param name="uploadedFiles">The uploaded files.</param>
        /// <returns>Task.</returns>
        [HttpPost]
        [Route("BannerFileUpload")]
        public async Task BannerFileUpload(IFormCollection uploadedFiles)
        {
            await Task.Run(async () =>
            {

                foreach (IFormFile file in uploadedFiles.Files)
                {
                    if (file.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            //load the file into memory
                            await file.CopyToAsync(ms);
                            StoredFiles sf = new StoredFiles(_repository)
                            {
                                FileName = file.FileName,
                                FileContents = ms.ToArray(),
                                LocationType = FileLocationType.Banner
                            };
                            sf.Save();
                            Assets a = new Assets(_environment.WebRootPath);
                            a.PushToLocation(sf.FileName, sf.FileContents);
                        }
                    }
                }
            });
        }

        /// <summary>
        /// Gets the list of possible banner files.
        /// </summary>
        /// <returns>Task&lt;JsonResult&gt;.</returns>
        [HttpGet]
        [Route("GetBannerFiles")]
        public JsonResult GetBannerFiles()
        {
            List<DropDownItemModel> returnValue = new List<DropDownItemModel>();
            int counter = 0;
            returnValue.Add(UIHelpers.CreateFileDropDownItem("Select File", counter.ToString(), "Select File"));
            foreach (StoredFiles sf in StoredFiles.GetBannerFiles(_repository))
            {
                returnValue.Add(UIHelpers.CreateFileDropDownItem(sf.FileName, sf.Id.ToString(), sf.FileName));
            }

            return new JsonResult(returnValue.ToArray());
        }

        /// <summary>
        /// Upload a file to be used as a Footer
        /// </summary>
        /// <param name="uploadedFiles">The uploaded files.</param>
        /// <returns>Task.</returns>
        [HttpPost]
        [Route("FooterFileUpload")]
        public ActionResult FooterFileUpload(IFormCollection uploadedFiles)
        {
            Task.Run(async () =>
            {
                foreach (IFormFile file in uploadedFiles.Files)
                {
                    if (file.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            //load the file into memory
                            await file.CopyToAsync(ms);
                            StoredFiles sf = new StoredFiles(_repository)
                            {
                                FileName = file.FileName,
                                FileContents = ms.ToArray(),
                                LocationType = FileLocationType.Footer
                            };
                            sf.Save();
                            Assets a = new Assets(_environment.WebRootPath);
                            a.PushToLocation(sf.FileName, sf.FileContents);
                        }
                    }
                }
            });
            return new AcceptedResult();
        }

        /// <summary>
        /// Gets the list of possible footer files.
        /// </summary>
        /// <returns>Task&lt;JsonResult&gt;.</returns>
        [HttpGet]
        [Route("GetFooterFiles")]
        public JsonResult GetFooterFiles()
        {
            List<DropDownItemModel> returnValue = new List<DropDownItemModel>();
            int counter = 0;
            returnValue.Add(UIHelpers.CreateFileDropDownItem("Select File", counter.ToString(), "Select File"));
            foreach (StoredFiles sf in StoredFiles.GetFooterFiles(_repository))
            {
                returnValue.Add(UIHelpers.CreateFileDropDownItem(sf.FileName, sf.Id.ToString(), sf.FileName));
            }

            return new JsonResult(returnValue.ToArray());
        }

        /// <summary>
        /// Gets the system configuration.
        /// </summary>
        /// <returns>Task&lt;JsonResult&gt;.</returns>
        [HttpGet]
        [Route("GetSystemConfiguration")]
        public JsonResult GetSystemConfiguration()
        {
            SystemConfigurationModel returnValue = null;

            ConfigurationManager cm = new ConfigurationManager(_repository);
            returnValue = cm.GetConfiguration();
            if (returnValue.IsEmpty())
            {
                returnValue = new SystemConfigurationModel()
                {
                    BackgroundColor = "#ec32ec"
                };
            }

            return new JsonResult(returnValue);
        }

        /// <summary>
        /// Sets the system configuration.
        /// </summary>
        /// <param name="systemConfiguration">The system configuration.</param>
        /// <returns>Task.</returns>
        [HttpPost]
        [Route("SetSystemConfiguration")]
        public ActionResult SetSystemConfiguration([FromBody] SystemConfigurationModel systemConfiguration)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(systemConfiguration);
            ConfigurationManager cm = new ConfigurationManager(_repository);
            cm.SetConfiguration(systemConfiguration);
            HttpContext.Session.Clear();
            return new AcceptedResult();
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>Task&lt;JsonResult&gt;.</returns>
        [HttpGet]
        [Route("GetUsers")]
        public JsonResult GetUsers()
        {
            List<DropDownItemModel> returnValue = new List<DropDownItemModel>();

            List<User> userList = OrderInvoice_BL.People.User.GetAllUsers(_repository);
            foreach (User user in userList)
            {
                DropDownItemModel usingDropDown = new DropDownItemModel()
                {
                    Label = user.UserName
                };
                UserModel userDetail = new UserModel()
                {
                    Id = user.Id,
                    Label = usingDropDown.Label
                };
                Role[] userRoles = user.GetRoles();
                userDetail.Roles = new string[userRoles.Length];
                for (int counter = 0; counter < userRoles.Length; counter++)
                {
                    Role role = userRoles[counter];
                    userDetail.Roles[counter] = role.Name;
                }

                usingDropDown.Value = userDetail;
                returnValue.Add(usingDropDown);
            }

            return new JsonResult(returnValue.ToArray());
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="newUser">The new user.</param>
        /// <returns>Task.</returns>
        [HttpPost]
        [Route("AddNewUser")]
        public ActionResult AddNewUser([FromBody] NewUserModel newUser)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(newUser);
            OrderInvoice_BL.People.User.CreateUserWithNoContact(_repository, newUser.UserName, newUser.Password);
            return new AcceptedResult();
        }

        /// <summary>
        /// Gets the roles defined in the system.
        /// </summary>
        /// <returns>Task&lt;JsonResult&gt;.</returns>
        [HttpGet]
        [Route("GetRoles")]
        public JsonResult GetRoles()
        {
            List<string> returnValue = new List<string>();
            //yes this does not have any db hits but made method async so its stubed out to change
            returnValue.Add(Constants.AdminRoleName);
            returnValue.Add(Constants.StandardUserRoleName);
            return new JsonResult(returnValue.ToArray());
        }

        /// <summary>
        /// Sets the user roles.
        /// </summary>
        /// <param name="usersRoles">The users roles.</param>
        /// <returns>Task.</returns>
        [HttpPost]
        [Route("SetUserRoles")]
        public ActionResult SetUserRoles([FromBody] AdjustingUserRolesModel usersRoles)
        {
            ParameterHelpers.ThrowInvalidParameterExceptionIfNull(usersRoles);
            User user = OrderInvoice_BL.People.User.GetUserById(usersRoles.UserId, _repository);
            if (user.IsNotEmpty())
            {
                List<Role> rolesToSet = Role.GetAll(_repository).Where(r => r.Name.In(usersRoles.Roles)).ToList();
                if (rolesToSet.IsNotEmpty()
                ) //roles are controlled by the developer so this is only defensive code (aka the above should always return at lease one role)
                {
                    user.SetRoles(rolesToSet);
                }
            }

            return new AcceptedResult();
        }

    }
}
