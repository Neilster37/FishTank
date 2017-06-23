using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank

{
    class Program
    {
        static void Main(string[] args)
        {

            //FishTank fishTank = new FishTank();
            //fishTank.AddFish(new GoldFish("Neil"));
            //fishTank.AddFish(new GoldFish("Boris"));
            //fishTank.AddFish(new BabelFish("Zaphod"));
            //fishTank.AddFish(new AngelFish("Charlie"));
            ////fishTank.AddFish(new GoldFish() { Name = "Neil" });

            //Console.WriteLine(fishTank.Feed);

            //var fishXml = new FishXml(fishTank);
            //fishXml.GenerateAndSaveFishTankXml(@"c:\FishTank.xml");
            //fishTank.WriteAllFishToConsole();



            FishTank fishTank = new FishTank();
            var fishXml = new FishTankXml();
            fishTank = fishXml.LoadFishTankFromXmlFileAndCreateFishTank(@"c:\FishTank.xml");
            fishTank.WriteAllFishToConsole();
            fishTank.WriteAllFishToConsole();
        }
    }
}
