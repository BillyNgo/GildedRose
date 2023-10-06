using NFQ.GildedRose.Domain.Entities;
using NFQ.GildedRose.Domain.Strategies;

namespace NFQ.GildedRose.Domain.Factories
{
    public interface IUpdateStrategyFactory
    {
        IUpdateStrategy Create(Item item);
    }
}
