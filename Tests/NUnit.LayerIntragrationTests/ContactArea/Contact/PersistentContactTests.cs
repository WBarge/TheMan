using System.Collections.Generic;
using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.Contact
{
    [TestFixture]
    class PersistentContactTests : TestBase
    {
        OrderInvoice_BL.Contacts.Contact _c1;
        OrderInvoice_BL.Contacts.Contact _c2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _c1 = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case"
            };
            _c1.Save();

            _c2 = OrderInvoice_BL.Contacts.Contact.GetById(_c1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _c1.PermanentlyRemoveFromSystem();

            List<OrderInvoice_BL.Contacts.Contact> extraRecords = OrderInvoice_BL.Contacts.Contact.GetAll(true,GetRepository);
            foreach (OrderInvoice_BL.Contacts.Contact contact in extraRecords)
            {
                contact.PermanentlyRemoveFromSystem();
            }
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
                _c1.Deleted == _c2.Deleted);
        }
    }
}
