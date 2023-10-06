using FluentAssertions;
using NFQ.GildedRose.Domain.Entities;
using Xunit;

namespace NFQ.GildedRose.Test.Strategies
{
    public class SulfurasUpdateStrategyTest : BaseTest
    {
        [Theory]
        [InlineData("Sulfuras", 10, 3)]
        [InlineData("Sulfuras", 0, 50)]
        [InlineData("Sulfuras", -10, 80)]
        [InlineData("Sulfuras", -10, -80)]
        public void GivenUpdateSulfurasItem_ThenShouldNotUpdate(string name, int sellIn, int quality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            SulfurasUpdateStrategy.UpdateItem(item);
            item.SellIn.Should().Be(sellIn);
            item.Quality.Should().Be(quality);
        }
    }
}