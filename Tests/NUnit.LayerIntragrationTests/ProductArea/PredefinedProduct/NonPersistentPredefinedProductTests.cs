using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.ProductArea.PredefinedProduct
{
    [TestFixture]
    class NonPersistentPredefinedProductTests : TestBase
    {
        OrderInvoice_BL.Products.Product _p;
        OrderInvoice_BL.Products.PredefinedProduct _pp;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _p = new OrderInvoice_BL.Products.Product(GetRepository);
            _pp = new OrderInvoice_BL.Products.PredefinedProduct(GetRepository, _p);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_p.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_pp.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_pp.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Name property
        /// </summary>
        [Test]
        public void InitPriceTest()
        {
            Assert.AreEqual(decimal.Zero, _pp.Price);
        }

        /// <summary>
        /// Test the initial state of the Description property
        /// </summary>
        [Test]
        public void InitDescriptionTest()
        {
            Assert.AreEqual(string.Empty, _p.Description);
        }
    }
}
