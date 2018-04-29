using CoberturaCoverageReportBaseDirFixer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoberturaCoverageReportBaseDirFixer
{
    class Program
    {
        static int Main(string[] args)
        {
            var parsedArgs = new ArgsValidator().ValidateArguments(args);
            if (!parsedArgs.IsValid)
                return -1;

            var parser = new ReportParser(new FileStreamFactory(), new BasePathFixer());
            parser.Parse(parsedArgs.InputFile, parsedArgs.OutputFile, parsedArgs.BaseDir);

            return 0;
        }
    }
}
