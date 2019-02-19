using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Services
{
    public class FilesService
    {
        private  string _executionPath;

        public FilesService(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _executionPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("AlgoExeDirectoryName").Value);
        }

        public string GetFullPath(string dirName)
        {
            return Path.Combine(_executionPath , dirName/* + @"\Output.csv"*/);
        }

        public bool IsFolderAlowed(string path)
        {
            DirectorySecurity dbSecurity;
            try
            {
                //string dirPath = new FileInfo(path);//.Directory.FullName;
                DirectoryInfo dInfo = new DirectoryInfo(path);
                dbSecurity = dInfo.GetAccessControl();
            }
            catch (System.UnauthorizedAccessException)
            {
                return false;
            }

            var acl = dbSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

            foreach (FileSystemAccessRule far in acl)
            {
                if (far.AccessControlType == AccessControlType.Allow && far.FileSystemRights >= FileSystemRights.ReadPermissions)
                    return true;
            }

            return false;
        }
    }
}
