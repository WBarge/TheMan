using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Application;

namespace NUnit.LayerIntragrationTests.ApplicationArea.ApplicationConfigurationArea
{
    [TestFixture]
    class BlApplicationConfigurationTests:TestBase
    {

        ApplicationConfiguration _config1;

        const string Configuration = "Test Config";
        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _config1 =
                new ApplicationConfiguration(GetRepository)
                {
                    Type = ApplicationConfigurationType.WebUiConfiguration,
                    Configuration = Configuration
                };
            _config1.Save();
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            List<ApplicationConfiguration> results = ApplicationConfiguration.GetAll(GetRepository);
            foreach (ApplicationConfiguration pnt in results)
            {
                pnt.PermanentlyRemoveFromSystem();
            }
        }


        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void DeletionNotAllowedOnUnsavedObjectTest()
        {
            ApplicationConfiguration testObj = new ApplicationConfiguration(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        /// <summary>
        /// The application configuration is a place for application options to be stored
        /// While multiple applications can make use of the business object you can have only one application type
        /// per system
        /// EG a web type is one web service type is another - they are two different applications where it is possible
        /// for each to have their own options. I.E. options are not shared across applications in the given example
        /// </summary>
        [Test]
        public void OnlyOneApplicationConfigurationTypeTest()
        {
            ApplicationConfiguration config2 =
                new ApplicationConfiguration(GetRepository)
                {
                    Type = ApplicationConfigurationType.WebUiConfiguration,
                    Configuration = Configuration
                };
            Assert.Throws<DataException>(() => config2.Save());
        }

        /// <summary>
        /// Tests getting the applicaiton configuration by the application type.
        /// </summary>
        [Test]
        public void GetByTypeTest()
        {
            ApplicationConfiguration ac = ApplicationConfiguration.GetByType(GetRepository, ApplicationConfigurationType.WebUiConfiguration);
            Assert.AreEqual(_config1.Id, ac.Id);
        }
    }
}
