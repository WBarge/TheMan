using NUnit.Framework;
using OrderInvoice_BL.Application;
using Utilites;

namespace NUnit.LayerIntragrationTests.ApplicationArea.ApplicationConfigurationArea
{
    [TestFixture]
    class NonPersistentApplicationConfigurationTests:TestBase
    {
        ApplicationConfiguration _config;

        /// <summary>
        /// Setup object for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _config = new ApplicationConfiguration(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_config.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the Type property
        /// </summary>
        [Test]
        public void InitTypeTest()
        {
            Assert.AreEqual(_config.Type, ApplicationConfigurationType.None);
        }

        /// <summary>
        /// Test the initial state of the configuration property
        /// </summary>
        [Test]
        public void InitConfigurationTest()
        {
            Assert.AreEqual(_config.Configuration,string.Empty);
        }
    }
}
