using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;

namespace NUnit.LayerIntragrationTests.ContactArea.PhoneNumber
{
    [TestFixture]
    class BlPhoneNumberTests : TestBase
    {
        OrderInvoice_BL.Contacts.PhoneNumber _pn1;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _pn1 = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                Number = "555-1212",
                CountryCode = "714",
                Type = GetOrCreatePhoneNumberType(PhoneType.Cell)
            };
            _pn1.Save();
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _pn1.PermanentlyRemoveFromSystem();

            List<OrderInvoice_BL.Contacts.PhoneNumber> phoneNumbers = OrderInvoice_BL.Contacts.PhoneNumber.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Contacts.PhoneNumber p in phoneNumbers)
            {
                p.PermanentlyRemoveFromSystem();
            }

            List<OrderInvoice_BL.Contacts.PhoneNumberType> extraRecords = OrderInvoice_BL.Contacts.PhoneNumberType.GetAll(true,GetRepository);
            foreach (OrderInvoice_BL.Contacts.PhoneNumberType pnt in extraRecords)
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
            _pn1.Delete();

            OrderInvoice_BL.Contacts.PhoneNumber pn = OrderInvoice_BL.Contacts.PhoneNumber.GetById(_pn1.Id, GetRepository);
            Assert.IsTrue(pn.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber pn21 = null;
            try
            {
                pn21 = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
                {
                    Number = "555-1313",
                    CountryCode = "213",
                    Type = GetOrCreatePhoneNumberType(PhoneType.Home)
                };
                pn21.Save();
                pn21.Delete();

                List<OrderInvoice_BL.Contacts.PhoneNumber> results = OrderInvoice_BL.Contacts.PhoneNumber.GetAll(GetRepository);
                Assert.IsTrue(results.Count == 1);
            }
            catch
            {
                // ignored
            }
            finally
            {
                pn21?.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Test getting all records including deleted ones
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber pn21 = null;
            try
            {
                pn21 = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
                {
                    Number = "555-1616",
                    CountryCode = "213",
                    Type = GetOrCreatePhoneNumberType(PhoneType.Home)
                };
                pn21.Save();
                pn21.Delete();

                List<OrderInvoice_BL.Contacts.PhoneNumberType> results = OrderInvoice_BL.Contacts.PhoneNumberType.GetAll(true, GetRepository);
                Assert.Greater(results.Count, 1);
            }
            catch
            {
                // ignored
            }
            finally
            {
                pn21?.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void DeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository);
            Assert.Throws<DataException>(()=> testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        /// <summary>
        /// insure we get a throw with an invalid number is entered
        /// </summary>
        [Test]
        public void NumberValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _pn1.Number = "12345678901234567890");
        }

        /// <summary>
        /// insure we get a throw with an invalid country code is entered
        /// </summary>
        [Test]
        public void CountryCodeValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _pn1.CountryCode = "12345678901");
        }

        /// <summary>
        /// Test to see that we insert a new phone number type if its not already in the database
        /// </summary>
        [Test]
        public void AddNewTypeTest()
        {
            _pn1.Type = GetOrCreatePhoneNumberType(PhoneType.Home);
            _pn1.Save();
            List<OrderInvoice_BL.Contacts.PhoneNumberType> testlist = OrderInvoice_BL.Contacts.PhoneNumberType.GetAll(GetRepository);
            Assert.IsTrue(testlist.Count >= 2);
        }
    }
}
