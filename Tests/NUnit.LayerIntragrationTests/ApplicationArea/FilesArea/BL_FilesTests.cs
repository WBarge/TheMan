using System.Collections.Generic;
using NUnit.Framework;
using OrderInvoice_BL.Application;

namespace NUnit.LayerIntragrationTests.ApplicationArea.FilesArea
{
    [TestFixture]
    public class BlFilesTests : TestBase
    {

        [SetUp]
        public void TestsInit()
        {
        }

        /// <summary>
        /// Remove record from db
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            List<StoredFiles> results = StoredFiles.GetAll(GetRepository);
            foreach (StoredFiles pnt in results)
            {
                pnt.PermanentlyRemoveFromSystem();
            }
        }

        private void CreateStoredFiles(FileLocationType lt)
        {
            StoredFiles stf = new StoredFiles(GetRepository)
            {
                FileName = "TestFile",
                FileContents = new byte[5],
                LocationType = lt
            };
            stf.Save();
        }

        [Test]
        public void TestFooterFiles()
        {
            CreateStoredFiles(FileLocationType.Footer);
            List<StoredFiles> results = StoredFiles.GetFooterFiles(GetRepository);
            Assert.Greater(results.Count, 0);

        }


        [Test]
        public void TestBannerFiles()
        {
            CreateStoredFiles(FileLocationType.Banner);
            List<StoredFiles> results = StoredFiles.GetBannerFiles(GetRepository);
            Assert.Greater(results.Count, 0);

        }

        [Test]
        public void TestBackgroundFiles()
        {
            CreateStoredFiles(FileLocationType.Background);
            List<StoredFiles> results = StoredFiles.GetBackgroundFiles(GetRepository);
            Assert.Greater(results.Count,0);

        }
    }
}
