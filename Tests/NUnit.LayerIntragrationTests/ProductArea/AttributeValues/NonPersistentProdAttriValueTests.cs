using NUnit.Framework;
using OrderInvoice_BL.Products;
using Utilites;

namespace NUnit.LayerIntragrationTests.ProductArea.AttributeValues
{
    [TestFixture]
    class NonPersistentProdAttriValueTests : TestBase
    {
        ProductAttributeValue _prodAttrVal;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _prodAttrVal = new ProductAttributeValue(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_prodAttrVal.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_prodAttrVal.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_prodAttrVal.Deleted);
        }

        /// <summary>
        /// Test the initial state of the ValueName property
        /// </summary>
        [Test]
        public void InitValueName()
        {
            Assert.AreEqual(_prodAttrVal.ValueName, string.Empty);
        }

        /// <summary>
        /// Test the initial state of the Description property
        /// </summary>
        [Test]
        public void InitDescription()
        {
            Assert.AreEqual(_prodAttrVal.Description, string.Empty);
        }
       
    }
}
