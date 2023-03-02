using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.PeopleArea.Employee
{
    [TestFixture]
    class PersistentEmployeeTests : TestBase
    {
        OrderInvoice_BL.People.Employee _e1;
        OrderInvoice_BL.People.Employee _e2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _e1 = GetTestEmployee();

            _e2 = OrderInvoice_BL.People.Employee.GetEmployeeById(_e1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            DeleteAllEmployees();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_e1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_e2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_e1.Id == _e2.Id &&
                _e1.FirstName == _e2.FirstName &&
                _e1.LastName == _e2.LastName &&
                _e1.Deleted == _e2.Deleted &&
                _e1.Active == _e2.Active &&
                _e1.UserName == _e2.UserName &&
                _e1.Password == _e2.Password &&
                _e1.ContactId == _e2.ContactId &&
                _e1.BadgeId == _e2.BadgeId);
        }
    }
}
