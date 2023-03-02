using System.Collections.Generic;
using NUnit.Framework;
using OrderInvoice_BL.Contacts;
using Utilites;

namespace NUnit.LayerIntragrationTests.ContactArea.SnalMailAddress
{
    [TestFixture]
    class PersistentSnailMailAddressTests : TestBase
    {
        SnailMailAddress _sma1;
        SnailMailAddress _sma2;

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

            _sma2 = SnailMailAddress.GetById(_sma1.Id, GetRepository);
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
            List<SnailMailAddress> extraRecords = SnailMailAddress.GetAll(true, GetRepository);
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
            foreach(Country country in countries)
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
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_sma1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_sma2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_sma1.Id == _sma2.Id &&
                _sma1.Line1 == _sma2.Line1 &&
                _sma1.Line2 == _sma2.Line2 &&
                _sma1.City == _sma2.City &&
                _sma1.State.Abbreviation == _sma2.State.Abbreviation &&
                _sma1.Country.Abbreviation == _sma2.Country.Abbreviation &&
                _sma1.Zip == _sma2.Zip &&
                _sma1.Type.AddressType == _sma2.Type.AddressType &&
                _sma1.Deleted == _sma2.Deleted);
        }
        
        
    }
}
