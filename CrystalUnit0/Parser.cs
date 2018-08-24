using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using CrystalGeneric;

namespace CrystalUnit0
{
    // https://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
    static class Parser
    {
        static readonly Stopwatch sw = new Stopwatch();
        public static Dictionary<string, List<(string league, string link)>> GetSportHierarchy(string html)
        {
            sw.Start();
            var out_uuid = FileSupervisor.WriteFile(html);
            Console.WriteLine($"Write html to files: {sw.ElapsedMilliseconds}ms");
            sw.Restart();
            ScriptRunner scrunner = new ScriptRunner(Assembly.GetExecutingAssembly());
            string in_uuid = scrunner.RunScript("sport_hierarchy.py", out_uuid).Trim();
            Console.WriteLine($"Python time: {sw.ElapsedMilliseconds}ms");
            sw.Restart();
            string data = FileSupervisor.ReadFile(in_uuid);
            Console.WriteLine($"Read results: {sw.ElapsedMilliseconds}ms");
            sw.Restart();

            var sportHierarchy = new Dictionary<string, List<(string, string)>>();
            foreach (var pair in SerializationSupervisor.Deserialize<Dictionary<string, List<object[]>>>(data))
                sportHierarchy.Add(pair.Key, pair.Value.Select(x => (x[0] as string, x[1] as string)).ToList());

            FileSupervisor.DeleteFile(out_uuid);
            FileSupervisor.DeleteFile(in_uuid);
            Console.WriteLine($"Delete files: {sw.ElapsedMilliseconds}ms");
            return sportHierarchy;
        }
    }
}
