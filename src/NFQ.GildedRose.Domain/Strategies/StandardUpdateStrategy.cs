using NFQ.GildedRose.Domain.Entities;

namespace NFQ.GildedRose.Domain.Strategies
{
    public class StandardUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            if (item.Quality > 0) item.Quality--;
            if (item is { SellIn: < 0, Quality: > 0 }) item.Quality--;
            if (item.Quality < 0) item.Quality = 0;
        }
    }
}
