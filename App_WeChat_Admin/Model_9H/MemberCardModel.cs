using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public class MemberCardModel
    {
        public string BackgroundPicUrl { get; set; }
        public string CardID { get; set; }
        public string LogoUrl { get; set; }
        public string BrandName { get; set; }
        public string Title { get; set; }


        // 积分相关
        public int CostMoneyUnit { get; set; }
        public int IncreaseBonus { get; set; }
        public int MaxIncreaseBonus { get; set; }
        public int InitIncreaseBonus { get; set; }
        public int CostBonusUnit { get; set; }
        public int ReduceMoney { get; set; }
        public int LeastMoneyToUseBonus { get; set; }
        public int MaxReduceBonus { get; set; }
        public string Notice { get; set; }
        public string ServicePhone { get; set; }
        public string Description { get; set; }
        public string Prerogative { get; set; }

        public bool Service_Free_WIFI { get; set; }
        public bool Service_With_Pet { get; set; }
        public bool Service_Free_Park { get; set; }
        public bool Service_Deliver { get; set; }

        public float Discount { get; set; }
    }
}
