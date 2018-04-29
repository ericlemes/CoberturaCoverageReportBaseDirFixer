using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public class BasePathFixer : IBasePathFixer
    {
        public string StripDrive(string basePath)
        {
            return basePath.Substring(basePath.IndexOf(':') + 2);
        }

        public string FixPath(string basePath, string filePath)
        {
            var strippedDrive = StripDrive(basePath);
            if (filePath.ToLower().StartsWith(strippedDrive.ToLower()))
                return filePath.Substring(strippedDrive.Length + 1);
            else
                return filePath;
        }
    }
}
