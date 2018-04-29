using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoberturaCoverageReportBaseDirFixer.Core.UnitTests
{
    public class GivenAReportParser
    {
        private MemoryStream inputMemoryStream;
        private MemoryStream outputMemoryStream;
        private Mock<IFileStreamFactory> fileStreamFactoryMock;
        private Mock<IBasePathFixer> basePathFixerMock;
        private ReportParser parser;
        private string inputReportPath;
        private string outputReportPath;

        public GivenAReportParser()
        {
            inputReportPath = @"C:\SomeReport.xml";
            outputReportPath = @"C:\OutputReport.xml";

            inputMemoryStream = CreateMemoryStreamWithContent(Resources.OpenCppCoverageReport);
            outputMemoryStream = new MemoryStream();

            fileStreamFactoryMock = new Mock<IFileStreamFactory>();
            fileStreamFactoryMock.Setup(fs => fs.OpenFile(inputReportPath)).Returns(inputMemoryStream);
            fileStreamFactoryMock.Setup(fs => fs.CreateFile(outputReportPath)).Returns(outputMemoryStream);

            basePathFixerMock = new Mock<IBasePathFixer>();

            parser = new ReportParser(fileStreamFactoryMock.Object, basePathFixerMock.Object);
        }

        [Fact]
        public void WhenParsingXmlShouldInvokeFileNameTranslation()
        {
            parser.Parse(inputReportPath, outputReportPath, @"C:\SandBox\UnitTestFrameworkEvaluation");

            fileStreamFactoryMock.Verify(fsf => fsf.OpenFile(inputReportPath), Times.Once());
            basePathFixerMock.Verify(bsf => bsf.FixPath(@"C:\SandBox\UnitTestFrameworkEvaluation", @"sandbox\unittestframeworkevaluation\examplecode\user.cpp"), Times.Once());
            basePathFixerMock.Verify(bsf => bsf.FixPath(@"C:\SandBox\UnitTestFrameworkEvaluation", @"sandbox\unittestframeworkevaluation\examplecode\usermanager.cpp"), Times.Once());
        }

        [Fact]
        public void WhenParsingXmlShouldSaveOutputXml()
        {
            inputMemoryStream = CreateMemoryStreamWithContent(Resources.VerySimpleReport);

            var basePath = @"C:\SandBox\UnitTestFrameworkEvaluation";

            basePathFixerMock.Setup(m => m.FixPath(basePath, @"sandbox\unittestframeworkevaluation\examplecode\user.cpp")).Returns(@"examplecode\user.cpp");
            basePathFixerMock.Setup(m => m.FixPath(basePath, @"sandbox\unittestframeworkevaluation\examplecode\user2.cpp")).Returns(@"examplecode\user2.cpp");

            fileStreamFactoryMock.Setup(fs => fs.OpenFile(inputReportPath)).Returns(inputMemoryStream);

            parser.Parse(inputReportPath, outputReportPath, @"C:\SandBox\UnitTestFrameworkEvaluation");

            fileStreamFactoryMock.Verify(fsf => fsf.CreateFile(outputReportPath), Times.Once());
            var content = GetFullContentOfStream(outputMemoryStream);
            Assert.Equal(Resources.VerySimpleReportParsed, content);    
        }

        private MemoryStream CreateMemoryStreamWithContent(string content)
        {
            var ms = new MemoryStream();
            var streamWriter = new StreamWriter(ms);
            streamWriter.Write(content);
            streamWriter.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        private string GetFullContentOfStream(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var rd = new StreamReader(stream);
            return rd.ReadToEnd();
        }
    }
}
