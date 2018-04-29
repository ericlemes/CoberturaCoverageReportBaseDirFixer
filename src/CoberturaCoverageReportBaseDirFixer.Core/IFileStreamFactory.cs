using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public interface IFileStreamFactory
    {
        Stream OpenFile(string fileName);
        Stream CreateFile(string fileName);
    }
}
