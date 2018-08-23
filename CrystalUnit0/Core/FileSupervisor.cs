using System;
using System.IO;
using System.Text;

namespace PmThief.Core
{
    internal static class FileSupervisor
    {
        internal static string WriteFile(string data)
        {
            var uuid = Guid.NewGuid().ToString();
            using (StreamWriter writer = new StreamWriter(uuid, false, encoding: Encoding.UTF8))
                writer.Write(data);
            return uuid;
        }

        internal static void DeleteFile(string uuid)
        {
            File.Delete(uuid);
        }

        internal static string ReadFile(string uuid)
        {
            using (StreamReader reader = new StreamReader(uuid, encoding: Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
