using System;
using System.IO;
using System.Text;

namespace CrystalGeneric
{
    public static class FileSupervisor
    {
        public static string WriteFile(string data)
        {
            var uuid = Guid.NewGuid().ToString();
            using (StreamWriter writer = new StreamWriter(uuid, false, encoding: Encoding.UTF8))
                writer.Write(data);
            return uuid;
        }

        public static void DeleteFile(string uuid)
        {
            File.Delete(uuid);
        }

        public static string ReadFile(string uuid)
        {
            using (StreamReader reader = new StreamReader(uuid, encoding: Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
