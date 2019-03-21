using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CronJob.Models
{
    public class ebay
    {

        [XmlRoot(ElementName = "seller_info")]
        public class Seller_info
        {
            [XmlElement(ElementName = "seller_name")]
            public string Seller_name { get; set; }
            [XmlElement(ElementName = "seller_rating")]
            public string Seller_rating { get; set; }
        }

        [XmlRoot(ElementName = "high_bidder")]
        public class High_bidder
        {
            [XmlElement(ElementName = "bidder_name")]
            public string Bidder_name { get; set; }
            [XmlElement(ElementName = "bidder_rating")]
            public string Bidder_rating { get; set; }
        }

        [XmlRoot(ElementName = "auction_info")]
        public class Auction_info
        {
            [XmlElement(ElementName = "current_bid")]
            public string Current_bid { get; set; }
            [XmlElement(ElementName = "time_left")]
            public string Time_left { get; set; }
            [XmlElement(ElementName = "high_bidder")]
            public High_bidder High_bidder { get; set; }
            [XmlElement(ElementName = "num_items")]
            public string Num_items { get; set; }
            [XmlElement(ElementName = "num_bids")]
            public string Num_bids { get; set; }
            [XmlElement(ElementName = "started_at")]
            public string Started_at { get; set; }
            [XmlElement(ElementName = "bid_increment")]
            public string Bid_increment { get; set; }
            [XmlElement(ElementName = "location")]
            public string Location { get; set; }
            [XmlElement(ElementName = "opened")]
            public string Opened { get; set; }
            [XmlElement(ElementName = "closed")]
            public string Closed { get; set; }
            [XmlElement(ElementName = "id_num")]
            public string Id_num { get; set; }
            [XmlElement(ElementName = "notes")]
            public string Notes { get; set; }
        }

        [XmlRoot(ElementName = "bid_history")]
        public class Bid_history
        {
            [XmlElement(ElementName = "highest_bid_amount")]
            public string Highest_bid_amount { get; set; }
            [XmlElement(ElementName = "quantity")]
            public string Quantity { get; set; }
        }

        [XmlRoot(ElementName = "item_info")]
        public class Item_info
        {
            [XmlElement(ElementName = "memory")]
            public string Memory { get; set; }
            [XmlElement(ElementName = "hard_drive")]
            public string Hard_drive { get; set; }
            [XmlElement(ElementName = "cpu")]
            public string Cpu { get; set; }
            [XmlElement(ElementName = "brand")]
            public string Brand { get; set; }
            [XmlElement(ElementName = "description")]
            public string Description { get; set; }
        }

        [XmlRoot(ElementName = "listing")]
        public class Listing
        {
            [XmlElement(ElementName = "seller_info")]
            public Seller_info Seller_info { get; set; }
            [XmlElement(ElementName = "payment_types")]
            public string Payment_types { get; set; }
            [XmlElement(ElementName = "shipping_info")]
            public string Shipping_info { get; set; }
            [XmlElement(ElementName = "buyer_protection_info")]
            public string Buyer_protection_info { get; set; }
            [XmlElement(ElementName = "auction_info")]
            public Auction_info Auction_info { get; set; }
            [XmlElement(ElementName = "bid_history")]
            public Bid_history Bid_history { get; set; }
            [XmlElement(ElementName = "item_info")]
            public Item_info Item_info { get; set; }
        }

        [XmlRoot(ElementName = "root")]
        public class Root
        {
            [XmlElement(ElementName = "listing")]
            public List<Listing> Listing { get; set; }
        }

    }
}
