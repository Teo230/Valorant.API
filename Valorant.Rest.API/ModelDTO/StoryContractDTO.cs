using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valorant.Rest.API.ModelDTO
{
    public class StoryContractDTO
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public object RequiredEntitlement { get; set; }
        public string ContractType { get; set; }
        public Progressionschedule ProgressionSchedule { get; set; }
        public Alternateprogressionschedule[] AlternateProgressionSchedules { get; set; }
        public List<Rewardschedule> RewardSchedules { get; set; }
        public Premiumcontractdetails PremiumContractDetails { get; set; }
        
        public class Progressionschedule
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string ProgressionCurrencyID { get; set; }
            public List<int> ProgressionDeltaPerLevel { get; set; }
        }

        public class Premiumcontractdetails
        {
            public Entitlement Entitlement { get; set; }
            public string PurchaseCurrencyID { get; set; }
            public int PurchaseCost { get; set; }
        }

        public class Entitlement
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
        }

        public class Alternateprogressionschedule
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string ProgressionCurrencyID { get; set; }
            public List<Progressiondeltaperlevel> ProgressionDeltaPerLevel { get; set; }
        }

        public class Progressiondeltaperlevel
        {
            public bool IsAvailable { get; set; }
            public int ProgressionDelta { get; set; }
        }

        public class Rewardschedule
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public Prerequisites Prerequisites { get; set; }
            public List<Rewardsperlevel> RewardsPerLevel { get; set; }
        }

        public class Prerequisites
        {
            public Requiredentitlement[] RequiredEntitlements { get; set; }
        }

        public class Requiredentitlement
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
        }

        public class Rewardsperlevel
        {
            public Entitlementreward[] EntitlementRewards { get; set; }
            public List<Walletreward> WalletRewards { get; set; }
        }

        public class Entitlementreward
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
            public int Amount { get; set; }
        }

        public class Walletreward
        {
            public string CurrencyID { get; set; }
            public int Amount { get; set; }
        }
    }
}
