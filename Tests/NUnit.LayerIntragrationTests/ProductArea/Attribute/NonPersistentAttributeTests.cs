using NUnit.Framework;
using Utilites;
using BL = OrderInvoice_BL.Products;

namespace NUnit.LayerIntragrationTests.ProductArea.Attribute
{
    [TestFixture]
    class NonPersistentAttributeTests : TestBase
    {
        BL.Attribute _attri;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _attri = new BL.Attribute(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_attri.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_attri.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_attri.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Name property
        /// </summary>
        [Test]
        public void InitNameTest()
        {
            Assert.AreEqual(string.Empty, _attri.Name);
        }

        /// <summary>
        /// Test the initial state of the Description property
        /// </summary>
        [Test]
        public void InitDescriptionTest()
        {
            Assert.AreEqual(string.Empty, _attri.Description);
        }
    }
}
