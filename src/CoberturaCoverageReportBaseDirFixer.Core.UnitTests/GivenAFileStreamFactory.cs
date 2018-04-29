using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoberturaCoverageReportBaseDirFixer.Core.UnitTests
{
    public class GivenAFileStreamFactory
    {
        [Fact]
        public void WhenCreatingAndOpeningFileShouldNotThrow()
        {
            var fileStreamFactory = new FileStreamFactory();
            var createdStream = fileStreamFactory.CreateFile("testfile.test");
            var streamWriter = new StreamWriter(createdStream);
            streamWriter.Write("blah");
            streamWriter.Flush();
            createdStream.Close();

            Assert.NotNull(fileStreamFactory.OpenFile("testfile.test"));
        }
    }
}
