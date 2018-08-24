using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace CrystalGeneric
{
    public class ScriptRunner
    {
        private ScriptRunner()
        {

        }

        public ScriptRunner(Assembly asm)
        {
            var asm_name = asm.GetName().Name; // CrystalUnit0 
            var asm_location = asm.Location;
            // C:\Users\beeff\Desktop\progs\CrystalFactory\CrystalUnit0\bin\Debug\CrystalUnit0.exe
            base_path = $@"..\..\..\{asm_name}\Scripts\";
        }

        private readonly string base_path;

        public string RunScript(string sc)
        {
            return RunScript(sc, string.Empty);
        }

        public string RunScript(string sc, string args)
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
