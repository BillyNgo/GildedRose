using NFQ.GildedRose.Domain.Entities;

namespace NFQ.GildedRose.Domain.Strategies
{
    public class BackstagePassesUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            if (item.Quality < 50) item.Quality++;
            if (item is { SellIn: < 10, Quality: < 50 }) item.Quality++;
            if (item is { SellIn: < 5, Quality: < 50 }) item.Quality++;
            if (item.SellIn < 0) item.Quality = 0;
        }
    }
}
