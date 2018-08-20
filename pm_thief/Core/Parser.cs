using System;
using System.Collections.Generic;
using System.Linq;

namespace PmThief.Core
{
    public static class Parser
    {
        static public Dictionary<string, List<(string league, string link)>> GetSportHierarchy(string html) // (string league, string link)
        {
            var out_uuid = FileSupervisor.WriteFile(html);
            string in_uuid = ScriptRunner.RunScript("sport_hierarchy.py", out_uuid).Trim();
            string data = FileSupervisor.ReadFile(in_uuid);

            var sportHierarchy = new Dictionary<string, List<(string, string)>>();
            foreach (var pair in SerializationSupervisor.Deserialize<Dictionary<string, List<object[]>>>(data))
                sportHierarchy.Add(pair.Key, pair.Value.Select(x => (x[0] as string, x[1] as string)).ToList());

            FileSupervisor.DeleteFile(out_uuid);
            FileSupervisor.DeleteFile(in_uuid);
            return sportHierarchy;
        }
    }
}
