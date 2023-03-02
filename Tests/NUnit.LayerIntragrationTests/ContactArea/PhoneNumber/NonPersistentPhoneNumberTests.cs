using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.PhoneNumber
{
    [TestFixture]
    class NonPersistentPhoneNumberTests : TestBase
    {
        OrderInvoice_BL.Contacts.PhoneNumber _pn;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _pn = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_pn.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_pn.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_pn.Deleted);
        }

        /// <summary>
        /// Test the initial state of the number property
        /// </summary>
        [Test]
        public void InitNumberTest()
        {
            Assert.AreEqual(_pn.Number, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the CountryCode property
        /// </summary>
        [Test]
        public void InitCountryCodeTest()
        {
            Assert.AreEqual(_pn.CountryCode, string.Empty);
        }

    }
}
