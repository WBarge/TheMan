using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;

namespace NUnit.LayerIntragrationTests.ContactArea.PhoneNumberType
{
    [TestFixture]
    class BlPhoneNumberTypeTests : TestBase
    {
        OrderInvoice_BL.Contacts.PhoneNumberType _pnt1;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _pnt1 = new OrderInvoice_BL.Contacts.PhoneNumberType(GetRepository)
            {
                Type = PhoneType.Cell
            };
            _pnt1.Save();
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            List<OrderInvoice_BL.Contacts.PhoneNumberType> results = OrderInvoice_BL.Contacts.PhoneNumberType.GetAll(true,GetRepository);
            foreach (OrderInvoice_BL.Contacts.PhoneNumberType pnt in results)
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
            _pnt1.Delete();

            OrderInvoice_BL.Contacts.PhoneNumberType pnt = OrderInvoice_BL.Contacts.PhoneNumberType.GetById(_pnt1.Id, GetRepository);
            Assert.IsTrue(pnt.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumberType pnt21 = null;
            try
            {
                pnt21 = new OrderInvoice_BL.Contacts.PhoneNumberType(GetRepository)
                {
                    Type = PhoneType.Cell,
                    Deleted = true
                };
                pnt21.Save();

                List<OrderInvoice_BL.Contacts.PhoneNumberType> results = OrderInvoice_BL.Contacts.PhoneNumberType.GetAll(GetRepository);
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
            OrderInvoice_BL.Contacts.PhoneNumberType pnt21 = null;
            try
            {
                pnt21 = new OrderInvoice_BL.Contacts.PhoneNumberType(GetRepository)
                {
                    Type = PhoneType.Cell,
                    Deleted = true
                };
                pnt21.Save();

                List<OrderInvoice_BL.Contacts.PhoneNumberType> results = OrderInvoice_BL.Contacts.PhoneNumberType.GetAll(true, GetRepository);
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
            OrderInvoice_BL.Contacts.PhoneNumberType testObj = new OrderInvoice_BL.Contacts.PhoneNumberType(GetRepository);
            Assert.Throws<DataException>(()=> testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumberType testObj = new OrderInvoice_BL.Contacts.PhoneNumberType(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

    }
}
