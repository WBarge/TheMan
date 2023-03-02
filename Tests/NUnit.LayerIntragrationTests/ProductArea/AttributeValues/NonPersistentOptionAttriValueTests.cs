using NUnit.Framework;
using OrderInvoice_BL.Products;
using Utilites;

namespace NUnit.LayerIntragrationTests.ProductArea.AttributeValues
{
    [TestFixture]
    class NonPersistentOptionAttriValueTests : TestBase
    {
        OptionAttributeValue _optionAttrVal;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _optionAttrVal = new OptionAttributeValue(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_optionAttrVal.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_optionAttrVal.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_optionAttrVal.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Description property
        /// </summary>
        [Test]
        public void InitDescription()
        {
            Assert.AreEqual(_optionAttrVal.Description, string.Empty);
        }
    }
}
