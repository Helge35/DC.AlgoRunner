using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

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

        public bool IsFolderAllowed(string path, string userPrincipalName)
        {
            try
            {
                var windowsIdentity = new WindowsIdentity(userPrincipalName.Split("\\").Last());
                var windowsPrincipal = new WindowsPrincipal(windowsIdentity);

                var rules = new DirectoryInfo(path)
                    .GetAccessControl(AccessControlSections.Access)
                    .GetAccessRules(true, true, typeof(NTAccount));

                foreach (AuthorizationRule rule in rules)
                {
                    if (!windowsPrincipal.IsInRole(rule.IdentityReference.Value))
                        continue;

                    var filesystemAccessRule = (FileSystemAccessRule)rule;
                    return (filesystemAccessRule.FileSystemRights & FileSystemRights.ReadData) > 0 &&
                        filesystemAccessRule.AccessControlType != AccessControlType.Deny;
                }
                return false;
            }
            catch (Exception exp) { return false; }
        }
    }
}
