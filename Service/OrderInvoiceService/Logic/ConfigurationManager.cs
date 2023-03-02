// ***********************************************************************
// Assembly         : OrderInvoiceService
// Author           : Admin
// Created          : 02-22-2021
//
// Last Modified By : Admin
// Last Modified On : 02-22-2021
// ***********************************************************************
// <copyright file="ConfigurationManager.cs" company="OrderInvoiceService">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data;
using Newtonsoft.Json;
using OrderInvoice_BL.Application;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoiceService.Models.API;
using Utilites;

namespace OrderInvoiceService.Logic
{
    /// <summary>
    /// ConfigurationManager - helps manage configuration information for the system.
    /// </summary>
    public class ConfigurationManager
    {

        /// <summary>
        /// The configuration type for UI
        /// </summary>
        const ApplicationConfigurationType ConfigurationTypeForUi = ApplicationConfigurationType.WebUiConfiguration;

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationManager" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ConfigurationManager(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns>SystemConfigurationModel.</returns>
        public SystemConfigurationModel GetConfiguration()
        {
            SystemConfigurationModel returnValue = null;

            ApplicationConfiguration ac = ApplicationConfiguration.GetByType(_repository, ConfigurationTypeForUi);
            if (ac.IsNotEmpty())
            {
                var config = JsonConvert.DeserializeObject(ac.Configuration,typeof(SystemConfigurationModel));
                returnValue = (SystemConfigurationModel)config;
            }
            return returnValue;
        }

        /// <summary>
        /// Sets the configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public void SetConfiguration(SystemConfigurationModel config)
        {
            ValidateModel(config);
            string configAsJson = JsonConvert.SerializeObject(config);
            ApplicationConfiguration ac = ApplicationConfiguration.GetByType(_repository, ConfigurationTypeForUi);
            if (ac.IsEmpty())
            {
                ac = new ApplicationConfiguration(_repository) {Type = ConfigurationTypeForUi};
            }
            ac.Configuration = configAsJson;
            ac.Save();
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <exception cref="DataException">The next customer cannot be a negative number.</exception>
        /// <exception cref="System.Data.DataException">The next customer cannot be a negative number.</exception>
        private void ValidateModel(SystemConfigurationModel config)
        {
            if (config.NextCustomerNumber < 0)
            {
                throw new DataException("The next customer cannot be a negative number.");
            }
        }
    }
}
