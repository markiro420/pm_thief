using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PmThief.Core
{
    public static class Downloader
    {
        public static async Task<HtmlDocument> GetHtmlDoc(string url)
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
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(data);
            return doc;
        }

    }
}
