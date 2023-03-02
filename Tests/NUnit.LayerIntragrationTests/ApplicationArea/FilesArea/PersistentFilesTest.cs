using NUnit.Framework;
using OrderInvoice_BL.Application;
using Utilites;

namespace NUnit.LayerIntragrationTests.ApplicationArea.FilesArea
{
    [TestFixture]
    public class PersistentFilesTest : TestBase
    {
        const string FileName = "TestFile.txt";

        StoredFiles _f1;
        StoredFiles _f2;


        /// <summary>
        /// Setup objects for series test
        /// </summary>
        [SetUp]
        public void TestsInit()
        {
            _f1 = new StoredFiles(GetRepository)
            {
                FileName = FileName,
                FileContents = new byte[2],
                LocationType = FileLocationType.Background
            };
            _f1.Save();
            _f2 = StoredFiles.GetById(_f1.Id, GetRepository);
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            _f1.PermanentlyRemoveFromSystem();
        }

        /// <summary>
        /// Test the object creation and save to the db happened
        /// </summary>
        [Test]
        public void SaveTest()
        {
            Assert.IsTrue(_f1.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the getting of the object populated from the db happened
        /// </summary>
        [Test]
        public void RetrieveTest()
        {
            Assert.IsTrue(_f2.Id.IsNotEmpty());
        }

        /// <summary>
        /// Test the objects point to the same record in the db
        /// </summary>
        [Test]
        public void SameRecordTest()
        {
            // ReSharper disable once EqualExpressionComparison
            Assert.IsTrue(_f1.Id == _f1.Id && _f1.FileName == _f2.FileName);
        }

    }
}
