using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.PeopleArea.Employee
{
    [TestFixture]
    class BlEmployeeTests : TestBase
    {
        const string EmailAddy = @"TestCase@addy.net";

        OrderInvoice_BL.People.Employee _e1;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _e1 = GetTestEmployee();
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            var extraRecords = OrderInvoice_BL.People.Employee.GetAllEmployees(GetRepository, true, true);
            foreach (OrderInvoice_BL.People.Employee employee in extraRecords)
            {
                var tempPhoneNumbers = employee.GetPhoneNumbers(true);
                foreach (PhoneNumber phoneNumber in tempPhoneNumbers)
                {
                    _e1.RemovePhoneNumber(phoneNumber);
                }
                var tempSnailMail = employee.GetAllAddresses(true);
                foreach (SnailMailAddress snailMail in tempSnailMail)
                {
                    _e1.RemoveAddress(snailMail);
                }
            }

            List<SnailMailAddress> snailMailes = SnailMailAddress.GetAll(true, GetRepository);
            foreach (SnailMailAddress pnt in snailMailes)
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

            List<EmailAddress> tEa = EmailAddress.GetAll(true, GetRepository);
            foreach (EmailAddress emailAddy in tEa)
            {
                emailAddy.PermanentlyRemoveFromSystem();
            }

            List<PhoneNumber> tPn = PhoneNumber.GetAll(true, GetRepository);
            foreach (PhoneNumber phoneNumber in tPn)
            {
                phoneNumber.PermanentlyRemoveFromSystem();
            }
            List<PhoneNumberType> tPt = PhoneNumberType.GetAll(true, GetRepository);
            foreach (PhoneNumberType phoneType in tPt)
            {
                phoneType.PermanentlyRemoveFromSystem();
            }

            DeleteAllEmployees();
        }

        [Test]
        public void PasswordIsEncryptedTest()
        {
            Assert.AreNotEqual(InitialPassword, _e1.Password);
        }

        /// <summary>
        /// Test marking an obj as deleted
        /// </summary>
        [Test]
        public void DeletionTest()
        {
            _e1.Delete();

            Contact obj = Contact.GetById(_e1.ContactId, GetRepository);
            Assert.IsTrue(obj.Deleted);
            OrderInvoice_BL.People.User uObj = OrderInvoice_BL.People.User.GetUserById(_e1.Id, GetRepository);
            Assert.IsTrue(uObj.Deleted);
            OrderInvoice_BL.People.Employee eObj = OrderInvoice_BL.People.Employee.GetEmployeeById(_e1.Id, GetRepository);
            Assert.IsTrue(eObj.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            _e1.Delete();

            List<OrderInvoice_BL.People.Employee> results =
                OrderInvoice_BL.People.Employee.GetAllEmployees(GetRepository);
            Assert.IsTrue(results.Count == 0);
        }

        /// <summary>
        /// Test getting all records including deleted ones
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            _e1.Delete();

            List<OrderInvoice_BL.People.Employee> results =
                OrderInvoice_BL.People.Employee.GetAllEmployees(GetRepository, true, true);
            Assert.Greater(results.Count, 0);
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void DeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.People.Employee testObj = new OrderInvoice_BL.People.Employee(GetRepository);
            Assert.Throws<DataException>(()=> testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            OrderInvoice_BL.People.Employee testObj = new OrderInvoice_BL.People.Employee(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        /// <summary>
        /// insure we get a throw when too long of a First Name is is entered
        /// </summary>
        [Test]
        public void FirstNameValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _e1.FirstName = "12345678901234567890123456789012345678901234567890" +
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
            Assert.Throws<InvalidLengthException>(() => _e1.LastName = "12345678901234567890123456789012345678901234567890" +
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
            Assert.Throws<InvalidParameterException>(() => _e1.AddPhoneNumber(null));
        }

        /// <summary>
        /// you can not add a phone number that has not been set up
        /// correct.  I.E. not all maditory field on the number have set
        /// </summary>
        [Test]
        public void AddNewlyCreatedPhoneNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _e1.AddPhoneNumber(testObj));
        }

        /// <summary>
        /// The phone number does not need to be saved to the db
        /// before the 
        /// </summary>
        [Test]
        public void AddWithoutSavingPhoneNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            _e1.AddPhoneNumber(testObj);
            List<PhoneNumber> phoneNumbers = PhoneNumber.GetAll(GetRepository);
            Assert.AreEqual(phoneNumbers.Count, 1);
            PhoneNumber[] numbers = _e1.GetPhoneNumbers();
            Assert.AreEqual(numbers.Length, 1);
        }

        /// <summary>
        /// Add a phone number to the contact
        /// </summary>
        [Test]
        public void AddPhoneNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            _e1.AddPhoneNumber(testObj);
            List<PhoneNumber> phoneNumbers = PhoneNumber.GetAll(GetRepository);
            Assert.AreEqual(phoneNumbers.Count, 1);
            PhoneNumber[] numbers = _e1.GetPhoneNumbers();
            Assert.AreEqual(numbers.Length, 1);
        }

        /// <summary>
        /// Test Getting a phone number that has been added to the contact
        /// </summary>
        [Test]
        public void GetPhoneNumber1Test()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            _e1.AddPhoneNumber(testObj);
            PhoneNumber[] phoneNumbers = _e1.GetPhoneNumbers();
            Assert.AreEqual(1, phoneNumbers.Length);
            Assert.AreEqual(testObj.Id, phoneNumbers[0].Id);
        }

        /// <summary>
        /// Test Getting a phone number that has been added to the contact
        /// </summary>
        [Test]
        public void GetPhoneNumber2Test()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            _e1.AddPhoneNumber(testObj);
            PhoneNumber[] phoneNumbers = _e1.GetPhoneNumbers(false);
            Assert.AreEqual(1, phoneNumbers.Length);
            Assert.AreEqual(testObj.Id, phoneNumbers[0].Id);
        }

        /// <summary>
        /// Test Getting a phone number that has been added to the contact
        /// </summary>
        [Test]
        public void GetDeletedPhoneNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            testObj.Delete();
            _e1.AddPhoneNumber(testObj);
            PhoneNumber[] phoneNumbers = _e1.GetPhoneNumbers(true);
            Assert.AreEqual(1, phoneNumbers.Length);
            Assert.AreEqual(testObj.Id, phoneNumbers[0].Id);
        }

        /// <summary>
        /// When a default number has not been set the GetDefaultNumber should return NULL
        /// </summary>
        [Test]
        public void GetDefaultNumberWhenNoneIsSetTest()
        {
            PhoneNumber pn = _e1.GetDefaultNumber();
            Assert.IsTrue(pn.IsEmpty());
        }

        /// <summary>
        /// Test to see the default number for a contact is being set
        /// </summary>
        [Test]
        public void SetDefaultNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            _e1.AddPhoneNumber(testObj);

            PhoneNumber additionalNumber = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "2135551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Work)
            };
            additionalNumber.Save();
            _e1.AddPhoneNumber(additionalNumber);

            bool didItSet = _e1.SetDefaultNumber(testObj);
            PhoneNumber defaultNumber = _e1.GetDefaultNumber();
            Assert.AreEqual(testObj.Id, defaultNumber.Id);
            Assert.IsTrue(didItSet);
        }

        /// <summary>
        /// you can not set the default number to null
        /// </summary>
        [Test]
        public void SetDefaultNumberToNullTest()
        {
            Assert.Throws<InvalidParameterException>(()=> _e1.SetDefaultNumber(null));
        }

        /// <summary>
        /// The contact has to be saved before you can set the default number
        /// </summary>
        [Test]
        public void SetDefaultNumberOnNewCreatedContactTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();

            OrderInvoice_BL.People.Employee testEmployee = new OrderInvoice_BL.People.Employee(GetRepository);
            Assert.Throws<RequiredFieldException>(()=> testEmployee.SetDefaultNumber(testObj));
        }

        /// <summary>
        /// The phone number has to be saved before it can 
        /// set to default number
        /// </summary>
        [Test]
        public void SetDefaultNumberOnNewCreatedPhoneNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            OrderInvoice_BL.People.Employee testEmployee = new OrderInvoice_BL.People.Employee(GetRepository);
            Assert.Throws<ClassDependencyException>(() => testEmployee.SetDefaultNumber(testObj));
        }

        /// <summary>
        /// The default number can not be deleted number
        /// </summary>
        [Test]
        public void SetDefaultNumberOnDeletedPhoneNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            testObj.Delete();

            OrderInvoice_BL.People.Employee testEmployee = GetTestEmployee();
            Assert.Throws<ClassDependencyException>(() => testEmployee.SetDefaultNumber(testObj));
        }

        /// <summary>
        /// Test removing a phone number from a contact
        /// </summary>
        [Test]
        public void RemovePhoneNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            _e1.AddPhoneNumber(testObj);
            bool wasPhoneNumberRemoved = _e1.RemovePhoneNumber(testObj);
            PhoneNumber[] phoneNumbers = _e1.GetPhoneNumbers();
            Assert.AreEqual(0, phoneNumbers.Length);
            Assert.IsTrue(wasPhoneNumberRemoved);
        }

        /// <summary>
        /// you can not remove a null phone number from a contact
        /// </summary>
        [Test]
        public void RemoveNullPhoneNumberTest()
        {
            Assert.Throws<InvalidParameterException>(() => _e1.RemovePhoneNumber(null));
        }

        /// <summary>
        /// The phone number has to be saved before it can be removed
        /// </summary>
        [Test]
        public void RemoveUnsavedPhoneNumberTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            Assert.Throws<ClassDependencyException>(() => _e1.RemovePhoneNumber(testObj));
            PhoneNumber[] phoneNumbers = _e1.GetPhoneNumbers();
            Assert.AreEqual(0, phoneNumbers.Length);
        }

        /// <summary>
        /// The remove phone number can not remove a number
        /// that was not added to the contact
        /// </summary>
        [Test]
        public void RemovePhoneThatHasNotBeedAddedTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();
            bool wasPhoneNumberRemoved = _e1.RemovePhoneNumber(testObj);
            Assert.IsFalse(wasPhoneNumberRemoved);
        }

        /// <summary>
        /// You can not remove a phone number from a contact
        /// that has not been saved
        /// </summary>
        [Test]
        public void RemovePhoneNumberOnNewCreatedContactTest()
        {
            PhoneNumber testObj = new PhoneNumber(GetRepository)
            {
                CountryCode = "1",
                Number = "7145551212",
                Type = GetOrCreatePhoneNumberType(PhoneType.Home)
            };
            testObj.Save();

            OrderInvoice_BL.People.Employee testEmployee = new OrderInvoice_BL.People.Employee(GetRepository);
            Assert.Throws<RequiredFieldException>(()=> testEmployee.RemovePhoneNumber(testObj));
        }

        #endregion Add Phone Number To Contact Tests

        #region Add Email Address to Contact Tests

        /// <summary>
        /// you can not add an null object to the add email address
        /// </summary>
        [Test]
        public void AddNullEmailAddressTest()
        {
            Assert.Throws<InvalidParameterException>(() => _e1.AddEmailAddress(null));
        }

        /// <summary>
        /// you can not add an empty string to the add email address
        /// </summary>
        [Test]
        public void AddEmptyStringEmailAddressTest()
        {
            Assert.Throws<InvalidParameterException>(() => _e1.AddEmailAddress(string.Empty));
        }

        /// <summary>
        /// Add a email address to the contact
        /// </summary>
        [Test]
        public void AddEmailTest()
        {
            EmailAddress addedAddy = _e1.AddEmailAddress(EmailAddy);
            Assert.IsTrue(addedAddy.IsNotEmpty());
            List<EmailAddress> addresses = EmailAddress.GetAll(GetRepository);
            Assert.AreEqual(addresses.Count, 1);
            EmailAddress[] addys = _e1.GetAllEmailAddresses();
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
            EmailAddress addedAddy = _e1.AddEmailAddress(EmailAddy);
            addedAddy.Delete();
            EmailAddress[] emailAddresses = _e1.GetAllEmailAddresses(true);
            Assert.AreEqual(1, emailAddresses.Length);
            Assert.AreEqual(addedAddy.Id, emailAddresses[0].Id);
        }

        /// <summary>
        /// Test to see the email address for a contact is being set
        /// </summary>
        [Test]
        public void SetDefaultEmailTest()
        {
            EmailAddress addedAddy = _e1.AddEmailAddress(EmailAddy);
            Assert.IsTrue(addedAddy.IsDefault);

            EmailAddress additionAddy = _e1.AddEmailAddress(@"second@hotmail.com");
            Assert.IsFalse(additionAddy.IsDefault);

            bool didItSet = _e1.SetDefaultEMailAddress(additionAddy);
            Assert.IsTrue(didItSet);

            EmailAddress defaultAddress = _e1.GetDefaultEMailAddress();
            Assert.AreEqual(additionAddy.Id, defaultAddress.Id);
        }

        /// <summary>
        /// Test the contact has a default email address
        /// </summary>
        [Test]
        public void HasDefaultEmailTest()
        {
            EmailAddress addedAddy = _e1.AddEmailAddress(EmailAddy);
            Assert.IsTrue(addedAddy.IsDefault);
            Assert.IsTrue(_e1.HasDefaultEmailAddress());
        }

        /// <summary>
        /// you can not set the default address to null
        /// </summary>
        [Test]
        public void SetDefaultAddressToNullTest()
        {
            Assert.Throws<InvalidParameterException>(() => _e1.SetDefaultEMailAddress(null));
        }

        /// <summary>
        /// The contact has to be saved before you can set the default address
        /// </summary>
        [Test]
        public void SetDefaultAddressOnNewCreatedContactTest()
        {
            OrderInvoice_BL.People.Employee testEmployee = new OrderInvoice_BL.People.Employee(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            EmailAddress testAddy = new EmailAddress(GetRepository)
            {
                Address = @"second@hotmail.com"
            };
            Assert.Throws<RequiredFieldException>(() => testEmployee.SetDefaultEMailAddress(testAddy));
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
            Assert.Throws<ClassDependencyException>(() => _e1.SetDefaultEMailAddress(testAddy));
        }


        /// <summary>
        /// The default email address can not be deleted address
        /// </summary>
        [Test]
        public void SetDefaultAddressOnDeletedEmailAddressTest()
        {
            EmailAddress addedAddy = _e1.AddEmailAddress(EmailAddy);
            Assert.IsTrue(addedAddy.IsDefault);

            EmailAddress additionAddy = _e1.AddEmailAddress(@"second@hotmail.com");
            Assert.IsFalse(additionAddy.IsDefault);
            additionAddy.Delete();

            Assert.Throws<ClassDependencyException>(() => _e1.SetDefaultEMailAddress(additionAddy));
        }

        /// <summary>
        /// Test removing a email address from a contact
        /// </summary>
        [Test]
        public void RemoveEmailAddressTest()
        {
            EmailAddress addedAddy = _e1.AddEmailAddress(EmailAddy);
            addedAddy.Delete();
            EmailAddress[] emailAddys = _e1.GetAllEmailAddresses();
            Assert.AreEqual(0, emailAddys.Length);
        }

        /// <summary>
        /// Test removing a email address from a contact
        /// </summary>
        [Test]
        public void PermanetRemoveEmailAddress1Test()
        {
            EmailAddress addedAddy = _e1.AddEmailAddress(EmailAddy);
            addedAddy.PermanentlyRemoveFromSystem();
            EmailAddress[] emailAddys = _e1.GetAllEmailAddresses();
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
            Assert.Throws<InvalidParameterException>(() => _e1.AddAddress(null));
        }

        /// <summary>
        /// you can not add a snail mail address that has not set
        /// up correctly
        /// </summary>
        [Test]
        public void AddNewlyCreatedSnailMailAddressTest()
        {
            SnailMailAddress sma1 = new SnailMailAddress(GetRepository);
            Assert.Throws<RequiredFieldException>(() => _e1.AddAddress(sma1));
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
            _e1.AddAddress(sma1);
            List<SnailMailAddress> snailMailAddressList = SnailMailAddress.GetAll(GetRepository);
            Assert.AreEqual(snailMailAddressList.Count, 1);
            SnailMailAddress[] snailMailAddresses = _e1.GetAllAddresses();
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
            _e1.AddAddress(sma1);
            List<SnailMailAddress> snailMailAddressList = SnailMailAddress.GetAll(GetRepository);
            Assert.AreEqual(snailMailAddressList.Count, 1);
            SnailMailAddress[] snailMailAddresses = _e1.GetAllAddresses();
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
            _e1.AddAddress(sma1);

            SnailMailAddress[] snailMailAddresses = _e1.GetAllAddresses();
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
            _e1.AddAddress(sma1);

            SnailMailAddress[] snailMailAddresses = _e1.GetAllAddresses(false);
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
            _e1.AddAddress(sma1);
            sma1.Delete();

            SnailMailAddress[] snailMailAddresses = _e1.GetAllAddresses(true);
            Assert.AreEqual(1, snailMailAddresses.Length);
            Assert.AreEqual(sma1.Id, snailMailAddresses[0].Id);
        }

        /// <summary>
        /// When a default snail mail address has not been set the GetDefaultAddress should return NULL
        /// </summary>
        [Test]
        public void GetDefaultSnailMailAddressWhenNoneIsSetTest()
        {
            SnailMailAddress pn = _e1.GetDefaultAddress();
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
            _e1.AddAddress(testObj);

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
            _e1.AddAddress(sma1);

            bool didItSet = _e1.SetDefaultAddress(testObj);
            SnailMailAddress defaultNumber = _e1.GetDefaultAddress();
            Assert.AreEqual(testObj.Id, defaultNumber.Id);
            Assert.IsTrue(didItSet);
        }

        /// <summary>
        /// you can not set the default snail mail address to null
        /// </summary>
        [Test]
        public void SetDefaultSnailMailAddressToNullTest()
        {
            Assert.Throws<InvalidParameterException>(() => _e1.SetDefaultAddress(null));
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
            _e1.AddAddress(testObj);

            OrderInvoice_BL.People.Employee testEmployee = new OrderInvoice_BL.People.Employee(GetRepository)
            {
                FirstName = "Test",
                LastName = "Case2"
            };
            Assert.Throws<RequiredFieldException>(() => testEmployee.SetDefaultAddress(testObj));
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
            OrderInvoice_BL.People.Employee testEmployee = GetTestEmployee();
            Assert.Throws<ClassDependencyException>(() => testEmployee.SetDefaultAddress(testObj));
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

            OrderInvoice_BL.People.Employee testEmployee = GetTestEmployee();
            Assert.Throws<ClassDependencyException>(() => testEmployee.SetDefaultAddress(testObj));
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
            _e1.AddAddress(testObj);
            bool wasAddressRemoved = _e1.RemoveAddress(testObj);
            SnailMailAddress[] addresses = _e1.GetAllAddresses();
            Assert.AreEqual(0, addresses.Length);
            Assert.IsTrue(wasAddressRemoved);
        }

        /// <summary>
        /// you can not remove a null snail mail address from a contact
        /// </summary>
        [Test]
        public void RemoveNullSnailMailAddressTest()
        {
            Assert.Throws<InvalidParameterException>(() => _e1.RemoveAddress(null));
        }

        /// <summary>
        /// The snail mail address has to be saved before it can be removed
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
            Assert.Throws<ClassDependencyException>(() => _e1.RemoveAddress(testObj));
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
            Assert.IsFalse(_e1.RemoveAddress(testObj));
        }

        /// <summary>
        /// You can not remove a phone number from a contact
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

            OrderInvoice_BL.People.Employee testEmployee = new OrderInvoice_BL.People.Employee(GetRepository);
            Assert.Throws<RequiredFieldException>(() => testEmployee.RemoveAddress(testObj));
        }

        #endregion Snail Mail Address To Contact Tests
    }
 }
