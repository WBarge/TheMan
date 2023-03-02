using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.OrderInvoiceArea.CustomItemOption
{
    [TestFixture]
    class NonPersistentCustomItemOptionTests:TestBase
    {
        OrderInvoice_BL.OrderInvoice.CustomItemOption _oi;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _oi = new OrderInvoice_BL.OrderInvoice.CustomItemOption(GetRepository);
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
        public void InitProductOptionIdTest()
        {
            Assert.AreEqual(_oi.ProductOptionId, 0);
        }

        /// <summary>
        /// Test the initial state of the Attribute Value.
        /// </summary>
        [Test]
        public void InitNoteTest()
        {
            Assert.AreEqual(_oi.Note, string.Empty);
        }

    }
}
