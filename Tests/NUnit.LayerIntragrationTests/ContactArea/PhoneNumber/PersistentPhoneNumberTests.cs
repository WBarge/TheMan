using System.Collections.Generic;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.PhoneNumber
{
    [TestFixture]
    class PersistentPhoneNumberTests : TestBase
    {
        OrderInvoice_BL.Contacts.PhoneNumber _pn1;
        OrderInvoice_BL.Contacts.PhoneNumber _pn2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _pn1 = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                Number = "555-1212",
                CountryCode = "714",
                Type = GetOrCreatePhoneNumberType(PhoneType.Cell)
            };
            _pn1.Save();

            _pn2 = OrderInvoice_BL.Contacts.PhoneNumber.GetById(_pn1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _pn1.PermanentlyRemoveFromSystem();

            List<OrderInvoice_BL.Contacts.PhoneNumberType> extraRecords = OrderInvoice_BL.Contacts.PhoneNumberType.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Contacts.PhoneNumberType pnt in extraRecords)
            {
                pnt.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_pn1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_pn2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_pn1.Id == _pn2.Id &&
                _pn1.Number == _pn2.Number &&
                _pn1.CountryCode == _pn2.CountryCode &&
                _pn1.Deleted == _pn2.Deleted &&
                _pn1.Type.Type == _pn2.Type.Type);
        }

    }
}
