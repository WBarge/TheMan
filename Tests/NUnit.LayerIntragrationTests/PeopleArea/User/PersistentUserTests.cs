using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.PeopleArea.User
{
    [TestFixture]
    class PersistentUserTests : TestBase
    {
        OrderInvoice_BL.People.User _u1;
        OrderInvoice_BL.People.User _u2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _u1 = GetTestUser();

            _u2 = OrderInvoice_BL.People.User.GetUserById(_u1.Id, GetRepository);
        }
 
        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            DeleteAllUsers();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_u1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_u2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_u1.Id == _u2.Id &&
                _u1.FirstName == _u2.FirstName &&
                _u1.LastName == _u2.LastName &&
                _u1.Deleted == _u2.Deleted &&
                _u1.Active == _u2.Active &&
                _u1.UserName == _u2.UserName &&
                _u1.Password == _u2.Password &&
                _u1.ContactId == _u2.ContactId);
        }
    }
}
