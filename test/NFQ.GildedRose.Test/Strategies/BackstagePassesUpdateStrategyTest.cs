using FluentAssertions;
using NFQ.GildedRose.Domain.Entities;
using Xunit;

namespace NFQ.GildedRose.Test.Strategies
{
    public class BackstagePassesUpdateStrategyTest : BaseTest
    {
        [Fact]
        public void GivenUpdateBackstagePassesItem_WhenQualityIsNotMaxAndSellInNotPassed_ThenSellInShouldDecreaseAndQualityShouldIncrease()
        {
            var item = new Item { Name = "Backstage passes", SellIn = 15, Quality = 0 };
            BackstagePassesUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(14);
            item.Quality.Should().Be(1);
        }

        [Fact]
        public void GivenUpdateBackstagePassesItem_WhenQualityIsNotMaxAndSellIn10Days_ThenSellInShouldDecreaseAndQualityShouldIncreaseByTwo()
        {
            var item = new Item { Name = "Backstage passes", SellIn = 10, Quality = 0 };
            BackstagePassesUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(9);
            item.Quality.Should().Be(2);
        }

        [Fact]
        public void GivenUpdateBackstagePassesItem_WhenQualityIsNotMaxAndSellIn5Days_ThenSellInShouldDecreaseAndQualityShouldIncreaseByThree()
        {
            var item = new Item { Name = "Backstage passes", SellIn = 5, Quality = 0 };
            BackstagePassesUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(4);
            item.Quality.Should().Be(3);
        }

        [Fact]
        public void GivenUpdateBackstagePassesItem_WhenQualityIsMaxAndSellInNotPassed_ThenQualityShouldNotIncrease()
        {
            var item = new Item { Name = "Backstage passes", SellIn = 5, Quality = 50 };
            BackstagePassesUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(4);
            item.Quality.Should().Be(50);
        }

        [Fact]
        public void GivenUpdateBackstagePassesItem_WhenSellInPassed_ThenQualityShouldBeZero()
        {
            var item = new Item { Name = "Backstage passes", SellIn = 0, Quality = 15 };
            BackstagePassesUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(-1);
            item.Quality.Should().Be(0);
        }
    }
}