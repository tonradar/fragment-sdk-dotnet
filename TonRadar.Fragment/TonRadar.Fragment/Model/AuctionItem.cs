using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonRadar.Fragment.Model
{
    public record AuctionItem
    {
        public required string Title {get;set;}
        public required decimal PriceInUsd {get;set;}
        public required decimal PriceInTon {get;set;}
        public required string EndTimeDescription {get;set;}
        public required DateTimeOffset EndTime { get; set; }

        public override string ToString()
        {
            return $"{Title} [{PriceInTon} TON] [{PriceInUsd}$] [{EndTimeDescription}] [{EndTime}]";
        }
    }
}
