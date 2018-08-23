using System;
using System.Diagnostics;
using System.IO;

namespace CrystalGeneric
{
    public static class ScriptRunner
    {
        private static readonly string base_path = @"..\..\Scripts\";

        public static string RunScript(string sc)
        {
            return RunScript(sc, string.Empty);
        }

        public static string RunScript(string sc, string args)
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
    }
}
