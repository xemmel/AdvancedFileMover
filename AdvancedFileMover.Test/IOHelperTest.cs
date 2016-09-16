using System;
using System.Collections.Generic;
using AdvancedFileMover.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvancedFileMover.Test
{
    [TestClass]
    public class IOHelperTest
    {
        [TestMethod]
        public void IOHelper_GetAllFilesFromDir()
        {
            string parentDirectory = @"C:\temp\TestPDF";
            string[] files = IOHelper.GetAllFilesFromDir(parentDirectory);
            Assert.IsNotNull(files);
            Assert.IsTrue(files.Length == 13);
        }
        [TestMethod]
        public void IOHelper_DirSearch()
        {
            string parentDirectory = @"C:\temp\TestPDF";
            var files = IOHelper.DirSearch(parentDirectory);
            Assert.IsNotNull(files);
            Assert.IsTrue(files.Count == 13);
        }
    }
}
