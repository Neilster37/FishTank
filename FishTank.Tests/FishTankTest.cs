using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishTank.Tests
{
    [TestFixture]
    public class FishTankTest
    {
        [Test]
        public void CreatingGoldFish_SetsDefaultProperties()
        {
            //Arrange / Act
            var goldFish = new GoldFish("Eric");

            //Assert
            Assert.That(goldFish.FoodRequired, Is.EqualTo(0.1));
            Assert.That(goldFish.Name, Is.EqualTo("Eric"));
        }

        [Test]
        public void CreatingFishTank_HasNoFishInTank()
        {
            //Arrange / Act
            var fishTank = new FishTank();
            
            //Assert
            Assert.That(fishTank.Fish.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddingGoldFish_AddsFishToTank()
        {
            //Arrange / Act
            var fishTank = new FishTank();
            fishTank.AddFish(new GoldFish ("Goldy"));

            //Assert
            Assert.That(fishTank.Fish.Count, Is.EqualTo(1));
            Assert.That(fishTank.Fish.ElementAt(0).Name, Is.EqualTo("Goldy"));
        }

        [Test]
        public void AddingGoldFishAndBabelFishAndAngelFish_UpdatesFishInTank()
        {
            //Arrange / Act
            var fishTank = new FishTank();

            fishTank.AddFish(new GoldFish("Neil"));
            fishTank.AddFish(new BabelFish("Zaphod"));
            fishTank.AddFish(new AngelFish("Charlies"));

            //Assert
            Assert.That(fishTank.Fish.Count, Is.EqualTo(3));            
        }

        [Test]
        public void Feed_CalculatesTotalFishFoodForAllFishInTank()
        {
            //Arrange / Act
            var fishTank = new FishTank();

            fishTank.AddFish(new GoldFish("Neil"));
            fishTank.AddFish(new GoldFish("Boris"));
            fishTank.AddFish(new BabelFish("Zaphod"));
            fishTank.AddFish(new AngelFish("Charlies"));

            //Assert
            Assert.That(fishTank.Feed, Is.EqualTo(0.7));
        }

        public void LoadingXmlWithOneFishPutsFishInTank()
        {
            //Arrange / Act
            var fishTank = new FishTank();

            fishTank.AddFish(new GoldFish("Neil"));
            fishTank.AddFish(new GoldFish("Boris"));
            fishTank.AddFish(new BabelFish("Zaphod"));
            fishTank.AddFish(new AngelFish("Charlies"));

            //Assert
            Assert.That(fishTank.Feed, Is.EqualTo(0.7));
        }
    }
}
