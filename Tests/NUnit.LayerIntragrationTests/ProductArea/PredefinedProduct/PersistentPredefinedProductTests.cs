using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.ProductArea.PredefinedProduct
{
    [TestFixture]
    class PersistentPredefinedProductTests : TestBase
    {
        OrderInvoice_BL.Products.Product _product1;
        OrderInvoice_BL.Products.PredefinedProduct _predefinedProduct1;
        OrderInvoice_BL.Products.PredefinedProduct _predefinedProduct2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _product1 = CreateProduct();
            _predefinedProduct1 = CreatePredefinedProduct(_product1);
            _predefinedProduct2 = OrderInvoice_BL.Products.PredefinedProduct.GetById(_predefinedProduct1.Id, GetRepository);
        }

      

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _predefinedProduct1.PermanentlyRemoveFromSystem();
            _product1.PermanentlyRemoveFromSystem();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_product1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_predefinedProduct2.Id.IsNotEmpty());
            
        }

        /// <summary>
        /// Test the Default value of quantity which should be set by the BO.
        /// If the BO sets it to null then the DB should set it to 1
        /// </summary>
        [Test]
        public void DefaultValueOfQuantity()
        {
            Assert.IsTrue(_predefinedProduct2.Quantity == 1); // we are
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_predefinedProduct1.Id == _predefinedProduct2.Id &&
                _predefinedProduct1.ProductId == _predefinedProduct2.ProductId &&
                _product1.Id == _predefinedProduct1.ProductId &&
                _product1.Id == _predefinedProduct2.ProductId &&
                _predefinedProduct1.Price == _predefinedProduct2.Price &&
                _predefinedProduct1.Description == _predefinedProduct2.Description &&
                _predefinedProduct1.Deleted == _predefinedProduct2.Deleted);
        }

    }
}
