using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public class FileStreamFactory : IFileStreamFactory
    {
        public Stream CreateFile(string fileName)
        {
            return new FileStream(fileName, FileMode.Create, FileAccess.Write);
        }

        public Stream OpenFile(string fileName)
        {
            return new FileStream(fileName, FileMode.Open, FileAccess.Read);
        }
    }
}
