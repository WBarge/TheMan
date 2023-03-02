using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.PeopleArea.Customer
{
    [TestFixture]
    class PersistentCustomerTests : TestBase
    {
        OrderInvoice_BL.People.Customer _c1;
        OrderInvoice_BL.People.Customer _c2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _c1 = GetTestCustomer();

            _c2 = OrderInvoice_BL.People.Customer.GetCustomerById(_c1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            DeleteAllCustomers();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_c1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_c2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_c1.Id == _c2.Id &&
                _c1.FirstName == _c2.FirstName &&
                _c1.LastName == _c2.LastName &&
                _c1.Deleted == _c2.Deleted &&
                _c1.Active == _c2.Active &&
                _c1.UserName == _c2.UserName &&
                _c1.Password == _c2.Password &&
                _c1.ContactId == _c2.ContactId &&
                _c1.Number == _c2.Number);
        }
    }
 }
