using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.OrderInvoiceArea.CustomItemAttribute
{
    [TestFixture]
    class NonPersistentCustomItemAttributeTests : TestBase
    {
        OrderInvoice_BL.OrderInvoice.CustomItemAttribute _oi;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _oi = new OrderInvoice_BL.OrderInvoice.CustomItemAttribute(GetRepository);
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
        /// Test the initial state of the order item Id.
        /// </summary>
        [Test]
        public void InitOrderItemIdTest()
        {
            Assert.AreEqual(_oi.OrderItemId, 0);
        }

        /// <summary>
        /// Test the initial state of the Attribute Id.
        /// </summary>
        [Test]
        public void InitAttributeIdTest()
        {
            Assert.AreEqual(_oi.AttributeId, 0);
        }

        /// <summary>
        /// Test the initial state of the Attribute Value.
        /// </summary>
        [Test]
        public void InitAttributeValueTest()
        {
            Assert.AreEqual(_oi.AttributeValue, string.Empty);
        }

    }
}
