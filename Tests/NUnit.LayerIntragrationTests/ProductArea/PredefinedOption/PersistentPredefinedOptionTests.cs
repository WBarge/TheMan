using NUnit.Framework;
using Utilites;
using BL = OrderInvoice_BL.Products;

namespace NUnit.LayerIntragrationTests.ProductArea.PredefinedOption
{
    [TestFixture]
    public class PersistentPredefinedOptionTests : TestBase
    {
        BL.Product _product1;
        BL.ProductOption _option1;
        BL.PredefinedProduct _predefinedProduct1;
        BL.PredefinedOption _predefinedOption;
        BL.PredefinedOption _testOption;
    
        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _product1 = CreateProduct();
            _option1 = CreateOption();
            _predefinedProduct1 = CreatePredefinedProduct(_product1);
            _predefinedOption = CreatePredefinedOption(_predefinedProduct1, _option1);
            _testOption = BL.PredefinedOption.GetById(_predefinedOption.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _predefinedOption.PermanentlyRemoveFromSystem();
            _predefinedProduct1.PermanentlyRemoveFromSystem();
            _option1.PermanentlyRemoveFromSystem();
            _product1.PermanentlyRemoveFromSystem();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_predefinedOption.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_testOption.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_predefinedOption.Id == _testOption.Id &&
                _predefinedOption.PredefinedProductId == _testOption.PredefinedProductId &&
                _option1.Id == _testOption.OptionId &&
                _predefinedOption.Description == _testOption.Description &&
                _predefinedOption.Deleted == _testOption.Deleted);
        }
    }
}
