using NUnit.Framework;
using OrderInvoice_BL.Application;
using Utilites;

namespace NUnit.LayerIntragrationTests.ApplicationArea.ApplicationConfigurationArea
{
    [TestFixture]
    class PersistentApplicationConfigurationTests : TestBase
    {
        ApplicationConfiguration _config1;
        ApplicationConfiguration _config2;

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

            _config2 = ApplicationConfiguration.GetById(_config1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _config1.PermanentlyRemoveFromSystem();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_config1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_config2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_config1.Id == _config2.Id && _config1.Type == _config2.Type && _config1.Configuration == _config2.Configuration);
        }

    }
}
