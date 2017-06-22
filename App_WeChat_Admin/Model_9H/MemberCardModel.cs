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

        public bool ServiceFreeWIFI { get; set; }
        public bool ServiceWithPet { get; set; }
        public bool ServiceFreePark { get; set; }
        public bool ServiceDeliver { get; set; }

        public float Discount { get; set; }
    }
}
