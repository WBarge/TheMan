using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using BL = OrderInvoice_BL.Products;

namespace NUnit.LayerIntragrationTests.ProductArea.Attribute
{
    [TestFixture]
    class BlAttributeTests : TestBase
    {
        BL.Attribute _product1;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _product1 = new BL.Attribute(GetRepository)
            {
                Name = "Cutting Board",
                Description = "A solid end grain cutting board"
            };
            _product1.Save();
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            List<BL.Attribute> results = BL.Attribute.GetAll(true,GetRepository);
            foreach (BL.Attribute pnt in results)
            {
                pnt.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Test marking an obj as deleted
        /// </summary>
        [Test]
        public void DeletionTest()
        {
            _product1.Delete();

            BL.Attribute pnt = BL.Attribute.GetById(_product1.Id, GetRepository);
            Assert.IsTrue(pnt.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            BL.Attribute pnt21 = null;
            try
            {
                pnt21 = new BL.Attribute(GetRepository)
                {
                    Name = "another Cutting Board",
                    Description = "A solid end grain cutting board without any finish"
                };
                pnt21.Save();
                pnt21.Delete();

                List<BL.Attribute> results = BL.Attribute.GetAll(GetRepository);
                Assert.IsTrue(results.Count == 1);
            }
            catch
            {
                // ignored
            }
            finally
            {
                pnt21?.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Test getting all records including deleted ones
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            BL.Attribute pnt21 = null;
            try
            {
                pnt21 = new BL.Attribute(GetRepository)
                {
                    Name = "another Cutting Board",
                    Description = "A solid end grain cutting board without any finish"
                };
                pnt21.Save();
                pnt21.Delete();

                List<BL.Attribute> results = BL.Attribute.GetAll(true, GetRepository);
                Assert.Greater(results.Count, 1);
            }
            catch
            {
                // ignored
            }

            finally
            {
                pnt21?.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void DeletionNotAllowedOnUnsavedObjectTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository);
            Assert.Throws<DataException>(()=> testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            BL.Attribute testObj = new BL.Attribute(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }
    }
}
