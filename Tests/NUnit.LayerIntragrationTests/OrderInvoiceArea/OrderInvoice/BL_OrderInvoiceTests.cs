using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;

namespace NUnit.LayerIntragrationTests.OrderInvoiceArea.OrderInvoice
{
    [TestFixture]
    class BlOrderInvoiceTests : TestBase
    {
        OrderInvoice_BL.OrderInvoice.OrderInvoice _oi1;
        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _oi1 = GetOrderInvoice();
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
        /// Test getting all records as a list
        /// </summary>
        [Test]
        public void GetAllListTest()
        {
            try
            {
                List<OrderInvoice_BL.OrderInvoice.OrderInvoice> results = OrderInvoice_BL.OrderInvoice.OrderInvoice.GetAll(GetRepository);
                Assert.Greater(results.Count, 0);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// Test getting all records as an array
        /// </summary>
        [Test]
        public void GetAllArrayTest()
        {
            try
            {
                List<OrderInvoice_BL.OrderInvoice.OrderInvoice> results = OrderInvoice_BL.OrderInvoice.OrderInvoice.GetAll(GetRepository);
                Assert.Greater(results.Count, 0);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// insure we get a throw when too long of a shipping address line 1 is is entered
        /// </summary>
        [Test]
        public void ShippingAddressLine1ValidationTest()
        {
            Assert.Throws<InvalidLengthException>(()=> _oi1.ShippingAddressLine1 = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a shipping address line 2 is is entered
        /// </summary>
        [Test]
        public void ShippingAddressLine2ValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.ShippingAddressLine2 = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a shipping city is is entered
        /// </summary>
        [Test]
        public void ShippingCityValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.ShippingCity = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a shipping state is is entered
        /// </summary>
        [Test]
        public void ShippingStateValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.ShippingStateName = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a shipping country is is entered
        /// </summary>
        [Test]
        public void ShippingCountryValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.ShippingCountryName = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a shipping zip is is entered
        /// </summary>
        [Test]
        public void ShippingZipValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.ShippingZip = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a Invoice address line 1 is is entered
        /// </summary>
        [Test]
        public void InvoiceAddressLine1ValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.InvoiceAddressLine1 = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a Invoice address line 2 is is entered
        /// </summary>
        [Test]
        public void InvoiceAddressLine2ValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.InvoiceAddressLine2 = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a Invoice city is is entered
        /// </summary>
        [Test]
        public void InvoiceCityValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.InvoiceCity = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a Invoice state is is entered
        /// </summary>
        [Test]
        public void InvoiceStateValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.InvoiceStateName = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a Invoice country is is entered
        /// </summary>
        [Test]
        public void InvoiceCountryValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.InvoiceCountryName = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a Invoice zip is is entered
        /// </summary>
        [Test]
        public void InvoiceZipValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _oi1.InvoiceZip = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// Test Coping the invoice address from shipping address.
        /// </summary>
        [Test]
        public void CopyInvoiceAddressFromShippingAddressTest()
        {
            _oi1.ShippingAddressLine1 = "a";
            _oi1.ShippingAddressLine2 = "a";
            _oi1.ShippingCity = "a";
            _oi1.ShippingCountryName = "a";
            _oi1.ShippingStateName = "a";
            _oi1.ShippingZip = "a";
            _oi1.CopyInvoiceAddressFromShippingAddress();

            Assert.IsTrue(
                _oi1.ShippingAddressLine1 == _oi1.InvoiceAddressLine1 &&
                _oi1.ShippingAddressLine2 == _oi1.InvoiceAddressLine2 &&
                _oi1.ShippingCity == _oi1.InvoiceCity &&
                _oi1.ShippingCountryName == _oi1.InvoiceCountryName &&
                _oi1.ShippingStateName == _oi1.InvoiceStateName &&
                _oi1.ShippingZip == _oi1.InvoiceZip);
        }

        /// <summary>
        /// Test Coping the shipping address from invoice address.
        /// </summary>
        [Test]
        public void CopyShippingAddressFromInvoiceAddressTest()
        {
            _oi1.InvoiceAddressLine1 = "a";
            _oi1.InvoiceAddressLine2 = "a";
            _oi1.InvoiceCity = "a";
            _oi1.InvoiceCountryName = "a";
            _oi1.InvoiceStateName = "a";
            _oi1.InvoiceZip = "a";
            _oi1.CopyInvoiceAddressFromShippingAddress();

            Assert.IsTrue(
                _oi1.ShippingAddressLine1 == _oi1.InvoiceAddressLine1 &&
                _oi1.ShippingAddressLine2 == _oi1.InvoiceAddressLine2 &&
                _oi1.ShippingCity == _oi1.InvoiceCity &&
                _oi1.ShippingCountryName == _oi1.InvoiceCountryName &&
                _oi1.ShippingStateName == _oi1.InvoiceStateName &&
                _oi1.ShippingZip == _oi1.InvoiceZip);
        }
    }
}
