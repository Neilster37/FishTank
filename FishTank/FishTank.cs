using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishTank
{
    public class FishTank
    {
        public FishTank()
        {
            Fish = new List<Fish>();
        }

        public double Feed
        {
            get
            {
                double totalFood = 0;
                foreach (var fish in Fish)
                {
                    totalFood = totalFood + fish.FoodRequired;
                }
                return totalFood;
            }

        }

        public void AddFish(Fish fish)
        {
            Fish.Add(fish);
        }

        public IEnumerator GetEnumerator()
        {
            return Fish.GetEnumerator();
        }
        
        public List<Fish> Fish;

        /*
         <FishTank>
            <TotalFeed>0.4</TotalFeed>
            <Fishes>
                <Fish>
                    <Name>Simon</Name>
                    <Type>
                        <Name>Goldfish</Name>
                        <Feed>0.1</Feed>
                    </Type>
                </Fish>
                <Fish>
                    <Name>PeterSimon</Name>
                    <Type>
                        <Name>Babelfish</Name>
                        <Feed>0.3</Feed>
                    </Type>
                </Fish>
            </Fishes>
        </FishTank>
         */

        public void WriteAllFishToConsole()
        {
            foreach (var fish in Fish)
            {
                Console.WriteLine(fish.Name + " (" + fish.FishType + ")");
            }
        }
    }
}
