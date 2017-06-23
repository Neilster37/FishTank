using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank
{
    public class BabelFish : Fish
    {
        public BabelFish() : base() { }
        public BabelFish(string name) : base(name) { }
        public override string FishType { get { return "BabelFish"; } }
        public override double FoodRequired { get { return 0.3; } }
                
    }
}
