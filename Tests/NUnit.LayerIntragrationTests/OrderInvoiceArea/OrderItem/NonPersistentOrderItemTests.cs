using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.OrderInvoiceArea.OrderItem
{
    [TestFixture]
    class NonPersistentOrderItemTests : TestBase
    {
        OrderInvoice_BL.OrderInvoice.OrderItem _oi;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _oi = new OrderInvoice_BL.OrderInvoice.OrderItem(GetRepository);
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
        /// Test the initial state of the order invoice Id.
        /// </summary>
        [Test]
        public void InitOrderInvoiceIdTest()
        {
            Assert.AreEqual(_oi.OrderInvoiceId, 0);
        }

        /// <summary>
        /// Test the initial state of the Predefined Product Id.
        /// </summary>
        [Test]
        public void InitPredefinedProductIdTest()
        {
            Assert.AreEqual(_oi.PredefinedProductId, null);
        }

        /// <summary>
        /// Test the initial state of the Product Id.
        /// </summary>
        [Test]
        public void InitProductIdTest()
        {
            Assert.AreEqual(_oi.ProductId, null);
        }

        /// <summary>
        /// Test the initial state of the Price.
        /// </summary>
        [Test]
        public void InitPriceTest()
        {
            Assert.AreEqual(_oi.Price, decimal.Zero);
        }
    }
}
