
namespace RunIt
{
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;

    static class Program
    {
        static void Main()
        {
            while (true)
            {
                try
                {
                    for (int i = 0; i < ConfigurationManager.AppSettings.Count; i++)
                    {
                        string filePath = ConfigurationManager.AppSettings[i];
                        string fullFileName = Path.GetFileName(filePath);
                        string fileName = Path.GetFileNameWithoutExtension(fullFileName);
                        var proc = Process.GetProcessesByName(fileName);
                        if (proc == null || proc.Length == 0)
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
                            startInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
                            Process.Start(startInfo);
                            Thread.Sleep(1000);
                        }
                    }       
                }
                catch
                { 
                }

                Thread.Sleep(10000);
            }
        }
    }
}
