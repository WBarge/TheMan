using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.OrderInvoiceArea.OrderInvoice
{
    [TestFixture]
    class NonPersistentOrderInvoiceTests:TestBase
    {
        OrderInvoice_BL.OrderInvoice.OrderInvoice _oi;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _oi = new OrderInvoice_BL.OrderInvoice.OrderInvoice(GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_oi.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_oi.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the order invoice customer.
        /// </summary>
        [Test]
        public void InitOrderInvoiceCustomerTest()
        {
            Assert.AreEqual(_oi.OrderInvoiceCustomer, null);
        }
        /// <summary>
        /// Test the initial state of the order invoice customer identifier.
        /// </summary>
        [Test]
        public void InitOrderInvoiceCustomerIdTest()
        {
            Assert.AreEqual(_oi.CustomerId, DefaultValues.DefaultInt);
        }
        /// <summary>
        /// Test the initial state of the order invoice employee.
        /// </summary>
        [Test]
        public void InitOrderInvoiceEmployeeTest()
        {
            Assert.AreEqual(_oi.OrderInvoiceEmployee, null);
        }
        /// <summary>
        /// Test the initial state of the order invoice employee identifier.
        /// </summary>
        [Test]
        public void InitOrderInvoiceEmployeeIdTest()
        {
            Assert.AreEqual(_oi.EmployeeId, DefaultValues.DefaultInt);
        }
        /// <summary>
        /// Test the initial state of the order number.
        /// </summary>
        [Test]
        public void InitOrderNumberTest()
        {
            Assert.AreEqual(_oi.OrderInvoiceNumber, long.MinValue);
        }
        /// <summary>
        /// Test the initial state of the shipping address line1.
        /// </summary>
        [Test]
        public void InitShippingAddressLine1Test()
        {
            Assert.AreEqual(_oi.ShippingAddressLine1, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the shipping address line2.
        /// </summary>
        [Test]
        public void InitShippingAddressLine2Test()
        {
            Assert.AreEqual(_oi.ShippingAddressLine2, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the shipping city.
        /// </summary>
        [Test]
        public void InitShippingCityTest()
        {
            Assert.AreEqual(_oi.ShippingCity, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the shipping state name.
        /// </summary>
        [Test]
        public void InitShippingStateNameTest()
        {
            Assert.AreEqual(_oi.ShippingStateName, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the shipping country name.
        /// </summary>
        [Test]
        public void InitShippingCountryNameTest()
        {
            Assert.AreEqual(_oi.ShippingCountryName, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the shipping zip.
        /// </summary>
        [Test]
        public void InitShippingZipTest()
        {
            Assert.AreEqual(_oi.ShippingZip, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the invoice address line1.
        /// </summary>
        [Test]
        public void InitInvoiceAddressLine1Test()
        {
            Assert.AreEqual(_oi.InvoiceAddressLine1, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the invoice address line2.
        /// </summary>
        [Test]
        public void InitInvoiceAddressLine2Test()
        {
            Assert.AreEqual(_oi.InvoiceAddressLine2, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the invoice city.
        /// </summary>
        [Test]
        public void InitInvoiceCityTest()
        {
            Assert.AreEqual(_oi.InvoiceCity, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the invoice state name.
        /// </summary>
        [Test]
        public void InitInvoiceStateNameTest()
        {
            Assert.AreEqual(_oi.InvoiceStateName, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the invoice country name.
        /// </summary>
        [Test]
        public void InitInvoiceCountryNameTest()
        {
            Assert.AreEqual(_oi.InvoiceCountryName, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the invoice zip.
        /// </summary>
        [Test]
        public void InitInvoiceZipTest()
        {
            Assert.AreEqual(_oi.InvoiceZip, string.Empty);
        }
        /// <summary>
        /// Test the initial state of the sub total.
        /// </summary>
        [Test]
        public void InitSubTotalTest()
        {
            Assert.AreEqual(_oi.SubTotal, decimal.Zero);
        }
        /// <summary>
        /// Test the initial state of the tax rate.
        /// </summary>
        [Test]
        public void InitTaxRateTest()
        {
            Assert.AreEqual(_oi.TaxRate, decimal.Zero);
        }
        /// <summary>
        /// Test the initial state of the tax amount.
        /// </summary>
        [Test]
        public void InitTaxAmountTest()
        {
            Assert.AreEqual(_oi.TaxAmount, decimal.Zero);
        }
        /// <summary>
        /// Test the initial state of the total.
        /// </summary>
        [Test]
        public void InitTotalTest()
        {
            Assert.AreEqual(_oi.Total, decimal.Zero);
        }
        /// <summary>
        /// Test the initial state of the note.
        /// </summary>
        [Test]
        public void InitNoteTest()
        {
            Assert.AreEqual(_oi.Note, string.Empty);
        }
    }
}
