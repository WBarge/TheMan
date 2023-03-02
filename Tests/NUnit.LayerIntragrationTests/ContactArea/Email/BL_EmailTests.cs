using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.Email
{
    [TestFixture]
    class BlEmailTests : TestBase
    {
        OrderInvoice_BL.Contacts.Contact _c;
        EmailAddress _email;
        const string TestEmailAddress = @"kittycandyy@yahoo.com";

        /// <summary>
        /// Setup object for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _c = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case1"
            };
            _c.Save();

            _email = _c.AddEmailAddress(TestEmailAddress);
        }

        /// <summary>
        /// Remove records from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            if (_email.IsNotEmpty())
            {
                _email.PermanentlyRemoveFromSystem();
            }
            List<EmailAddress> extraRecords = EmailAddress.GetAll(true, GetRepository);
            foreach (EmailAddress emailAddress in extraRecords)
            {
                emailAddress.PermanentlyRemoveFromSystem();
            }

            List<OrderInvoice_BL.Contacts.Contact> contacts = OrderInvoice_BL.Contacts.Contact.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Contacts.Contact contact in contacts)
            {
                contact.PermanentlyRemoveFromSystem();
            }
        }

        /// <summary>
        /// Test marking an obj as deleted
        /// </summary>
        [Test]
        public void DeletionTest()
        {
            _email.Delete();

            EmailAddress obj = EmailAddress.GetById(_email.Id, GetRepository);
            Assert.IsTrue(obj.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            _email.Delete();
            _c.AddEmailAddress(@"tester@hotmail.com");

            List<EmailAddress> results = EmailAddress.GetAll(GetRepository);
            Assert.IsTrue(results.Count == 1);
        }

        /// <summary>
        /// Test getting all records including deleted ones
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            _email.Delete();
            _c.AddEmailAddress(@"tester@hotmail.com");

            List<EmailAddress> results = EmailAddress.GetAll(true, GetRepository);
            Assert.Greater(results.Count, 1);
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void DeletionNotAllowedOnUnsavedObjectTest()
        {
            EmailAddress testObj = new EmailAddress(GetRepository);
            Assert.Throws<DataException>(() => testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            EmailAddress testObj = new EmailAddress(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        /// <summary>
        /// insure we get a throw when too long of a Address is is entered
        /// </summary>
        [Test]
        public void AddressValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _email.Address = "12345678901234567890123456789012345678901234567890"+
                "12345678901234567890123456789012345678901234567890"+
                "12345678901234567890123456789012345678901234567890"+
                "12345678901234567890123456789012345678901234567890"+
                "12345678901234567890123456789012345678901234567890"+
                "123456");
        }
    }
}
