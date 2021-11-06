using HtmlAgilityPack;
using MWCore.Areas.MWCore.Models.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace MWCore.Areas.MWCore.Models.Modules.SearchEngine
{
    public class SearchEngineCOM
    {
        public static List<string> lstLinks = new List<string>();
        static string BaseURL = "";
        public static XElement contacts = new XElement("Search");
        public static async Task UpdateSearchFiles()
        {
            BaseURL = System.Configuration.ConfigurationManager.AppSettings["DefaultWebsiteURL"].ToString();
            await GetData(BaseURL);
            contacts.Save(@"D:\TFS_Projects_New\BeepBeepApp\BeepBeepApp\MWCore\SearchFiles\search.xml");
            lstLinks = new List<string>();
            contacts = new XElement("Search");
            await GetData(BaseURL + "/ar");
            contacts.Save(@"D:\TFS_Projects_New\BeepBeepApp\BeepBeepApp\MWCore\SearchFiles\search-ar.xml");

        }

        public static async Task GetData(string sURL)
        {
            try
            {
                sURL = sURL.Replace("/ar//ar", "/ar");
                if (!SearchEngineCOM.lstLinks.Contains(sURL))
                {
                    if (!sURL.ToLower().Contains("mailto") && !sURL.ToLower().Contains("javascript") && !sURL.ToLower().Contains("tel:") && sURL.ToLower() != "#" && !sURL.ToLower().Contains("changelanguage"))
                    {
                        using (var client = new MyWebClient())
                        {


                            SearchEngineCOM.lstLinks.Add(sURL);
                            string html = client.DownloadString(sURL);
                            HtmlAgilityPack.HtmlDocument doc = new HtmlWeb().Load(sURL);
                            HtmlToText oHtmlToText = new HtmlToText();
                            string data = oHtmlToText.ConvertHtml(doc.DocumentNode.OuterHtml);
                            string sTitle = "Page";

                            HtmlNode Title = doc.DocumentNode.Descendants("title").FirstOrDefault();
                            if (Title != null)
                            {
                                sTitle = Title.InnerText;
                            }
                            XElement Result = new XElement("Result");
                            Result.Add(new XElement("url", sURL));
                            Result.Add(new XElement("title", sTitle));
                            Result.Add(new XElement("content", data));
                            contacts.Add(Result);
                            List<string> lstLinks = ExtractAllAHrefTags(doc);
                            foreach (string link in lstLinks)
                            {
                                string sLink = link;
                                if (sLink != "#")
                                {
                                    if (!sLink.StartsWith("http"))
                                    {
                                        if (!sLink.EndsWith("/"))
                                        {
                                            sLink = BaseURL + "/" + sLink;
                                        }
                                    }
                                    if (sLink.Contains(sURL.Replace("https://", "").Replace("http://", "")))
                                    {
                                        await GetData(sLink);

                                    }

                                }

                            }


                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private static List<string> ExtractAllAHrefTags(HtmlAgilityPack.HtmlDocument htmlSnippet)
        {
            List<string> hrefTags = new List<string>();
            if (htmlSnippet.DocumentNode.SelectNodes("//a[@href]") != null)
            {
                foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
                {
                    HtmlAttribute att = link.Attributes["href"];
                    hrefTags.Add(att.Value);
                }
            }


            return hrefTags;
        }
    }
}