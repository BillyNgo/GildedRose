using NFQ.GildedRose.Domain.Entities;
using NFQ.GildedRose.Domain.Strategies;

namespace NFQ.GildedRose.Domain.Factories
{
    public class UpdateStrategyFactory : IUpdateStrategyFactory
    {
        public IUpdateStrategy Create(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return item.Name switch
            {
                { } name when name.Contains("Aged Brie", StringComparison.CurrentCultureIgnoreCase) => new AgedBrieUpdateStrategy(),
                { } name when name.Contains("Backstage passes", StringComparison.CurrentCultureIgnoreCase) => new BackstagePassesUpdateStrategy(),
                { } name when name.Contains("Sulfuras", StringComparison.CurrentCultureIgnoreCase) => new SulfurasUpdateStrategy(),
                { } name when name.Contains("Conjured", StringComparison.CurrentCultureIgnoreCase) => new ConjuredUpdateStrategy(),
                _ => new StandardUpdateStrategy()
            };
        }
    }
}
