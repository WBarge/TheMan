using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.OrderInvoiceArea.OrderInvoice
{
    [TestFixture]
    class PersistentOrderInvoiceTests : TestBase
    {
        OrderInvoice_BL.OrderInvoice.OrderInvoice _oi1;
        OrderInvoice_BL.OrderInvoice.OrderInvoice _oi2;
        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _oi1 = GetOrderInvoice();
            _oi2 = OrderInvoice_BL.OrderInvoice.OrderInvoice.GetById(_oi1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            DeleteAllOrderInvoices();
            DeleteAllCustomers();
            DeleteAllEmployees();
            DeleteAllUsers();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_oi1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_oi2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_oi1.Id == _oi2.Id &&
                _oi1.CustomerId == _oi2.CustomerId &&
                _oi1.EmployeeId == _oi2.EmployeeId &&
                _oi1.OrderInvoiceNumber == _oi2.OrderInvoiceNumber &&
                _oi1.ShippingAddressLine1 == _oi2.ShippingAddressLine1 &&
                _oi1.ShippingAddressLine2 == _oi2.ShippingAddressLine2 &&
                _oi1.ShippingCity == _oi2.ShippingCity &&
                _oi1.ShippingCountryName == _oi2.ShippingCountryName &&
                _oi1.ShippingStateName == _oi2.ShippingStateName &&
                _oi1.ShippingZip == _oi2.ShippingZip &&
                _oi1.InvoiceAddressLine1 == _oi2.InvoiceAddressLine1 &&
                _oi1.InvoiceAddressLine2 == _oi2.InvoiceAddressLine2 &&
                _oi1.InvoiceCity == _oi2.InvoiceCity &&
                _oi1.InvoiceCountryName == _oi2.InvoiceCountryName &&
                _oi1.InvoiceStateName == _oi2.InvoiceStateName &&
                _oi1.InvoiceZip == _oi2.InvoiceZip &&
                _oi1.SubTotal == _oi2.SubTotal &&
                _oi1.TaxRate == _oi2.TaxRate &&
                _oi1.TaxAmount == _oi2.TaxAmount &&
                _oi1.Total == _oi2.Total &&
                _oi1.Note == _oi2.Note);
        }
    }
}
