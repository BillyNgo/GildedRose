using NFQ.GildedRose.Domain.Entities;

namespace NFQ.GildedRose.Domain.Strategies
{
    public class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            if (item.Quality < 50) item.Quality++;
            if (item is { SellIn: < 0, Quality: < 50 }) item.Quality++;
        }
    }
}
