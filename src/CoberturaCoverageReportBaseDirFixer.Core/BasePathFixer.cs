using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoberturaCoverageReportBaseDirFixer.Core
{
    public class BasePathFixer : IBasePathFixer
    {
        private IPath path;

        public BasePathFixer(IPath path)
        {
            this.path = path;
        }

        public string StripDrive(string basePath)
        {
            return basePath.Substring(basePath.IndexOf(':') + 2);
        }

        public string FixPath(string basePath, string filePath)
        {
            var absoluteBasePath = this.path.GetFullPath(basePath);
            var strippedDrive = StripDrive(absoluteBasePath);
            if (filePath.ToLower().StartsWith(strippedDrive.ToLower()))
                return filePath.Substring(strippedDrive.Length + 1);
            else
                return filePath;
        }
    }
}
