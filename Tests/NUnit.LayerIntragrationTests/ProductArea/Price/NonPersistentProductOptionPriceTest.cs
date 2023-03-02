using System;
using NUnit.Framework;
using OrderInvoice_BL.Products;
using Utilites;

namespace NUnit.LayerIntragrationTests.ProductArea.Price
{
    [TestFixture]
    class NonPersistentProductOptionPriceTest : TestBase
    {
        OptionPrice _prodOptPrice;

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _prodOptPrice = new OptionPrice(GetRepository);
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_prodOptPrice.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the ID property
        /// </summary>
        [Test]
        public void InitIdTest()
        {
            Assert.AreEqual(_prodOptPrice.Id, DefaultValues.DefaultInt);
        }

        /// <summary>
        /// Test the initial state of the Deleted property
        /// </summary>
        [Test]
        public void InitDeletedTest()
        {
            Assert.IsFalse(_prodOptPrice.Deleted);
        }

        /// <summary>
        /// Test the initial state of the Start property
        /// </summary>
        [Test]
        public void InitStartTest()
        {
            Assert.AreEqual(_prodOptPrice.Start, DateTime.MaxValue);
        }
        /// <summary>
        /// Test the initial state of the End property
        /// </summary>
        [Test]
        public void InitEndTest()
        {
            Assert.AreEqual(_prodOptPrice.End, DateTime.MaxValue);
        }

        /// <summary>
        /// Test the initial state of the FlatPrice property
        /// </summary>
        [Test]
        public void InitFlatPriceTest()
        {
            Assert.AreEqual(_prodOptPrice.FlatPrice, decimal.Zero);
        }

    }
}
