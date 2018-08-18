namespace PmThief.Core
{
    public static class Parser
    {
        static public string GetSportHierarchy(string html)
        {
            var out_uuid = FileSupervisor.WriteFile(html);
            string in_uuid = ScriptRunner.RunScript("sport_hierarchy.py", out_uuid).Trim();
            string sportHierarchy = FileSupervisor.ReadFile(in_uuid);
            FileSupervisor.DeleteFile(out_uuid);
            FileSupervisor.DeleteFile(in_uuid);
            return sportHierarchy;
        }
    }
}
