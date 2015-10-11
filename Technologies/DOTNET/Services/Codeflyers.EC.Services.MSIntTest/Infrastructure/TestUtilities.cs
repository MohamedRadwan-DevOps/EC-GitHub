using System;
using System.IO;
using System.Reflection;

namespace Codeflyers.EC.Services.MSIntTest.Infrastructure
{
    public class TestUtilities
    {
        public static string AssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public static string ProjectDirectory(string assemblyDirectory)
        {
            if (assemblyDirectory != null)
            {
                int postionOfBin = assemblyDirectory.IndexOf("\\bin");
                return assemblyDirectory.Substring(0, postionOfBin);
            }
            return string.Empty;
        }        
        
        public static string ProjectDirectory()
        {

            int postionOfBin = AssemblyDirectory().IndexOf("\\bin");
            return AssemblyDirectory().Substring(0, postionOfBin);
        }
    }
}
