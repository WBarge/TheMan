using Microsoft.Extensions.DependencyInjection;
using OrderInvoice_DL;
using OrderInvoice_DL.Repository;
using OrderInvoice_Interfaces;
using OrderInvoice_Interfaces.RepositoryInterfaces;

namespace CompositionRoot
{
    /// <summary>
    /// This class setup to blocks only used in the Business Layer
    /// </summary>
    public class BusinessLayerStartUp
    {

        private readonly string _connectionStr;
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLayerStartUp"/> class.
        /// </summary>
        public BusinessLayerStartUp(string conStr)
        {
            this._connectionStr = conStr;
        }

        public void SetupBusinessLayer(IServiceCollection services)
        {
            services.AddTransient<IConnectionFactory, ConnectionFactory>(provider => new ConnectionFactory(this._connectionStr));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository, Repository>();
        }

    }
}
