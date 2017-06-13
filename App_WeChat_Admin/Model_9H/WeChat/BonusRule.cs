using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class BonusRule
    {
        [JsonProperty("cost_money_unit")]
        public int CostMoneyUnit { get; set; }
        [JsonProperty("increase_bonus")]
        public int IncreaseBonus { get; set; }
        [JsonProperty("max_increase_bonus")]
        public int MaxIncreaseBonus { get; set; }
        [JsonProperty("init_increase_bonus")]
        public int InitIncreaseBonus { get; set; }
        [JsonProperty("cost_bonus_unit")]
        public int CostBonusUnit { get; set; }
        [JsonProperty("reduce_money")]
        public int ReduceMoney { get; set; }
        [JsonProperty("least_money_to_use_bonus")]
        public int LeastMoneyToUseBonus { get; set; }
        [JsonProperty("max_reduce_bonus")]
        public int MaxReduceBonus { get; set; }
    }
}
