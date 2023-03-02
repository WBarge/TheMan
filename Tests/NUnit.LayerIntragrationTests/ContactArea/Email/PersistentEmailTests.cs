using System.Collections.Generic;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.Email
{
    [TestFixture]
    class PersistentEmailTests : TestBase
    {
        EmailAddress _email;
        const string TestEmailAddress = @"kittycandyy@yahoo.com";

        /// <summary>
        /// Setup oject for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            OrderInvoice_BL.Contacts.Contact c = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case1"
            };
            c.Save();

            _email = c.AddEmailAddress(TestEmailAddress);
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
            List<EmailAddress> extraRecords = EmailAddress.GetAll(true,GetRepository);
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
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_email.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            var email2 = EmailAddress.GetById(_email.Id, GetRepository);
            Assert.IsTrue(email2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            var email2 = EmailAddress.GetById(_email.Id, GetRepository);

            Assert.IsTrue(_email.Id == email2.Id &&
                _email.Address == email2.Address &&
                _email.Deleted == email2.Deleted);
        }
    }
}
