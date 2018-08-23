using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace PmThief.Core
{
    public static class Downloader
    {
        public static async Task<string> GetHTML(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0");
            string data = string.Empty;
            try
            {
                data = await client.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
            return data;
        }
    }
}
