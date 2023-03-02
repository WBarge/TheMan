using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.Contact
{
    [TestFixture]
    class BlContactTests : TestBase
    {
        const string EmailAddy = @"TestCase@addy.net";

        OrderInvoice_BL.Contacts.Contact _c1;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _c1 = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case"
            };
            _c1.Save();
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            var extraRecords = OrderInvoice_BL.Contacts.Contact.GetAll(true,GetRepository);
            foreach (OrderInvoice_BL.Contacts.Contact contact in extraRecords)
            {
                var tempPhoneNumbers = contact.GetPhoneNumbers(true);
                foreach (OrderInvoice_BL.Contacts.PhoneNumber phoneNumber in tempPhoneNumbers)
                {
                    _c1.RemovePhoneNumber(phoneNumber);
                }
                var tempSnailMail = contact.GetAllAddresses(true);
                foreach (SnailMailAddress snailMail in tempSnailMail)
                {
                    _c1.RemoveAddress(snailMail);
                }
            }

            List<SnailMailAddress> snailMails = SnailMailAddress.GetAll(true, GetRepository);
            foreach (SnailMailAddress pnt in snailMails)
            {
                pnt.PermanentlyRemoveFromSystem();
            }

            List<SnailMailType> types = SnailMailType.GetAll(GetRepository);
            foreach (SnailMailType snType in types)
            {
                snType.PermanentlyRemoveFromSystem();
            }

            List<Country> countries = Country.GetAll(GetRepository);
            foreach (Country country in countries)
            {
                country.PermanentlyRemoveFromSystem();
            }

            List<State> states = State.GetAll(GetRepository);
            foreach (State state in states)
            {
                state.PermanentlyRemoveFromSystem();
            }

            var tempEmailAddresses = EmailAddress.GetAll(true, GetRepository);
            foreach (EmailAddress emailAddy in tempEmailAddresses)
            {
                emailAddy.PermanentlyRemoveFromSystem();
            }

            List<OrderInvoice_BL.Contacts.PhoneNumber> pns = OrderInvoice_BL.Contacts.PhoneNumber.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Contacts.PhoneNumber phoneNumber in pns)
            {
                phoneNumber.PermanentlyRemoveFromSystem();
            }
            var tempPhoneTypes = OrderInvoice_BL.Contacts.PhoneNumberType.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Contacts.PhoneNumberType phoneType in tempPhoneTypes)
            {
                phoneType.PermanentlyRemoveFromSystem();
            }

            extraRecords = OrderInvoice_BL.Contacts.Contact.GetAll(true, GetRepository);
            foreach (OrderInvoice_BL.Contacts.Contact contact in extraRecords)
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
            _c1.Delete();

            OrderInvoice_BL.Contacts.Contact obj = OrderInvoice_BL.Contacts.Contact.GetById(_c1.Id, GetRepository);
            Assert.IsTrue(obj.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            _c1.Delete();

            List<OrderInvoice_BL.Contacts.Contact> results =
                OrderInvoice_BL.Contacts.Contact.GetAll(GetRepository);
            Assert.IsTrue(results.Count == 0);
        }

        /// <summary>
        /// Test getting all records including deleted ones
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            _c1.Delete();

            List<OrderInvoice_BL.Contacts.Contact> results =
                OrderInvoice_BL.Contacts.Contact.GetAll(true, GetRepository);
            Assert.Greater(results.Count, 0);
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void DeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.Contacts.Contact testObj = new OrderInvoice_BL.Contacts.Contact(GetRepository);
            Assert.Throws<DataException>(() => testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.Contacts.Contact testObj = new OrderInvoice_BL.Contacts.Contact(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        /// <summary>
        /// insure we get a throw when too long of a First Name is is entered
        /// </summary>
        [Test]
        public void FirstNameValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _c1.FirstName = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        /// <summary>
        /// insure we get a throw when too long of a Last Name is is entered
        /// </summary>
        [Test]
        public void LastNameValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _c1.LastName = "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "12345678901234567890123456789012345678901234567890" +
                "123456");
        }

        #region Add Phone Number To Contact Tests

        /// <summary>
        /// you can not add an null object to the add phone number
        /// i.e. you can not pass null to the add phone number
        /// </summary>
        [Test]
        public void AddNullPhoneTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.AddPhoneNumber(null));
        }

        /// <summary>
        /// you can not add a phone number that has not been set up
        /// correct.  I.E. not all maditory field on the number have set
        /// </summary>
        [Test]
        public void AddNewlyCreatedPhoneNumberTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _c1.AddPhoneNumber(testObj));
        }

        /// <summary>
        /// The phone number does not need to be saved to the db
        /// before the 
        /// </summary>
        [Test]
        public void AddWithoutSavingPhoneNumberTest()
        {

            OrderInvoice_BL.Contacts.PhoneNumber testObj =
                new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
                {
                    CountryCode = "1",
                    Number = "7145551212",
                    Type = GetOrCreatePhoneNumberType(PhoneType.Home)
                };
            _c1.AddPhoneNumber(testObj);
            List<OrderInvoice_BL.Contacts.PhoneNumber> phoneNumbers = OrderInvoice_BL.Contacts.PhoneNumber.GetAll(GetRepository);
            Assert.AreEqual(phoneNumbers.Count, 1);
            OrderInvoice_BL.Contacts.PhoneNumber[] numbers = _c1.GetPhoneNumbers();
            Assert.AreEqual(numbers.Length, 1);
        }

        /// <summary>
        /// Add a phone number to the contact
        /// </summary>
        [Test]
        public void AddPhoneNumberTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj =
                new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
                {
                    CountryCode = "1",
                    Number = "7145551212",
                    Type = GetOrCreatePhoneNumberType(PhoneType.Home)
                };
            testObj.Save();
            _c1.AddPhoneNumber(testObj);
            List<OrderInvoice_BL.Contacts.PhoneNumber> phoneNumbers = OrderInvoice_BL.Contacts.PhoneNumber.GetAll(GetRepository);
            Assert.AreEqual(phoneNumbers.Count, 1);
            OrderInvoice_BL.Contacts.PhoneNumber[] numbers = _c1.GetPhoneNumbers();
            Assert.AreEqual(numbers.Length, 1);
        }

        /// <summary>
        /// Test Getting a phone number that has been added to the contact
        /// </summary>
        [Test]
        public void GetPhoneNumber1Test()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj =
                new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
                {
                    CountryCode = "1",
                    Number = "7145551212",
                    Type = GetOrCreatePhoneNumberType(PhoneType.Home)
                };
            testObj.Save();
            _c1.AddPhoneNumber(testObj);
            OrderInvoice_BL.Contacts.PhoneNumber[] phoneNumbers = _c1.GetPhoneNumbers();
            Assert.AreEqual(1, phoneNumbers.Length);
            Assert.AreEqual(testObj.Id, phoneNumbers[0].Id);
        }

        /// <summary>
        /// Test Getting a phone number that has been added to the contact
        /// </summary>
        [Test]
        public void GetPhoneNumber2Test()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj =
                new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
                {
                    CountryCode = "1",
                    Number = "7145551212",
                    Type = GetOrCreatePhoneNumberType(PhoneType.Home)
                };
            testObj.Save();
            _c1.AddPhoneNumber(testObj);
            OrderInvoice_BL.Contacts.PhoneNumber[] phoneNumbers = _c1.GetPhoneNumbers(false);
            Assert.AreEqual(1, phoneNumbers.Length);
            Assert.AreEqual(testObj.Id, phoneNumbers[0].Id);
        }

        /// <summary>
        /// Test Getting a phone number that has been added to the contact
        /// </summary>
        [Test]
        public void GetDeletedPhoneNumberTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj =
                new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
                {
                    CountryCode = "1",
                    Number = "7145551212",
                    Type = GetOrCreatePhoneNumberType(PhoneType.Home)
                };
            testObj.Save();
            testObj.Delete();
            _c1.AddPhoneNumber(testObj);
            OrderInvoice_BL.Contacts.PhoneNumber[] phoneNumbers = _c1.GetPhoneNumbers(true);
            Assert.AreEqual(1, phoneNumbers.Length);
            Assert.AreEqual(testObj.Id, phoneNumbers[0].Id);
        }

        /// <summary>
        /// When a default number has not been set the GetDefaultNumber should return NULL
        /// </summary>
        [Test]
        public void GetDefaultNumberWhenNoneIsSetTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber pn = _c1.GetDefaultNumber();
            Assert.IsTrue(pn.IsEmpty());
        }

        /// <summary>
        /// Test to see the default number for a contact is being set
        /// </summary>
        [Test]
        public void SetDefaultNumberTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            _c1.AddPhoneNumber(testObj);

            OrderInvoice_BL.Contacts.PhoneNumber additionalNumber = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "2135551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Work)
            };
            additionalNumber.Save();
            _c1.AddPhoneNumber(additionalNumber);

            bool didItSet = _c1.SetDefaultNumber(testObj);
            OrderInvoice_BL.Contacts.PhoneNumber defaultNumber = _c1.GetDefaultNumber();
            Assert.AreEqual(testObj.Id, defaultNumber.Id);
            Assert.IsTrue(didItSet);
        }

        /// <summary>
        /// you can not set the default number to null
        /// </summary>
        [Test]
        public void SetDefaultNumberToNullTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.SetDefaultNumber(null));
        }

        /// <summary>
        /// The contact has to be saved before you can set the default number
        /// </summary>
        [Test]
        public void SetDefaultNumberOnNewCreatedContactTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();

            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            Assert.Throws<RequiredFieldException>(() => testContact.SetDefaultNumber(testObj));
        }

        /// <summary>
        /// The phone number has to be saved before it can 
        /// set to default number
        /// </summary>
        [Test]
        public void SetDefaultNumberOnNewCreatedPhoneNumberTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            testContact.Save();
            Assert.Throws<ClassDependencyException>(() => testContact.SetDefaultNumber(testObj));
        }

        /// <summary>
        /// The default number can not be deleted number
        /// </summary>
        [Test]
        public void SetDefaultNumberOnDeletedPhoneNumberTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            testObj.Delete();

            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            testContact.Save();
            Assert.Throws<ClassDependencyException>(() => testContact.SetDefaultNumber(testObj));
        }

        /// <summary>
        /// Test removing a phone number from a contact
        /// </summary>
        [Test]
        public void RemovePhoneNumberTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            _c1.AddPhoneNumber(testObj);
            bool wasPhoneNumberRemoved = _c1.RemovePhoneNumber(testObj);
            OrderInvoice_BL.Contacts.PhoneNumber[] phoneNumbers = _c1.GetPhoneNumbers();
            Assert.AreEqual(0, phoneNumbers.Length);
            Assert.IsTrue(wasPhoneNumberRemoved);
        }

        /// <summary>
        /// you can not remove a null phone number from a contact
        /// </summary>
        [Test]
        public void RemoveNullPhoneNumberTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.RemovePhoneNumber(null));
        }

        /// <summary>
        /// The phone number has to be saved before it can be removed
        /// </summary>
        [Test]
        public void RemoveUnsavedPhoneNumberTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            Assert.Throws<ClassDependencyException>(() => _c1.RemovePhoneNumber(testObj));
            OrderInvoice_BL.Contacts.PhoneNumber[] phoneNumbers = _c1.GetPhoneNumbers();
            Assert.AreEqual(0, phoneNumbers.Length);
        }

        /// <summary>
        /// The remove phone number can not remove a number
        /// that was not added to the contact
        /// </summary>
        [Test]
        public void RemovePhoneThatHasNotBeedAddedTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            bool wasPhoneNumberRemoved = _c1.RemovePhoneNumber(testObj);
            Assert.IsFalse(wasPhoneNumberRemoved);
        }

        /// <summary>
        /// You can not remove a phone number from a contact
        /// that has not been saved
        /// </summary>
        [Test]
        public void RemovePhoneNumberOnNewCreatedContactTest()
        {
            OrderInvoice_BL.Contacts.PhoneNumber testObj = new OrderInvoice_BL.Contacts.PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();

            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            Assert.Throws<RequiredFieldException>(() => testContact.RemovePhoneNumber(testObj));
        }

        #endregion Add Phone Number To Contact Tests

        #region Add Email Address to Contact Tests

        /// <summary>
        /// you can not add an null object to the add email address
        /// </summary>
        [Test]
        public void AddNullEmailAddressTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.AddEmailAddress(null));
        }

        /// <summary>
        /// you can not add an empty string to the add email address
        /// </summary>
        [Test]
        public void AddEmptyStringEmailAddressTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.AddEmailAddress(string.Empty));
        }

        /// <summary>
        /// Add a email address to the contact
        /// </summary>
        [Test]
        public void AddEmailTest()
        {
            EmailAddress addedAddy = _c1.AddEmailAddress(EmailAddy);
            Assert.IsTrue(addedAddy.IsNotEmpty());
            List<EmailAddress> addresses = EmailAddress.GetAll(GetRepository);
            Assert.AreEqual(addresses.Count, 1);
            EmailAddress[] addys = _c1.GetAllEmailAddresses();
            Assert.AreEqual(addys.Length, 1);
            Assert.AreEqual(addedAddy.Id, addys[0].Id);
        }

        /// <summary>
        /// Test Getting a email address that has been added to the contact
        /// and then deleted
        /// </summary>
        [Test]
        public void GetDeletedEmailAddressTest()
        {
            EmailAddress addedAddy = _c1.AddEmailAddress(EmailAddy);
            addedAddy.Delete();
            EmailAddress[] emailAddresses = _c1.GetAllEmailAddresses(true);
            Assert.AreEqual(1, emailAddresses.Length);
            Assert.AreEqual(addedAddy.Id, emailAddresses[0].Id);
        }

        /// <summary>
        /// Test to see the email address for a contact is being set
        /// </summary>
        [Test]
        public void SetDefaultEmailTest()
        {
            EmailAddress addedAddy = _c1.AddEmailAddress(EmailAddy);
            Assert.IsTrue(addedAddy.IsDefault);

            EmailAddress additionAddy = _c1.AddEmailAddress(@"second@hotmail.com");
            Assert.IsFalse(additionAddy.IsDefault);

            bool didItSet = _c1.SetDefaultEMailAddress(additionAddy);
            Assert.IsTrue(didItSet);

            EmailAddress defaultAddress = _c1.GetDefaultEMailAddress();
            Assert.AreEqual(additionAddy.Id, defaultAddress.Id);
        }

        /// <summary>
        /// Test the contact has a default email address
        /// </summary>
        [Test]
        public void HasDefaultEmailTest()
        {
            EmailAddress addedAddy = _c1.AddEmailAddress(EmailAddy);
            Assert.IsTrue(addedAddy.IsDefault);
            Assert.IsTrue(_c1.HasDefaultEmailAddress());
        }

        /// <summary>
        /// you can not set the default address to null
        /// </summary>
        [Test]
        public void SetDefaultAddressToNullTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.SetDefaultEMailAddress(null));
        }

        /// <summary>
        /// The contact has to be saved before you can set the default address
        /// </summary>
        [Test]
        public void SetDefaultAddressOnNewCreatedContactTest()
        {
            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            EmailAddress testAddy = new EmailAddress(GetRepository)
            {
                Address = @"second@hotmail.com"
            };
            Assert.Throws<RequiredFieldException>(() => testContact.SetDefaultEMailAddress(testAddy));
        }

        /// <summary>
        /// The has to be add using the add email address method
        /// off the contact
        /// </summary>
        [Test]
        public void SetDefaultAddressOnNewCreatedEmailTest()
        {
            EmailAddress testAddy = new EmailAddress(GetRepository)
            {
                Address = @"second@hotmail.com"
            };
            Assert.Throws<ClassDependencyException>(() => _c1.SetDefaultEMailAddress(testAddy));
        }

        
        /// <summary>
        /// The default email address can not be deleted address
        /// </summary>
        [Test]
        public void SetDefaultAddressOnDeletedEmailAddressTest()
        {
            EmailAddress addedAddy = _c1.AddEmailAddress(EmailAddy);
            Assert.IsTrue(addedAddy.IsDefault);

            EmailAddress additionAddy = _c1.AddEmailAddress(@"second@hotmail.com");
            Assert.IsFalse(additionAddy.IsDefault);
            additionAddy.Delete();

            Assert.Throws<ClassDependencyException>(() => _c1.SetDefaultEMailAddress(additionAddy));
        }

        /// <summary>
        /// Test removing a email address from a contact
        /// </summary>
        [Test]
        public void RemoveEmailAddressTest()
        {
            EmailAddress addedAddy = _c1.AddEmailAddress(EmailAddy);
            addedAddy.Delete();
            EmailAddress[] emailAddys = _c1.GetAllEmailAddresses();
            Assert.AreEqual(0, emailAddys.Length);
        }

        /// <summary>
        /// Test removing a email address from a contact
        /// </summary>
        [Test]
        public void PermanetRemoveEmailAddress1Test()
        {
            EmailAddress addedAddy = _c1.AddEmailAddress(EmailAddy);
            addedAddy.PermanentlyRemoveFromSystem();
            EmailAddress[] emailAddys = _c1.GetAllEmailAddresses();
            Assert.AreEqual(0, emailAddys.Length);
        }


        #endregion Add Email Address to Contact Tests

        #region Snail Mail Address To Contact Tests

        /// <summary>
        /// you can not add an null object to the add address
        /// i.e. you can not pass null to the add address
        /// </summary>
        [Test]
        public void AddNullSnailMailAddressTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.AddAddress(null));
        }

        /// <summary>
        /// you can not add a snail mail address that has not set
        /// up correctly
        /// </summary>
        [Test]
        public void AddNewlyCreatedSnailMailAddressTest()
        {
            SnailMailAddress sma1 = new SnailMailAddress(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _c1.AddAddress(sma1));
        }

        /// <summary>
        /// The Snail Mail Address does not need to be saved to the db
        /// before being added to the contact
        /// </summary>
        [Test]
        public void AddWithoutSavingSnailMailAddressTest()
        {
            SnailMailAddress sma1 = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            _c1.AddAddress(sma1);
            List<SnailMailAddress> snailMailAddressList = SnailMailAddress.GetAll(GetRepository);
            Assert.AreEqual(snailMailAddressList.Count, 1);
            SnailMailAddress[] snailMailAddresses = _c1.GetAllAddresses();
            Assert.AreEqual(snailMailAddresses.Length, 1);
        }

        /// <summary>
        /// Add a snail mail address to the contact
        /// </summary>
        [Test]
        public void AddSnailMailAddressTest()
        {
            SnailMailAddress sma1 = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            sma1.Save();
            _c1.AddAddress(sma1);
            List<SnailMailAddress> snailMailAddressList = SnailMailAddress.GetAll(GetRepository);
            Assert.AreEqual(snailMailAddressList.Count, 1);
            SnailMailAddress[] snailMailAddresses = _c1.GetAllAddresses();
            Assert.AreEqual(snailMailAddresses.Length, 1);
        }

        /// <summary>
        /// Test Getting a snail mail address that has been added to the contact
        /// </summary>
        [Test]
        public void GetSnailMailAddress1Test()
        {
            SnailMailAddress sma1 = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            sma1.Save();
            _c1.AddAddress(sma1);

            SnailMailAddress[] snailMailAddresses = _c1.GetAllAddresses();
            Assert.AreEqual(1, snailMailAddresses.Length);
            Assert.AreEqual(sma1.Id, snailMailAddresses[0].Id);
        }

        /// <summary>
        /// Test Getting a snail mail address that has been added to the contact
        /// </summary>
        [Test]
        public void GetSnailMailAddress2Test()
        {
            SnailMailAddress sma1 = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            sma1.Save();
            _c1.AddAddress(sma1);

            SnailMailAddress[] snailMailAddresses = _c1.GetAllAddresses(false);
            Assert.AreEqual(1, snailMailAddresses.Length);
            Assert.AreEqual(sma1.Id, snailMailAddresses[0].Id);
        }

        /// <summary>
        /// Test Getting a snail mail address that has been added to the contact
        /// the snail mail address has to be a deleted address for this test
        /// </summary>
        [Test]
        public void GetDeletedSnailMailAddressTest()
        {
            SnailMailAddress sma1 = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            sma1.Save();
            _c1.AddAddress(sma1);
            sma1.Delete();

            SnailMailAddress[] snailMailAddresses = _c1.GetAllAddresses(true);
            Assert.AreEqual(1, snailMailAddresses.Length);
            Assert.AreEqual(sma1.Id, snailMailAddresses[0].Id);
        }

        /// <summary>
        /// When a default snail mail address has not been set the GetDefaultAddress should return NULL
        /// </summary>
        [Test]
        public void GetDefaultSnailMailAddressWhenNoneIsSetTest()
        {
            SnailMailAddress pn = _c1.GetDefaultAddress();
            Assert.IsTrue(pn.IsEmpty());
        }

        /// <summary>
        /// Test to see the default snail address for a contact is being set
        /// </summary>
        [Test]
        public void SetDefaultSnailMailAddressTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            testObj.Save();
            _c1.AddAddress(testObj);

            SnailMailAddress sma1 = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            sma1.Save();
            _c1.AddAddress(sma1);

            bool didItSet = _c1.SetDefaultAddress(testObj);
            SnailMailAddress defaultNumber = _c1.GetDefaultAddress();
            Assert.AreEqual(testObj.Id, defaultNumber.Id);
            Assert.IsTrue(didItSet);
        }

        /// <summary>
        /// you can not set the default snail mail address to null
        /// </summary>
        [Test]
        public void SetDefaultSnailMailAddressToNullTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.SetDefaultAddress(null));
        }

        /// <summary>
        /// The contact has to be saved before you can set the default number
        /// </summary>
        [Test]
        public void SetDefaultSnailMailAddressOnNewCreatedContactTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            testObj.Save();
            _c1.AddAddress(testObj);

            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            Assert.Throws<RequiredFieldException>(() => testContact.SetDefaultAddress(testObj));
        }

        /// <summary>
        /// The snail mail address has to be saved before it can 
        /// set to default address
        /// </summary>
        [Test]
        public void SetDefaultSnailMailAddressOnNewCreatedPhoneNumberTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            testContact.Save();
            Assert.Throws<ClassDependencyException>(() => testContact.SetDefaultAddress(testObj));
        }

        /// <summary>
        /// The default address can not be a deleted snail mail address
        /// </summary>
        [Test]
        public void SetDefaultAddressOnDeletedSnailMailAddressTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            testObj.Save();
            testObj.Delete();

            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            testContact.Save();
            Assert.Throws<ClassDependencyException>(() => testContact.SetDefaultAddress(testObj));
        }

        /// <summary>
        /// Test removing a Snail Mail Address from a contact
        /// </summary>
        [Test]
        public void RemoveSnailMailAddressTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            testObj.Save();
            _c1.AddAddress(testObj);
            bool wasAddressRemoved = _c1.RemoveAddress(testObj);
            SnailMailAddress[] addresses = _c1.GetAllAddresses();
            Assert.AreEqual(0, addresses.Length);
            Assert.IsTrue(wasAddressRemoved);
        }

        /// <summary>
        /// you can not remove a null snail mail address from a contact
        /// </summary>
        [Test]
        public void RemoveNullSnailMailAddressTest()
        {
            Assert.Throws<InvalidParameterException>(() => _c1.RemoveAddress(null));
        }

        /// <summary>
        /// The snail mail address has to be saved before it can be removed
        /// i.e you can not remove it if it has not been added
        /// </summary>
        [Test]
        public void RemoveUnsavedSnailMailAddressTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            Assert.Throws<ClassDependencyException>(() => _c1.RemoveAddress(testObj));
        }

        /// <summary>
        /// The remove address can not remove a snail mail address
        /// that was not added to the contact
        /// </summary>
        [Test]
        public void RemoveSnailMailAddressThatHasNotBeenAddedTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            testObj.Save();
            Assert.IsFalse(_c1.RemoveAddress(testObj));
        }

        /// <summary>
        /// You can not remove a snail mail address from a contact
        /// that has not been saved
        /// </summary>
        [Test]
        public void RemoveSnailMailAddressOnNewCreatedContactTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            testObj.Save();

            OrderInvoice_BL.Contacts.Contact testContact = new OrderInvoice_BL.Contacts.Contact(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            Assert.Throws<RequiredFieldException>(() => testContact.RemoveAddress(testObj));
        }

        #endregion Snail Mail Address To Contact Tests
    }
}
