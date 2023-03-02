using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.PeopleArea.Employee
{
    [TestFixture]
    class NonPersistentEmployeeTests : TestBase
    {
        OrderInvoice_BL.People.Employee _employee;
        OrderInvoice_BL.People.User _user;
        Contact _contact;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _employee = new OrderInvoice_BL.People.Employee(GetRepository);
            _user = _employee;
            _contact = _user;
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_employee.IsNotEmpty());
            Assert.IsTrue(_user.IsNotEmpty());
            Assert.IsTrue(_contact.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_employee.Id, DefaultValues.DefaultInt);
            Assert.AreEqual(_user.Id, DefaultValues.DefaultInt);
            Assert.AreEqual(_contact.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_employee.Deleted);
            Assert.IsFalse(_user.Deleted);
            Assert.IsFalse(_contact.Deleted);
        }

        /// <summary>
        /// Test the initial state of the FirstName property
        /// </summary>
        [Test]
        public void InitFirstNameTest()
        {
            Assert.AreEqual(_user.FirstName, string.Empty);
            Assert.AreEqual(_contact.FirstName, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the LastName property
        /// </summary>
        [Test]
        public void InitLastNameTest()
        {
            Assert.AreEqual(_user.LastName, string.Empty);
            Assert.AreEqual(_contact.LastName, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the user name property.
        /// </summary>
        [Test]
        public void InitUserNameTest()
        {
            Assert.AreEqual(_user.UserName, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the password property.
        /// </summary>
        [Test]
        public void InitPasswordTest()
        {
            Assert.AreEqual(_user.Password, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the badge property
        /// </summary>
        [Test]
        public void InitBadgeIdTest()
        {
            Assert.AreEqual(_employee.BadgeId, string.Empty);
        }
    }
}
