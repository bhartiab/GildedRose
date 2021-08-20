using System;
using System.Collections.Generic;

namespace Katas
{
    public class GildedRose
    {
        public IList<Item> Items { get; }

        public GildedRose(IList<Item> items)
        {
	        Items = items;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var items = new List<Item>
            {
	            new Item("+5 Dexterity Vest", 10, 20),
	            new Item("Aged Brie", 2, 0),
	            new Item("Elixir of the Mongoose", 5, 7),
	            new Item("Sulfuras, Hand of Ragnaros", 0, 80),
	            new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20),
	            new Item("Conjured Mana Cake", 3, 6)
            };

            var store = new GildedRose(items);
			store.AgeItems();
        }

		public void AgeItems()
		{
			foreach (var item in Items)
			{
				AgeItem(item);
			}
		}
		private static void AgeItem(Item item)
		{
			if (item.Name == "Sulfuras, Hand of Ragnaros")
			{
				return;
			}

			UpdateQualityForItem(item);
			--item.SellIn;

			if (item.SellIn < 0)
			{
				HandleExpiredItem(item);
			}
		}

        private static void UpdateQualityForItem(Item item)
        {
	        if (!ItemValueIncreasesWithAge(item))
	        {
		        DecreaseQuality(item);
	        }
	        else
	        {
		        IncreaseQuality(item);

		        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
		        {
			        IncreaseQualityForBackstageItem(item);
		        }
	        }
        }
        
        private static void IncreaseQualityForBackstageItem(Item item)
		{
			if (item.SellIn < 11)
				IncreaseQuality(item);

			if (item.SellIn < 6)
				IncreaseQuality(item);
		}

		private static void HandleExpiredItem(Item  item)
		{
			switch (item.Name)
			{
				case "Aged Brie":
					IncreaseQuality(item);
					break;
				case "Backstage passes to a TAFKAL80ETC concert":
					item.Quality = 0;
					break;
				default:
					DecreaseQuality(item);
					break;
			}
		}
		private static bool ItemValueIncreasesWithAge(Item item)
		{
			return item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert";
		}

		private static void IncreaseQuality(Item item)
		{
			if (item.Quality < 50)
			{
				item.Quality++;
			}
		}

		private static void DecreaseQuality(Item item)
		{
			if (item.Quality > 0)
			{
				item.Quality--;
			}
		}
    }
}
