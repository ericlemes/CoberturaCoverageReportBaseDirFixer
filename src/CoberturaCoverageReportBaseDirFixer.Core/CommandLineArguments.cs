using System.Collections.Generic;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public class CommandLineArguments
    {
        public bool IsValid { get; set; }
        public string BaseDir { get; set; }
        public string OutputFile { get; set; }
        public string InputFile { get; set; }
    }
}