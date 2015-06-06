using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;

namespace Bob.Boot
{
    public class Program
    {
        public static int Main(string[] args)
        {
            string application = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string directory = Path.Combine(application, "adma", "bob", "cache");
            string filename = Path.Combine(directory, "bob.exe");

            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(filename) == false)
            {
                using (WebClient client = new WebClient())
                {
                    string text = client.DownloadString("https://www.nuget.org/api/v2/FindPackagesById()?$filter=IsAbsoluteLatestVersion&$orderby=Version%20desc&$top=1&id='bob-make'");
                    Match match = Regex.Match(text, "src=\"(?<url>[^|]*?/package/bob-make/[^|]*?)\"");

                    if (match.Success == true)
                    {
                        byte[] data = client.DownloadData(match.Groups["url"].Value);

                        using (MemoryStream stream = new MemoryStream(data, false))
                        {
                            using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Read))
                            {
                                foreach (ZipArchiveEntry entry in archive.Entries)
                                {
                                    if (entry.Name.StartsWith("bob.exe") == true)
                                    {
                                        using (Stream bob = entry.Open())
                                        {
                                            using (Stream file = File.Create(Path.Combine(directory, entry.Name)))
                                            {
                                                bob.CopyTo(file);
                                                file.Flush();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (File.Exists(filename) == true)
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = Path.Combine(directory, "bob.exe"),
                    Arguments = String.Join(" ", args),
                    WorkingDirectory = Environment.CurrentDirectory,
                    UseShellExecute = false
                };

                Process process = Process.Start(info);
                process.WaitForExit();
                return process.ExitCode;
            }

            return -1;
        }
    }
}
