using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace pm_thief
{   
    public static class Parser
    {
        public static Dictionary<string, List<Tuple<string, string>>> getSportLinksHieararchy(HtmlDocument doc)
        {
            HtmlNode table = doc.DocumentNode.SelectSingleNode("//*[@id=\"lobbySportsHolder\"]");
            return new Dictionary<string, List<Tuple<string, string>>>();
        }
    }
}
