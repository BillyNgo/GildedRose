using NFQ.GildedRose.Domain.Entities;

namespace NFQ.GildedRose.Domain.Strategies
{
    public class SulfurasUpdateStrategy : IUpdateStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn = item.SellIn;
            item.Quality = item.Quality;
        }
    }
}
