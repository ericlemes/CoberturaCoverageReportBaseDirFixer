using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoberturaCoverageReportBaseDirFixer.Core.UnitTests
{
    public class GivenAnArgsValidator
    {
        [Fact]
        public void WhenArgsDifferentThan3ShouldReturnInvalidArgs()
        {
            var argsValidator = new ArgsValidator();
            var args = argsValidator.ValidateArguments(new string[0]);

            Assert.False(args.IsValid);
        }

        [Fact]
        public void WhenArgsEqual3ShouldProcessArgumentsCorrectly()
        {
            var argsValidator = new ArgsValidator();
            var args = argsValidator.ValidateArguments(new string[] { "arg1", "arg2", "arg3" });
            Assert.True(args.IsValid);
            Assert.Equal("arg1", args.InputFile);
            Assert.Equal("arg2", args.OutputFile);
            Assert.Equal("arg3", args.BaseDir);
        }
    }
}
