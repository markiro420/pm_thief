using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmThief.Core
{
    internal static class ScriptRunner
    {
        private static readonly string base_path = @"..\..\Scripts\";

        internal static string RunScript(string sc)
        {
            return RunScript(sc, string.Empty);
        }

        internal static string RunScript(string sc, string args)
        {
            string path = Path.Combine(base_path, sc);
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = @"C:\Users\beeff\AppData\Local\Programs\Python\Python36-32\python.exe",
                Arguments = $"\"{path}\" \"{args}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            using (Process process = Process.Start(info))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string errors = process.StandardError.ReadToEnd();
                    if (errors.Length > 0) Console.WriteLine(errors);
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }

        internal static string CreateFile(string data)
        {
            var uuid = Guid.NewGuid().ToString();
            using (StreamWriter writer = new StreamWriter(Path.Combine(base_path, uuid), false, encoding: Encoding.UTF8))
                writer.Write(data);
            return uuid;
        }

        internal static void DeleteFile(string uuid)
        {
            File.Delete(Path.Combine(base_path, uuid));
        }

        internal static string ReadFile(string uuid)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(base_path, uuid), encoding: Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
