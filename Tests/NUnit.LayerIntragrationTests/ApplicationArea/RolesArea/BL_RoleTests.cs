using System.Collections.Generic;
using NUnit.Framework;
using OrderInvoice_BL.Application;

namespace NUnit.LayerIntragrationTests.ApplicationArea.RolesArea
{
    [TestFixture]
    class BlRoleTests:TestBase
    {
        public Role Role1 { get; private set; }

        const string RoleName = "TestRole";

        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            Role1 = Role.Create(RoleName, GetRepository);
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

    }
}
