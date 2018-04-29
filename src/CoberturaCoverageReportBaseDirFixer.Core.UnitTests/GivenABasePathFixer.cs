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
        [Fact]
        public void WhenStrippingDriveShouldReturnExpectedString()
        {
            var basePathFixer = new BasePathFixer();
            Assert.Equal(@"test", basePathFixer.StripDrive(@"C:\test"));
        }

        [Fact]
        public void WhenConvertingValidPathShouldReturnCorrectValue()
        {
            var basePathFixer = new BasePathFixer();
            Assert.Equal(@"file.cpp", basePathFixer.FixPath(@"C:\SomeWorkPath\SolutionPath", @"someworkpath\solutionpath\file.cpp"));
        }

        [Fact]
        public void WhenConvertingValidBigPathShouldReturnCorrectValue()
        {
            var basePathFixer = new BasePathFixer();
            Assert.Equal(@"someotherpath\anotherone\file.cpp", basePathFixer.FixPath(@"C:\SomeWorkPath\SolutionPath", @"someworkpath\solutionpath\someotherpath\anotherone\file.cpp"));
        }
    }
}
