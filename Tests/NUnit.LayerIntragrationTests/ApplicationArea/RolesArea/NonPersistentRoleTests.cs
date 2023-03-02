using System.Collections.Generic;
using NUnit.Framework;
using OrderInvoice_BL.Application;
using Utilites;

namespace NUnit.LayerIntragrationTests.ApplicationArea.RolesArea
{
    [TestFixture]
    public class NonPersistentRoleTests : TestBase
    {
        const string RoleName = "TestRole";

        Role _role;


        /// <summary>
        /// Setup object for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _role = Role.Create(RoleName, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            List<Role> results = Role.GetAll(GetRepository);
            foreach (Role r in results)
            {
                r.PermanentlyRemoveFromSystem();
            }
        }


        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_role.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the Name property
        /// </summary>
        [Test]
        public void InitNameTest()
        {
            Assert.AreEqual(_role.Name, RoleName);
        }
    }

}
