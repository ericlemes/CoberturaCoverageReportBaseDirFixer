using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public interface IBasePathFixer
    {
        string FixPath(string basePath, string filePath);
    }
}
