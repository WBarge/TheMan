using NUnit.Framework;
using OrderInvoice_BL.Application;
using Utilites;

namespace NUnit.LayerIntragrationTests.ApplicationArea.RolesArea
{
    [TestFixture]
    public class PersistentRoleTests:TestBase
    {
        const string RoleName = "TestRole";

        Role _role1;
        Role _role2;


        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _role1 = Role.Create(RoleName, GetRepository);
            _role2 = Role.GetById(_role1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _role1.PermanentlyRemoveFromSystem();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_role1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_role2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            Assert.IsTrue(_role1.Id == _role2.Id && _role1.Name == _role2.Name);
        }


    }
}
