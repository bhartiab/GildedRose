using System;
namespace Katas
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public Item(string name, int sellIn, int quality)
        {
            Quality = quality;
            SellIn = sellIn;
            Name = name;
        }
    }
}
