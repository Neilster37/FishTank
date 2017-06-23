using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FishTank
{
    public class FishTankXml
    {
        public FishTankXml() { }
        public FishTankXml(FishTank fishTank)
        {
            //todo throw exception if null
            if (fishTank == null)
            {
                throw new ArgumentException("Fish Tank cannot be null"); ;
            }

            FishTank = fishTank;
        }
        private FishTank FishTank { get; set; }

        public XDocument GenerateFishTankXml()
        {
            XDocument fishTankXDoc = new XDocument(
                new XElement("FishTank",
                    new XElement("TotalFeed", FishTank.Feed),
                    new XElement("Fishes")
                )
            );

            var fishesXml = fishTankXDoc.Descendants("Fishes").FirstOrDefault();
            if (fishesXml != null)
            {
                foreach (var fish in FishTank.Fish)
                {
                    fishesXml.Add(new XElement("Fish",
                        new XAttribute("FishType", fish.GetType().AssemblyQualifiedName),
                        new XElement("Name", fish.Name),
                        new XElement("FoodRequired", fish.FoodRequired)
                        )
                    );
                }
            }
            fishTankXDoc.Declaration = new XDeclaration("1.0", "utf-8", "true");
            return fishTankXDoc;
        }

        public void SaveFishTankXMLToDisk(XDocument xmlDocument, string filePath)
        {
            xmlDocument.Save(filePath);
        }

        public void GenerateAndSaveFishTankXml(string filePath)
        {
            var xmlToSave = new XDocument();
            xmlToSave = GenerateFishTankXml();

            SaveFishTankXMLToDisk(xmlToSave, filePath);
        }



        public XDocument LoadFishTankFromFile (string filePath)
        {
            XDocument importedFileXml = XDocument.Load(filePath);
            return importedFileXml;
        }

        public FishTank ImportFishTankXmlToFishTank (XDocument fishTankXml)
        {
            var fishTank = new FishTank();

            foreach (XElement xe in fishTankXml.Descendants("Fish"))
            {
                string assemblyQualifiedName = xe.Attribute("FishType").Value;
                string fishName = xe.Element("Name").Value;

                // Get the type contained in the name string
                Type type = Type.GetType(assemblyQualifiedName, true);

                // create an instance of that type
                Fish newFish = Activator.CreateInstance(type) as Fish;
                newFish.Name = fishName;

                fishTank.AddFish((Fish)newFish);
            }

            return fishTank;
        }

        public FishTank LoadFishTankFromXmlFileAndCreateFishTank(string filePath)
        {
            var fishXml = new XDocument(LoadFishTankFromFile(filePath));
            var fishTank = new FishTank();
            fishTank = ImportFishTankXmlToFishTank(fishXml);
            return fishTank;
        }

    }
}
