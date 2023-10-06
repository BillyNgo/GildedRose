using FluentAssertions;
using NFQ.GildedRose.Domain.Entities;
using Xunit;

namespace NFQ.GildedRose.Test.Strategies
{
    public class AgedBrieUpdateStrategyTest : BaseTest
    {
        [Fact]
        public void GivenUpdateAgedBrieItem_WhenQualityIsNotMaxAndSellInNotPassed_ThenSellInShouldDecreaseAndQualityShouldIncrease()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 0 };
            AgedBrieUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(4);
            item.Quality.Should().Be(1);
        }

        [Fact]
        public void GivenUpdateAgedBrieItem_WhenQualityIsNotMaxAndSellInPassed_ThenSellInShouldDecreaseAndQualityShouldIncreaseTwice()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };
            AgedBrieUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(-1);
            item.Quality.Should().Be(2);
        }

        [Fact]
        public void GivenUpdateAgedBrieItem_WhenQualityIsMaxAndSellInPassed_ThenSellInShouldDecreaseAndQualityShouldNotIncrease()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };
            AgedBrieUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(-1);
            item.Quality.Should().Be(50);
        }

        [Fact]
        public void GivenUpdateAgedBrieItem_WhenQualityIsMaxAndSellInNotPassed_ThenSellInShouldDecreaseQualityShouldNotIncrease()
        {
            var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 };
            AgedBrieUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(4);
            item.Quality.Should().Be(50);
        }
    }
}