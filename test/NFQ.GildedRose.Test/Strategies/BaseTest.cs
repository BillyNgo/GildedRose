using NFQ.GildedRose.Domain.Factories;
using NFQ.GildedRose.Domain.Strategies;

namespace NFQ.GildedRose.Test.Strategies
{
    public class BaseTest : IDisposable
    {
        public readonly AgedBrieUpdateStrategy AgedBrieUpdateStrategy;
        public readonly BackstagePassesUpdateStrategy BackstagePassesUpdateStrategy;
        public readonly ConjuredUpdateStrategy ConjuredUpdateStrategy;
        public readonly StandardUpdateStrategy StandardUpdateStrategy;
        public readonly SulfurasUpdateStrategy SulfurasUpdateStrategy;

        public readonly UpdateStrategyFactory UpdateStrategyFactory;

        public BaseTest()
        {
            AgedBrieUpdateStrategy = new AgedBrieUpdateStrategy();
            BackstagePassesUpdateStrategy = new BackstagePassesUpdateStrategy();
            ConjuredUpdateStrategy = new ConjuredUpdateStrategy();
            StandardUpdateStrategy = new StandardUpdateStrategy();
            SulfurasUpdateStrategy = new SulfurasUpdateStrategy();
            UpdateStrategyFactory = new UpdateStrategyFactory();
        }
        public void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
            try
            {

            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }
}