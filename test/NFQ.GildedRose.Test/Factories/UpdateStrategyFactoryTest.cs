using FluentAssertions;
using NFQ.GildedRose.Domain.Entities;
using NFQ.GildedRose.Test.Strategies;
using Xunit;

namespace NFQ.GildedRose.Test.Factories
{
    public class UpdateStrategyFactoryTest : BaseTest
    {
        [Theory]
        [InlineData("Sulfuras", 10, 3)]
        [InlineData("Aged Brie", 0, 50)]
        [InlineData("Conjured", -10, 80)]
        [InlineData("Backstage Passes", -10, -80)]
        public void GivenCreateStrategy_ThenShouldCreateCorrectStrategy(string name, int sellIn, int quality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            var strategy = UpdateStrategyFactory.Create(item);
            strategy.GetType().Name.Should().Be(name.Replace(" ", "") + "UpdateStrategy");
        }

        [Theory]
        [InlineData("Test", 10, 3)]
        [InlineData("+5 Dexterity Vest", 0, 50)]
        [InlineData("Elixir of the Mongoose", -10, 80)]
        [InlineData("OMG", -10, -80)]
        public void GivenCreateStrategy_WhenItemNameIsNotInList_ThenShouldCreateStandardStrategy(string name, int sellIn, int quality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            var strategy = UpdateStrategyFactory.Create(item);
            strategy.GetType().Should().Be(StandardUpdateStrategy.GetType());
        }
    }
}