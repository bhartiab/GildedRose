using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Katas
{
    public class GuildedRoseTest
    {
        
        [Fact]
        public void TestAgedBrieShouldIncreaseQualityAndDecreaseSellIn()
        {
            var inputItem = new Item("Aged Brie", 2, 0);

            var actual=  GildedRose.updateQualityPerItem(inputItem);

            actual.Quality.Should().Be(1);
            actual.SellIn.Should().Be(1);
        }
        [Fact]
        public void TestSulfurasShouldNotDecreaseQualityAndNeverToBeSold()
        {

            var inputItem = new Item("Sulfuras, Hand of Ragnaros", 0, 80);

            var actual = GildedRose.updateQualityPerItem(inputItem);

            actual.Quality.Should().Be(80);
            actual.SellIn.Should().Be(0);
        }
        [Fact]
        public void TestQualityDegradeTwiceIfSellDatePassed()
        {
            var inputItem = new Item("NormalItem",0,4);
            
            var actual = GildedRose.updateQualityPerItem(inputItem); 
            
            actual.Quality.Should().Be(2);

            actual.SellIn.Should().Be(-1);

        }
        [Fact]
        public void TestQualityOfAnItemNeverNegative()
        {
            var inputItem = new Item("NormalItem", 1, 0);

            var actual = GildedRose.updateQualityPerItem(inputItem);

            actual.Quality.Should().Be(0);

        }
        [Fact]
        public void TestNormalItemsCanHaveQualityMoreThan50()
        {
            var inputItem = new Item("NormalItem", 1, 54);

            var actual = GildedRose.updateQualityPerItem(inputItem);

            actual.Quality.Should().Be(53);

        }
        [Fact]
        public void TestAgedBrieShouldNotIncreaseQualityMoreThan50()
        {
            var inputItem = new Item("Aged Brie", 2, 50);

            var actual = GildedRose.updateQualityPerItem(inputItem);

            actual.Quality.Should().Be(50);
        }
        [Fact]
        public void TestBackstagePasses()
        {
           // "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
            var inputItem = new Item("Backstage passes to a TAFKAL80ETC concert", 10, 20);

            var actual = GildedRose.updateQualityPerItem(inputItem);
            // Quality increases by 2 when there are 10 days 
            actual.Quality.Should().Be(22);
            actual.SellIn.Should().Be(9);


        }
    }
}
