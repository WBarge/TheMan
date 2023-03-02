using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.PhoneNumberType
{
    [TestFixture]
    class PersistentPhoneNumberTypeTests : TestBase
    {
        OrderInvoice_BL.Contacts.PhoneNumberType _pnt1;
        OrderInvoice_BL.Contacts.PhoneNumberType _pnt2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _pnt1 = new OrderInvoice_BL.Contacts.PhoneNumberType(GetRepository)
            {
                Type = PhoneType.Cell
            };
            _pnt1.Save();

            _pnt2 = OrderInvoice_BL.Contacts.PhoneNumberType.GetById(_pnt1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _pnt1.PermanentlyRemoveFromSystem();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_pnt1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_pnt2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_pnt1.Id == _pnt2.Id && _pnt1.Type == _pnt2.Type && _pnt1.Deleted == _pnt2.Deleted);
        }

    }
}
