using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    /// <summary>
    /// Singleton to glue all the blocks together
    /// </summary>
    public class CompositionRoot
	{
        #region Local Vars

        #endregion Local Vars

        #region Properties

        #endregion Properties

        #region Constructors

        #endregion Constructors

        #region Methods

        #region Protected Methods

       
        #endregion Protected Methods

        #region Public Static Methods

        public static void StartupAspNet(IServiceCollection services, string connectionString)
        {
            BusinessLayerStartUp blStartup = new BusinessLayerStartUp(connectionString);
            blStartup.SetupBusinessLayer(services);

        }

        #endregion Public Static Methods

        #region Public Methods

        #endregion

        #endregion Methods
    }

}
