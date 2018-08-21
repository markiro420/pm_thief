using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PmThief.Core
{
    public static class Parser
    {
        static readonly Stopwatch sw = new Stopwatch();
        static public Dictionary<string, List<(string league, string link)>> GetSportHierarchy(string html) // (string league, string link)
        {
            sw.Start();
            var out_uuid = FileSupervisor.WriteFile(html);
            Console.WriteLine($"Write html to files: {sw.ElapsedMilliseconds}ms");
            sw.Restart();
            string in_uuid = ScriptRunner.RunScript("sport_hierarchy.py", out_uuid).Trim();
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
