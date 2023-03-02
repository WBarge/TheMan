using NUnit.Framework;
using Utilites;
using BL = OrderInvoice_BL.Products;

namespace NUnit.LayerIntragrationTests.ProductArea.Attribute
{
    [TestFixture]
    class PersistentAttributeTests : TestBase
    {
        BL.Attribute _attri1;
        BL.Attribute _attri2;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _attri1 = new BL.Attribute(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            _attri1.Save();

            _attri2 = BL.Attribute.GetById(_attri1.Id,GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _attri1.PermanentlyRemoveFromSystem();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_attri1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_attri2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_attri1.Id == _attri2.Id &&
                _attri1.Name == _attri2.Name &&
                _attri1.Description == _attri2.Description &&
                _attri1.Deleted == _attri2.Deleted);
        }
    }
}
