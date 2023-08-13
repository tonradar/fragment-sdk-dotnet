using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TonRadar.Fragment.Model;
using ScrapySharp.Extensions;
using TonRadar.Fragment.Enum;


namespace TonRadar.Fragment.Parser
{
    public class FragmentHtmlParser
    {
        public List<AuctionItem> ExtractAuctionItems(string content)
        {
            var parser = new HtmlAgilityPack.HtmlDocument();
            parser.LoadHtml(content);
            var html = parser.DocumentNode;

            var auctionNodes = html.CssSelect(".js-search-results tbody > tr.tm-row-selectable").ToList();

            var auctionItems = new List<AuctionItem>();
            foreach (var auctionNode in auctionNodes)
            {
                var titleNode = auctionNode.CssSelect("div.table-cell-value-row > div.tm-value").Single();
                var priceInUsdNode = auctionNode.CssSelect("td.thin-last-col div.table-cell-desc.wide-only").Single();
                var priceInUsd = decimal.Parse(priceInUsdNode.InnerText.Split(';').Last().Replace(",", ""));

                var priceInTonNode = auctionNode.CssSelect("td.thin-last-col div.table-cell-value.tm-value.icon-before.icon-ton").Single();
                var priceInTon = decimal.Parse(priceInTonNode.InnerText.Split(';').Last().Replace(",", ""));

                var timeNode = auctionNode.CssSelect("td.thin-last-col time").Single();

                var endTime = DateTimeOffset.Parse(timeNode.Attributes["datetime"].Value);
                var endTimeDescription = timeNode.InnerText;

                auctionItems.Add(new AuctionItem()
                {
                    Title = titleNode.InnerText,
                    PriceInUsd = priceInUsd,
                    PriceInTon = priceInTon,
                    EndTime = endTime,
                    EndTimeDescription = endTimeDescription
                });
            }

            return auctionItems;
        }

        public List<AuctionItem> ExtractSaleItems(string content)
        {
            var parser = new HtmlAgilityPack.HtmlDocument();
            parser.LoadHtml(content);
            var html = parser.DocumentNode;

            var auctionNodes = html.CssSelect(".js-search-results tbody > tr.tm-row-selectable").ToList();

            var auctionItems = new List<AuctionItem>();
            foreach (var auctionNode in auctionNodes)
            {
                var titleNode = auctionNode.CssSelect("div.table-cell-value-row > div.tm-value").Single();
                var statusNode = auctionNode.CssSelect("div.table-cell-value-row > div.tm-status-avail").Single();
                var status = System.Enum.Parse<FragmentStatus>(statusNode.InnerText.Replace(" ", ""), ignoreCase: true);

                var priceInTonNode = auctionNode.CssSelect("td.thin-last-col div.table-cell-value.tm-value.icon-before.icon-ton").Single();
                var priceInTon = decimal.Parse(priceInTonNode.InnerText.Split(';').Last().Replace(",", ""));

                var timeNode = auctionNode.CssSelect("td.thin-last-col time").Single();

                var endTime = DateTimeOffset.Parse(timeNode.Attributes["datetime"].Value);
                var endTimeDescription = timeNode.InnerText;

                auctionItems.Add(new AuctionItem()
                {
                    Title = titleNode.InnerText,
                    Status = status,
                    PriceInTon = priceInTon,
                    EndTime = endTime,
                    EndTimeDescription = endTimeDescription
                });
            }

            return auctionItems;
        }

        public List<AuctionItem> ExtractSoldItems(string content)
        {
            var parser = new HtmlAgilityPack.HtmlDocument();
            parser.LoadHtml(content);
            var html = parser.DocumentNode;

            var auctionNodes = html.CssSelect(".js-search-results tbody > tr.tm-row-selectable").ToList();

            var auctionItems = new List<AuctionItem>();
            foreach (var auctionNode in auctionNodes)
            {
                var titleNode = auctionNode.CssSelect("div.table-cell-value-row > div.tm-value").Single();
                var statusNode = auctionNode.CssSelect("div.table-cell-value-row > div.tm-status-unavail").Single();
                var status = System.Enum.Parse<FragmentStatus>(statusNode.InnerText.Replace(" ", ""), ignoreCase: true);

                var priceInTonNode = auctionNode.CssSelect("td.thin-last-col div.table-cell-value.tm-value.icon-before.icon-ton").Single();
                var priceInTon = decimal.Parse(priceInTonNode.InnerText.Split(';').Last().Replace(",", ""));

                var timeNode = auctionNode.CssSelect("td.wide-last-col time").Single();

                var endTime = DateTimeOffset.Parse(timeNode.Attributes["datetime"].Value);
                var endTimeDescription = timeNode.InnerText;

                auctionItems.Add(new AuctionItem()
                {
                    Title = titleNode.InnerText,
                    Status = status,
                    PriceInTon = priceInTon,
                    EndTime = endTime,
                    EndTimeDescription = endTimeDescription
                });
            }

            return auctionItems;
        }

        private string GetPlainTextFromHtml(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }
    }
}
