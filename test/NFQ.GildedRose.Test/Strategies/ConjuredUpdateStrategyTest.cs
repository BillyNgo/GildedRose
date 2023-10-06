using FluentAssertions;
using NFQ.GildedRose.Domain.Entities;
using Xunit;

namespace NFQ.GildedRose.Test.Strategies
{
    public class ConjuredUpdateStrategyTest : BaseTest
    {
        [Fact]
        public void GivenUpdateConjuredItem_WhenAndSellInNotPassed_ThenSellInShouldDecreaseAndQualityShouldDecreaseByTwo()
        {
            var item = new Item { Name = "Conjured", SellIn = 5, Quality = 30 };
            ConjuredUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(4);
            item.Quality.Should().Be(28);
        }

        [Fact]
        public void GivenUpdateConjuredItem_WhenAndSellInPassed_ThenSellInShouldDecreaseAndQualityShouldDecreaseByFour()
        {
            var item = new Item { Name = "Conjured", SellIn = 0, Quality = 30 };
            ConjuredUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(-1);
            item.Quality.Should().Be(26);
        }

        [Fact]
        public void GivenUpdateConjuredItem_WhenAndSellInPassedAndQualityIsZero_ThenSellInShouldDecreaseAndQualityShouldNotNegative()
        {
            var item = new Item { Name = "Conjured", SellIn = 0, Quality = 0 };
            ConjuredUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(-1);
            item.Quality.Should().Be(0);
        }

        [Fact]
        public void GivenUpdateConjuredItem_WhenSellInNotPassedAndQualityIsZero_ThenSellInShouldDecreaseAndQualityShouldNotNegative()
        {
            var item = new Item { Name = "Conjured", SellIn = 5, Quality = 0 };
            ConjuredUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(4);
            item.Quality.Should().Be(0);
        }
    }
}