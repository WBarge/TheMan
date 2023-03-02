using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.PhoneNumberType
{
    [TestFixture]
    class NonPersistentPhoneNumberTypeTests : TestBase
    {
        OrderInvoice_BL.Contacts.PhoneNumberType _pnt;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _pnt = new OrderInvoice_BL.Contacts.PhoneNumberType(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_pnt.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_pnt.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_pnt.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Type property
        /// </summary>
        [Test]
        public void InitTypeTest()
        {
            Assert.AreEqual(_pnt.Type, PhoneType.None);
        }
    }
}
