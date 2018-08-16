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
            // Из тейбл нужно собрать все ссылки с названием лиг, скомпоновать в список таплов и поместить в словарь по спортам
            return new Dictionary<string, List<Tuple<string, string>>>();
        }

        //public static List<>
    }
}
