using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoberturaCoverageReportBaseDirFixer.Core.UnitTests
{
    
    public class GivenABasePathFixer
    {
        private BasePathFixer basePathFixer;
        private Mock<IPath> path;

        public GivenABasePathFixer()
        {
            path = new Mock<IPath>();
            string capturedPath = String.Empty;
            path.Setup(p => p.GetFullPath(It.IsAny<string>())).Returns((string s) => s);

            this.basePathFixer = new BasePathFixer(path.Object);
        }

        [Fact]
        public void WhenStrippingDriveShouldReturnExpectedString()
        {            
            Assert.Equal(@"test", basePathFixer.StripDrive(@"C:\test"));
        }

        [Fact]
        public void WhenConvertingValidPathShouldReturnCorrectValue()
        {            
            Assert.Equal(@"file.cpp", basePathFixer.FixPath(@"C:\SomeWorkPath\SolutionPath", @"someworkpath\solutionpath\file.cpp"));
        }

        [Fact]
        public void WhenConvertingValidBigPathShouldReturnCorrectValue()
        {            
            Assert.Equal(@"someotherpath\anotherone\file.cpp", basePathFixer.FixPath(@"C:\SomeWorkPath\SolutionPath", @"someworkpath\solutionpath\someotherpath\anotherone\file.cpp"));
        }

        [Fact]
        public void WhenBasePathContainsDotShouldReturnCorrectValue()
        {
            this.path.Reset();
            this.path.Setup(p => p.GetFullPath(@".")).Returns(@"C:\SomeWorkPath\SolutionPath");
            Assert.Equal(@"someotherpath\anotherone\file.cpp", basePathFixer.FixPath(@".", @"someworkpath\solutionpath\someotherpath\anotherone\file.cpp"));
        }
    }
}
