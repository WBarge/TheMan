using NUnit.Framework;
using Utilites;

namespace NUnit.LayerIntragrationTests.ProductArea.Product
{
    [TestFixture]
    class PersistentProductTests : TestBase
    {
        OrderInvoice_BL.Products.Product _product1;
        OrderInvoice_BL.Products.Product _product2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _product1 = new OrderInvoice_BL.Products.Product(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            _product1.Save();

            _product2 = OrderInvoice_BL.Products.Product.GetById(_product1.Id,GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
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
            Assert.IsTrue(_product2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_product1.Id == _product2.Id && 
                _product1.Name == _product2.Name &&
                _product1.Description == _product2.Description &&
                _product1.Deleted == _product2.Deleted);
        }

    }
}
