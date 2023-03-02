using NUnit.Framework;
using Utilites;
using BL = OrderInvoice_BL.Products;

namespace NUnit.LayerIntragrationTests.ProductArea.ProductOption
{
    [TestFixture]
    class NonPersistentProductOptionTests : TestBase
    {
        BL.ProductOption _p;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _p = new BL.ProductOption(GetRepository);
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
            Assert.AreEqual(_p.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_p.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Name property
        /// </summary>
        [Test]
        public void InitNameTest()
        {
            Assert.AreEqual(string.Empty, _p.Name);
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
