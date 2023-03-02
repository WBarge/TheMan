using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using Moq;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_BL.Application;
using OrderInvoice_Interfaces.DB_DTOs;
using Utilites;

namespace OrderInvoice_BL_UnitTests.Application
{
    public class ApplicationConfigurationTests
    {
        private Mock<IRepository> _repositoryMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository>();
        }

        [Test]
        public void CreateEmptyInstance()
        {
            IRepository repo = _repositoryMock.Object;
            ApplicationConfiguration sut = new ApplicationConfiguration(repo);

            Assert.IsTrue(sut.Id.IsEmpty());
            Assert.IsTrue(sut.Type == ApplicationConfigurationType.None);
            Assert.IsTrue(sut.Configuration.IsEmpty());
            Assert.Pass("Created an empty instance of the Application Configuration Object");
        }

        [Test]
        public void GetLoadedInstance()
        {
            ConfigureSingleTestObject();
            IRepository repo = _repositoryMock.Object;

            ApplicationConfiguration sut = ApplicationConfiguration.GetById(1, repo);

            Assert.AreEqual(sut.Id,1);
            Assert.AreEqual(sut.Type,ApplicationConfigurationType.None);
            Assert.AreEqual(sut.Configuration,Constants.CONFIGURATION_TEST_VALUE);
            Assert.Pass("Successfully Loaded and instance of the Application Configuration Object");
        }

        [Test]
        public void ReallyDeleteTheData()
        {
            ConfigureSingleTestObject();
            _repositoryMock.Setup(m => m.DeleteApplicationConfiguration(It.IsAny<int>()));
            _repositoryMock.Setup(m => m.SaveChanges());
            IRepository repo = _repositoryMock.Object;

            ApplicationConfiguration unused = ApplicationConfiguration.GetById(1, repo);

            _repositoryMock.Verify();
            Assert.Pass("The data was permanently deleted");
        }

        [Test]
        public void CannotDeleteAnObjectThatHasNotBeenSavedToTheDataBase()
        {
            IRepository repo = _repositoryMock.Object;
            ApplicationConfiguration sut = new ApplicationConfiguration(repo);
            Assert.Throws<DataException>(() =>
            {
                sut.PermanentlyRemoveFromSystem();
            });
            Assert.Pass("The object stopped you from deleting the object when it is not in the db");
        }

        [Test]
        public void GetByIdReturnsNullWhenDataNotPresent()
        {
            ConfigureEmptyTestObject();
            IRepository repo = _repositoryMock.Object;

            ApplicationConfiguration sut = ApplicationConfiguration.GetById(100000, repo);
            Assert.IsNull(sut);
            Assert.Pass("A null value was returned when the data is not present");

        }

        [Test]
        public void GetAllObjects()
        {
            ConfigureASetOfTestObjects();
            IRepository repo = _repositoryMock.Object;
            List<ApplicationConfiguration> sut = ApplicationConfiguration.GetAll(repo);
            Assert.Greater(sut.Count,0);
            Assert.Pass("Got the collection of objects");
        }

        [Test]
        public void GetAnEmptyCollection()
        {
            ConfigureAnEmptySetOfTestObjects();
            IRepository repo = _repositoryMock.Object;
            List<ApplicationConfiguration> sut = ApplicationConfiguration.GetAll(repo);
            Assert.IsNotNull(sut);
            Assert.AreEqual(sut.Count,0);
            Assert.Pass("Got and Empty collection");
        }


        private void ConfigureSingleTestObject()
        {
            _repositoryMock.Setup(m => m.GetApplicationConfiguration(It.IsAny<int>()))
                .Returns(DataCreator.CreateDataObejct());
        }

        private void ConfigureEmptyTestObject()
        {
            _repositoryMock.Setup(m => m.GetApplicationConfiguration(It.IsAny<int>()));
        }

        private void ConfigureASetOfTestObjects()
        {
            List<IApplicationConfiguration> resultSet = new List<IApplicationConfiguration>
            {
                DataCreator.CreateDataObejct()
            };
            _repositoryMock.Setup((m => m.GetApplicationConfigurations())).Returns(resultSet);
        }

        private void ConfigureAnEmptySetOfTestObjects()
        {
            List<IApplicationConfiguration> resultSet = new List<IApplicationConfiguration>();
            _repositoryMock.Setup((m => m.GetApplicationConfigurations())).Returns(resultSet);
        }
    }
}
