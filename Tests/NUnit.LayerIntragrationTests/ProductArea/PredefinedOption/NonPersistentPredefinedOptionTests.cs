using NUnit.Framework;
using Utilites;
using BL = OrderInvoice_BL.Products;

namespace NUnit.LayerIntragrationTests.ProductArea.PredefinedOption
{
    [TestFixture]
    public class NonPersistentPredefinedOptionTests : TestBase
    {
        BL.Product _p;
        BL.PredefinedProduct _pp;
        BL.ProductOption _o;
        BL.PredefinedOption _po;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _p = new BL.Product(GetRepository);
            _pp = new BL.PredefinedProduct(GetRepository, _p);
            _o = new BL.ProductOption(GetRepository);
            _po = new BL.PredefinedOption(GetRepository, _pp, _o);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_po.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_po.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_po.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Description property
        /// </summary>
        [Test]
        public void InitDescriptionTest()
        {
            Assert.AreEqual(string.Empty, _po.Description);
        }
    }
}
