using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank
{
    public class GoldFish : Fish
    {
        public GoldFish(string name) : base(name) { }

        public override string FishType { get { return "GoldFish"; } }
        public override double FoodRequired { get { return 0.1; } }
                
    }
}
