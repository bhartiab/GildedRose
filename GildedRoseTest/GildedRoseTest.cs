using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Katas
{
    public class GuildedRoseTest
    {
        
        [Theory]
        [InlineData("Quality of an item degrades daily", 1, 20, 19)]
        [InlineData("Quality of an item degrades twice if sell date is passed", 0, 20, 18)]
        [InlineData("Quality of an item is never negative", 10, 0, 0)]
        [InlineData("Quality of an item doesnt change if set to negative (edge case)", 10, -1, -1)]
        [InlineData("Normal items can have quality more than 50", 10, 54, 53)]
        public void NormalItemTests(string testName, int sellIn, int quality, int expectedQuality)
        {
            var actual = GildedRose.AgeItem(new Item("NormalItem", sellIn, quality));
            actual.Quality.Should().Be(expectedQuality);
            actual.SellIn.Should().Be(sellIn - 1);
        }
        
        [Theory]
        [InlineData("Backstage Pass quality increases by 1 when there are 99 days (more than 10 days)", 99, 20, 21)]
        [InlineData("Backstage Pass quality increases by 1 when there are ll days (more than 10 days)", 11, 20, 21)]
        [InlineData("Backstage Pass quality increases by 2 when there are 10 days (10 days or less)", 10, 20, 22)]
        [InlineData("Backstage Pass quality increases by 2 when there are 6 days (10 days or less)", 6, 20, 22)]
        [InlineData("Backstage Pass quality increases by 3 when there are 5 days (5 days or less)", 5, 20, 23)]
        [InlineData("Backstage Pass quality increases by 3 when there is 1 day left (5 days or less)", 1, 20, 23)]
        [InlineData("Backstage Pass quality drops to zero when no days left", 0, 20, 0)]
        public void BackstagePassesTests(string testName, int sellIn, int quality, int expectedQuality)
        {
            var actual = GildedRose.AgeItem(new Item("Backstage passes to a TAFKAL80ETC concert", sellIn, quality));
            actual.Quality.Should().Be(expectedQuality);
            actual.SellIn.Should().Be(sellIn - 1);
        }
        
        [Theory]
        [InlineData("Aged Brie increases quality", 10, 20, 21)]
        [InlineData("Aged Brie increases quality by one on the last day", 1, 20, 21)]
        [InlineData("Aged Brie increases quality by two when expired", 0, 20, 22)]
        [InlineData("Aged Brie increases quality by two when past expiration", -99, 20, 22)]
        [InlineData("Aged Brie should not increase quality more than 50", 10, 50, 50)]
        [InlineData("If Aged Brie quality greater than 50, quality does not increase", 10, 51, 51)]
        public void AgedBrieTests(string testName, int sellIn, int quality, int expectedQuality)
        {
            var actual = GildedRose.AgeItem(new Item("Aged Brie", sellIn, quality));
            actual.Quality.Should().Be(expectedQuality);
            actual.SellIn.Should().Be(sellIn - 1);
        }
        
        [Theory]
        [InlineData("Sulfuras does not change quality or sell in", 1, 20, 20)]
        [InlineData("Sulfuras does not change quality or sell in", 0, 80, 80)]
        [InlineData("Sulfuras does not change quality or sell in", -1, 80, 80)]
        public void TestSulfurasShouldNotDecreaseQualityAndNeverToBeSold(string testName, int sellIn, int quality, int expectedQuality)
        {
            var actual = GildedRose.AgeItem(new Item("Sulfuras, Hand of Ragnaros", sellIn, quality));

            actual.Quality.Should().Be(expectedQuality);
            actual.SellIn.Should().Be(sellIn);
        }
        
        // TODO:  "Conjured" items degrade in Quality twice as fast as normal items
        
    }
}
