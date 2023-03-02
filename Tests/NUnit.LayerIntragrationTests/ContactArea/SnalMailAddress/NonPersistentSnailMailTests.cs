using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.SnalMailAddress
{
    [TestFixture]
    class NonPersistentSnailMailTests : TestBase
    {
        SnailMailAddress _address;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _address = new SnailMailAddress(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_address.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_address.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_address.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Line1 property
        /// </summary>
        [Test]
        public void InitAdressLine1()
        {
            Assert.AreEqual(_address.Line1, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the Line2 property
        /// </summary>
        [Test]
        public void InitAdressLine2()
        {
            Assert.AreEqual(_address.Line2, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the City property
        /// </summary>
        [Test]
        public void InitAdressCity()
        {
            Assert.AreEqual(_address.City, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the Type property
        /// </summary>
        [Test]
        public void InitAdressType()
        {
            Assert.AreEqual(_address.Type, null);
        }

    }
}
