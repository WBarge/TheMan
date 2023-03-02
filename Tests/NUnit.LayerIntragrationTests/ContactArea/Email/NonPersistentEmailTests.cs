using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.Email
{
    [TestFixture]
    class NonPersistentEmailTests : TestBase
    {
        EmailAddress _email;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _email = new EmailAddress(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_email.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_email.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_email.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Address property
        /// </summary>
        [Test]
        public void InitAdressTest()
        {
            Assert.AreEqual(_email.Address, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the IsDefault property
        /// </summary>
        [Test]
        public void InitIsDefaultTest()
        {
            Assert.IsFalse(_email.IsDefault);
        }
    }
}
