using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace pm_thief
{
    static class Downloader
    {
        private static async Task<HtmlDocument> GetHtmlDoc(string url)
        {
            var client = new HttpClient();
            var data = string.Empty;
            try
            {
                data = await client.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine(ex.Message);
            }
            var doc = new HtmlDocument();
            doc.LoadHtml(data);
            return doc;
        }

    }
}
