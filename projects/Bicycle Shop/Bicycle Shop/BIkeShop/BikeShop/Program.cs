using System.Runtime.CompilerServices;

namespace BikeShopCode
{
    public class BikeShop
    {
        public static List<Bike> BikeList = new List<Bike>();
        public static void Main(string[] args)
        {
        }
        public static void Add(Bike bike)
        {
            BikeList.Add(bike);
        }

        public static void Remove(Bike bike)
        {
            BikeList.Remove(bike);
        }
    }
    public class Bike
    {
        public string Color;
        public ModelTypes? Model;
        public int Price;
        public bool IsSold = false;

        public Bike(string color, ModelTypes? model, int price)
        {
            Color = color;
            Model = model;
            Price = price;
        }

        public ModelTypes? GetModel()
        {
            return Model;
        }
        
        public bool Sell()
        {
            IsSold = true;
            return IsSold;
        }
        
        public bool Sold()
        {
            return IsSold;
        }

        public void ColorChange(string color)
        {
            Color = color;
        }
    }

        public enum ModelTypes
        {
            Cosmic,
            Stallion,
            Pegasus,
            Unicorn,
            Dragon,
            Phoenix,
            Griffin
        }
}

