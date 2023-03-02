using NUnit.Framework;
using Utilites;
using BL = OrderInvoice_BL.Products;

namespace NUnit.LayerIntragrationTests.ProductArea.ProductOption
{
    [TestFixture]
    class PersistentProductOptionTests : TestBase
    {
        BL.ProductOption _productOption1;
        BL.ProductOption _productOption2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _productOption1 = CreateOption();
            _productOption2 = BL.ProductOption.GetById(_productOption1.Id,GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _productOption1.PermanentlyRemoveFromSystem();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_productOption1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_productOption2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_productOption1.Id == _productOption2.Id &&
                _productOption1.Name == _productOption2.Name &&
                _productOption1.Description == _productOption2.Description &&
                _productOption1.Deleted == _productOption2.Deleted);
        }

    }
}
