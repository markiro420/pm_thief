using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PmThief
{
    public static class Parser
    {
        // Маркул бля выучи нотацию
        public static Dictionary<string, List<(string, string)>> GetSportLinksHierarchy(HtmlDocument doc)
        {
            // Из тейбл нужно собрать все ссылки с названием лиг, скомпоновать в список таплов и поместить в словарь по спортам
            HtmlNode table = doc.DocumentNode.SelectSingleNode("//*[@id=\"lobbySportsHolder\"]");
            
            var sportHierarchy = new Dictionary<string, List<(string, string)>>();
            var sportNodes = table.ChildNodes.Where(child => child.Name == "li");
            foreach (var sportNode in sportNodes)
            {
                var sport = sportNode.ChildNodes["a"].InnerText;
                var leagues_links = sportNode.ChildNodes["ul"].ChildNodes.Where(child => child.Name == "li").
                    Select(li => (league: li.InnerText, link: li.ChildNodes["a"].GetAttributeValue("href", string.Empty)));

                if (!sportHierarchy.Keys.Contains(sport))
                    sportHierarchy.Add(sport, new List<(string, string)>());
                sportHierarchy[sport].AddRange(leagues_links);
            }
            return sportHierarchy;
        }

        //public static List<>
    }
}
