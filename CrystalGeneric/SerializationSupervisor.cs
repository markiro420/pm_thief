using System;
using Newtonsoft.Json;

namespace CrystalGeneric
{
    public static class SerializationSupervisor
    {
        public static string Serialize(object obj)
        {
            string data = JsonConvert.SerializeObject(obj, Formatting.None);
            return data;
        }

        public static T0 Deserialize<T0>(string data)
        {
            T0 obj = JsonConvert.DeserializeObject<T0>(data);
            return obj;
        }
    }
}
