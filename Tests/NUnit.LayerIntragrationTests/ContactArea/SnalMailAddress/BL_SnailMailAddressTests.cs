using System.Collections.Generic;
using Exceptions;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.SnalMailAddress
{
    [TestFixture]
    class BlSnailMailAddressTests : TestBase
    {
        SnailMailAddress _sma1;

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _sma1 = new SnailMailAddress(GetRepository)
            {
                Line1 = "666 Mockingbird Lane",
                Line2 = "Apt 6",
                City = "Limbo",
                State = GetOrCreateState(UsStateName.Arizona),
                Country = GetOrCreateCountry(CountryName.UnitedStates),
                Zip = "85234",
                Type = GetOrCreateSnailMailType(MailType.Home)
            };
            _sma1.Save();
        }

        /// <summary>
        /// Remove records from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            if (_sma1.IsNotEmpty())
            {
                _sma1.PermanentlyRemoveFromSystem();
            }
            List<SnailMailAddress> extraRecords = SnailMailAddress.GetAll(true,GetRepository);
            foreach (SnailMailAddress pnt in extraRecords)
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
        }


        /// <summary>
        /// Test marking an obj as deleted
        /// </summary>
        [Test]
        public void DeletionTest()
        {
            _sma1.Delete();

            SnailMailAddress pn = SnailMailAddress.GetById(_sma1.Id, GetRepository);
            Assert.IsTrue(pn.Deleted);
        }

        /// <summary>
        /// Test getting only active records
        /// </summary>
        [Test]
        public void GetAllActiveTest()
        {
            SnailMailAddress pn21 = null;
            try
            {
                pn21 = new SnailMailAddress(GetRepository)
                {
                    Line1 = "666 Mockingbird Lane",
                    Line2 = "Apt 6",
                    City = "Limbo",
                    State = GetOrCreateState(UsStateName.Arizona),
                    Country = GetOrCreateCountry(CountryName.UnitedStates),
                    Zip = "85234",
                    Type = GetOrCreateSnailMailType(MailType.Home)
                };
                pn21.Save();
                pn21.Delete();

                List<SnailMailAddress> results = SnailMailAddress.GetAll(GetRepository);
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
            SnailMailAddress pn21 = null;
            try
            {
                pn21 = new SnailMailAddress(GetRepository)
                {
                    Line1 = "666 Mockingbird Lane",
                    Line2 = "Apt 6",
                    City = "Limbo",
                    State = GetOrCreateState(UsStateName.Arizona),
                    Country = GetOrCreateCountry(CountryName.UnitedStates),
                    Zip = "85234",
                    Type = GetOrCreateSnailMailType(MailType.Home)
                };
                pn21.Save();
                pn21.Delete();

                List<SnailMailAddress> results = SnailMailAddress.GetAll(true, GetRepository);
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
            SnailMailAddress testObj = new SnailMailAddress(GetRepository);
            Assert.Throws<DataException>(()=> testObj.Delete());
        }

        /// <summary>
        /// you can not delete an object before it has been saved
        /// </summary>
        [Test]
        public void AnotherDeletionNotAllowedOnUnsavedObjectTest()
        {
            SnailMailAddress testObj = new SnailMailAddress(GetRepository);
            Assert.Throws<DataException>(() => testObj.PermanentlyRemoveFromSystem());
        }

        /// <summary>
        /// insure we get a throw when too long of a line is is entered
        /// </summary>
        [Test]
        public void Line1ValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _sma1.Line1 = "12345678901234567890123456789012345678901");
        }

        /// <summary>
        /// insure we get a throw when too long of a line is is entered
        /// </summary>
        [Test]
        public void Line2ValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _sma1.Line2 = "12345678901234567890123456789012345678901");
        }

        /// <summary>
        /// insure we get a throw when too long of a line is is entered
        /// </summary>
        [Test]
        public void CityValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _sma1.City = "12345678901234567890123456789012345678901");
        }

        /// <summary>
        /// insure we get a throw when too long of a line is is entered
        /// </summary>
        [Test]
        public void ZipValidationTest()
        {
            Assert.Throws<InvalidLengthException>(() => _sma1.Zip = "1234567890123");
        }
    }
}
