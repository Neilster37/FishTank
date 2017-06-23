using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank
{
    public class AngelFish : Fish
    {
        public AngelFish() : base() { }
        public AngelFish(string name) : base(name) { }
        public override string FishType { get { return "AngelFish"; } }

        public override double FoodRequired { get { return 0.2; } }
                
    }
}
