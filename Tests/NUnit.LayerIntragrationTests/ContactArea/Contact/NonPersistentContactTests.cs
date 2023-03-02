using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.Contact
{
    [TestFixture]
    class NonPersistentContactTests : TestBase
    {
        OrderInvoice_BL.Contacts.Contact _contact;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _contact = new OrderInvoice_BL.Contacts.Contact(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_contact.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_contact.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_contact.Deleted);
        }

        /// <summary>
        /// Test the initial state of the FirstName property
        /// </summary>
        [Test]
        public void InitFirstNameTest()
        {
            Assert.AreEqual(_contact.FirstName, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the LastName property
        /// </summary>
        [Test]
        public void InitLastNameTest()
        {
            Assert.AreEqual(_contact.LastName, string.Empty);
        }
    }
}
