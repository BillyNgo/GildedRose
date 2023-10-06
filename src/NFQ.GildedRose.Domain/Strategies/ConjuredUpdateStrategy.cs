using NFQ.GildedRose.Domain.Entities;

namespace NFQ.GildedRose.Domain.Strategies
{
    public class ConjuredUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            if (item.Quality > 0) item.Quality -= 2;
            if (item is { SellIn: < 0, Quality: > 0 }) item.Quality -= 2;
            if (item.Quality < 0) item.Quality = 0;
        }
    }
}
