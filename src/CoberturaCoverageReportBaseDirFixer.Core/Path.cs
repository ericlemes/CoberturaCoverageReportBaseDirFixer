using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public class Path : IPath
    {
        public string GetFullPath(string path)
        {
            return System.IO.Path.GetFullPath(path);
        }
    }
}
