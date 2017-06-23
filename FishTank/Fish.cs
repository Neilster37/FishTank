using System.Collections;

namespace FishTank
{
    public abstract class Fish
    {
        protected Fish() { }
        protected Fish(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public abstract string FishType { get; }

        public abstract double FoodRequired { get; }
    }
}