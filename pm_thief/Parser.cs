﻿using System;
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
        public static Dictionary<string, List<(string league, string link)>> GetSportLinksHierarchy(HtmlDocument doc)
        {
            // Из тейбл нужно собрать все ссылки с названием лиг, скомпоновать в список таплов и поместить в словарь по спортам
            HtmlNode table = doc.DocumentNode.SelectSingleNode("//*[@id=\"lobbySportsHolder\"]");
            
            var sportHierarchy = new Dictionary<string, List<(string, string)>>();
            var sportNodes = table.ChildNodes.Where(child => child.Name == "li");
            foreach (var sportNode in sportNodes)
            {
                var sport = sportNode.ChildNodes["a"].InnerText;
                var leagues_links = sportNode.ChildNodes["ul"].ChildNodes.Where(child => child.Name == "li").
                    Select(li => (li.InnerText, li.ChildNodes["a"].GetAttributeValue("href", string.Empty)));

                if (!sportHierarchy.Keys.Contains(sport))
                    sportHierarchy.Add(sport, new List<(string, string)>());
                sportHierarchy[sport].AddRange(leagues_links);
            }
            return sportHierarchy;
        }


        //Обобщить для разных спортов, пока только для футбола
        public static void getMatchesFromDoc(HtmlDocument doc)
        {
            HtmlNode table = doc.DocumentNode.ChildNodes..Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("dt twp")).ToList().FirstOrDefault();
            if (table != null)
            {
                var rawMatches = table.Descendants().Where(d => d.Attributes.Contains("class")
                    && d.Attributes["class"].Value.Contains("row1 processed")).ToList();
                    //&& (d.Attributes["class"].Value.Contains("row1") || d.Attributes["class"].Value.Contains("row1"))).ToList();
                Console.WriteLine();
            }
        }

        //public static List<>
    }
}
