using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class PlayerStoreDTO
    {
        public Featuredtheme FeaturedTheme { get; set; }
        public Featuredbundle FeaturedBundle { get; set; }
        public Skinspanellayout SkinsPanelLayout { get; set; }

        public class Featuredtheme
        {
            public string ID { get; set; }
            public string DataAssetID { get; set; }
            public string CurrencyID { get; set; }
            public List<Items> Items { get; set; }
        }

        public class Items
        {
            public Item Item { get; set; }
            public int BasePrice { get; set; }
            public string CurrencyID { get; set; }
            public int DiscountPercent { get; set; }
            public bool IsPromoItem { get; set; }
        }

        public class Item
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
            public int Amount { get; set; }
        }

        public class Featuredbundle
        {
            public Bundle Bundle { get; set; }
            public int BundleRemainingDurationInSeconds { get; set; }
        }

        public class Bundle
        {
            public string ID { get; set; }
            public string DataAssetID { get; set; }
            public string CurrencyID { get; set; }
            public List<Items> Items { get; set; }
        }

        public class Skinspanellayout
        {
            public List<string> SingleItemOffers { get; set; }
            public int SingleItemOffersRemainingDurationInSeconds { get; set; }
        }

    }
}
