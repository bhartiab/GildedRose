using System;
using System.Collections.Generic;

namespace Katas
{
    public class GildedRose
    {
        private static IList<Item> items = null;

        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

			items = new List<Item>();
			items.Add(new Item("+5 Dexterity Vest", 10, 20));
			items.Add(new Item("Aged Brie", 2, 0));
			items.Add(new Item("Elixir of the Mongoose", 5, 7));
			items.Add(new Item("Sulfuras, Hand of Ragnaros", 0, 80));
			items.Add(new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20));
			items.Add(new Item("Conjured Mana Cake", 3, 6));

			updateQuality();
        }

		public static void updateQuality()
		{
			for (int i = 0; i < items.Count; i++)
			{
				updateQualityPerItem(items[i]);
			}
		}
		public static Item updateQualityPerItem(Item item)
		{
			if (item.Name == "Sulfuras, Hand of Ragnaros")
			{
				return item;
			}

			UpdateQualityValue(item);
			UpdateSellInValue(item);

			return item;
		}

        private static void UpdateQualityValue(Item item)
        {
	        if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
			{
				if ((item.Quality > 0))
				{
					item.Quality--;
				}
			}
			else
			{
				if (item.Quality < 50)
				{
					item.Quality++;

					if (item.Name=="Backstage passes to a TAFKAL80ETC concert")
					{
						IncreaseQualityForBackstageItem(item);
					}
				}
			}
		}

		private static void IncreaseQualityForBackstageItem(Item item)
		{
			if (item.SellIn < 11 && item.Quality < 50)
			{
				item.Quality++;
			}

			if (item.SellIn < 6 && item.Quality < 50)
			{
				item.Quality++;
			}
		}
        private static void UpdateSellInValue(Item item)
		{
			item.SellIn = (item.SellIn - 1);

			if (item.SellIn < 0)
			{
				HandleExpiredItem(item);
			}
		}

		private static void HandleExpiredItem(Item  item)
		{
			if (item.Name != "Aged Brie")
			{
				if (item.Name!="Backstage passes to a TAFKAL80ETC concert")
				{
					if (item.Quality > 0)
					{
						item.Quality--;
					}
				}
				else
				{
					item.Quality = 0;
				}
			}
			else
			{
				if (item.Quality < 50)
				{
					item.Quality++;
				}
			}
		}
			 
	}
}
