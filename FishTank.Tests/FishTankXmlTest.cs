using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FishTank.Tests
{
    [TestFixture]
    public class FishTankXmlTest
    {
        [Test]
        public void FishTankXml_ThrowsException_IfFishTankIsNull()
        {
            //Arrange
            FishTank fishTank = null;

            //Act / Assert
            try
            {
                var fishXml = new FishTankXml(fishTank);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Fish Tank cannot be null"));
            }
        }


        [Test]
        public void GenerateFishTankXml_CreatesXmlDocumentWithNoFish_IfNoFishInTank()
        {
            //Arrange
            var fishTank = new FishTank();

            var fishXml = new FishTankXml(fishTank);

            //Act
            var fishXmlDocument = fishXml.GenerateFishTankXml();


            //Assert
            double totalFeed = Convert.ToDouble( fishXmlDocument.Root.Element("TotalFeed").Value);
            Assert.That(totalFeed, Is.EqualTo(0));
            Assert.That(fishXmlDocument.Root.Element("Fishes").IsEmpty, Is.True);
        }


        [Test]
        public void ImportFishTankXmlToFishTank_AddsFishesToFishTank ()
        {
            //Arrange
            string fishXml = @"<?xml version=""1.0"" encoding=""utf-8""?>
<FishTank>
  <TotalFeed>0.7</TotalFeed>
  <Fishes>
    <Fish FishType=""FishTank.GoldFish, FishTank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"">
      <Name>Neil</Name>
      <FoodRequired>0.1</FoodRequired>
    </Fish>
    <Fish FishType=""FishTank.GoldFish, FishTank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"">
      <Name>Boris</Name>
      <FoodRequired>0.1</FoodRequired>
    </Fish>
    <Fish FishType=""FishTank.BabelFish, FishTank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"">
      <Name>Zaphod</Name>
      <FoodRequired>0.3</FoodRequired>
    </Fish>
    <Fish FishType=""FishTank.AngelFish, FishTank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"">
      <Name>Charlie</Name>
      <FoodRequired>0.2</FoodRequired>
    </Fish>
  </Fishes>
</FishTank>";
            XDocument fishXDoc = XDocument.Parse(fishXml);

            FishTank fishTank = new FishTank();
            FishTankXml fishTankXml = new FishTankXml();


            //act
            fishTank = fishTankXml.ImportFishTankXmlToFishTank(fishXDoc);

            //assert
            Assert.That(fishTank.Fish.Count, Is.EqualTo(4));
            Assert.That(fishTank.Feed, Is.EqualTo(0.7));
        }
    }
}
