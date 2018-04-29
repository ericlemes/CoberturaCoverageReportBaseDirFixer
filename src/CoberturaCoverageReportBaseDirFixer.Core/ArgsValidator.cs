using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public class ArgsValidator
    {
        public CommandLineArguments ValidateArguments(string[] args)
        {
            if (args.Length < 3)
            {
                Console.Write(Resources.Usage);
                return new CommandLineArguments()
                {
                    IsValid = false
                };
            }
            return new CommandLineArguments()
            {
                IsValid = true,
                InputFile = args[0],
                OutputFile = args[1],
                BaseDir = args[2]
            };
        }
    }
}
