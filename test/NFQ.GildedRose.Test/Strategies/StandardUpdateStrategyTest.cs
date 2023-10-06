using FluentAssertions;
using NFQ.GildedRose.Domain.Entities;
using Xunit;

namespace NFQ.GildedRose.Test.Strategies
{
    public class StandardUpdateStrategyTest : BaseTest
    {
        [Fact]
        public void GivenUpdateStandardItem_WhenAndSellInNotPassed_ThenSellInShouldDecreaseAndQualityShouldDecrease()
        {
            var item = new Item { Name = "Standard", SellIn = 5, Quality = 30 };
            StandardUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(4);
            item.Quality.Should().Be(29);
        }

        [Fact]
        public void GivenUpdateStandardItem_WhenAndSellInPassed_ThenSellInShouldDecreaseAndQualityShouldDecreaseTwice()
        {
            var item = new Item { Name = "Standard", SellIn = 0, Quality = 30 };
            StandardUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(-1);
            item.Quality.Should().Be(28);
        }

        [Fact]
        public void GivenUpdateStandardItem_WhenAndSellInPassedAndQualityIsZero_ThenSellInShouldDecreaseAndQualityShouldNotNegative()
        {
            var item = new Item { Name = "Standard", SellIn = 0, Quality = 0 };
            StandardUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(-1);
            item.Quality.Should().Be(0);
        }

        [Fact]
        public void GivenUpdateStandardItem_WhenSellInNotPassedAndQualityIsZero_ThenSellInShouldDecreaseAndQualityShouldNotNegative()
        {
            var item = new Item { Name = "Standard", SellIn = 5, Quality = 0 };
            StandardUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(4);
            item.Quality.Should().Be(0);
        }
    }
}