using BikeShopCode;

namespace BikeShopTest
{
    public class Tests
    {

        [Test]
        public void BikeConstructorSetsVariables()
        {
            Bike bike = new Bike("red", ModelTypes.Cosmic, 100);
            Assert.That(bike.Color, Is.EqualTo("red"));
            Assert.AreEqual(ModelTypes.Cosmic, bike.GetModel());
            Assert.AreEqual(100, bike.Price);
            Assert.That(bike.IsSold, Is.False);
        }

        [Test]
        public void BikeHasStaticList()
        {
            Assert.That(BikeShop.BikeList, Is.TypeOf<List<Bike>>());
            Assert.That(BikeShop.BikeList, Is.Not.Null);
        }

        [Test]
        public void BikeSoldFalse() 
        {
            Bike bike = new Bike("red", ModelTypes.Cosmic, 100);
            Assert.That(bike.IsSold, Is.False);
        }
        
        [Test]
        public void BikeHasBeenSold()
        {
            Bike bike = new Bike("red", ModelTypes.Cosmic, 100);
            Assert.That(bike.Sell, Throws.Nothing);
            Assert.That(bike.IsSold, Is.True);
        }

        [Test]
        public void BikeAdded()
        {
            Bike bike = new Bike("red", ModelTypes.Cosmic, 100);
            BikeShop.Add(bike);
            Assert.AreEqual(1, BikeShop.BikeList.Count);
        }
        
        [Test]
        public void BikeDeletedFromList()
        {
            Bike bike = new Bike("red", ModelTypes.Cosmic, 100);
            BikeShop.Add(bike);
            Assert.AreEqual(2, BikeShop.BikeList.Count);
            BikeShop.Remove(bike);
            Assert.AreEqual(1, BikeShop.BikeList.Count);
        }

        [Test]
        public void IsBikeSold()
        {
            Bike bike = new Bike("red", ModelTypes.Cosmic, 100);
            Assert.That(bike.Sold(), Is.False);
            bike.Sell();
            Assert.That(bike.Sold(), Is.True);
        }
        
        [Test]
        public void BikeColorChange()
        {
            Bike bike = new Bike("red", ModelTypes.Cosmic, 100);
            bike.ColorChange("blue");
            Assert.AreEqual("blue", bike.Color);
        }

        [Test]
        public void BikeModelOnChangeCheck()
        {
            Bike bike = new Bike("red", ModelTypes.Cosmic, 100);
            bike.Model = ModelTypes.Stallion;
            Assert.AreEqual(bike.GetModel(), ModelTypes.Stallion);
        }
    }
}