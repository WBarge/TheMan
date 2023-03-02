using NUnit.Framework;
using OrderInvoice_BL.Application;
using Utilites;

namespace NUnit.LayerIntragrationTests.ApplicationArea.FilesArea
{
    [TestFixture]
    public class NonPersistentFilesTests : TestBase
    {
        const string FileName = "TestFile.txt";

        StoredFiles _f;

        /// <summary>
        /// Setup object for this series of tests
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _f = new StoredFiles(GetRepository)
            {
                FileName = FileName,
                FileContents = new byte[3]
            };
        }

        /// <summary>
        /// Test a new object was created
        /// </summary>
        [Test]
        public void NewObjectTest()
        {
            Assert.IsTrue(_f.IsNotEmpty());
        }

        /// <summary>
        /// Test the initial state of the Name property
        /// </summary>
        [Test]
        public void InitFileNameTest()
        {
            Assert.AreEqual(_f.FileName, FileName);
        }

        [Test]
        public void InitFileContentsTest()
        {
            Assert.IsTrue(_f.FileContents.IsNotEmpty());
        }

    }
}
