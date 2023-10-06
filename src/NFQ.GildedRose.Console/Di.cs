using Ninject.Modules;
using NFQ.GildedRose.Domain.Factories;

namespace NFQ.GildedRose.Console
{
    public class Di : NinjectModule
    {
        public override void Load()
        {
            Bind<IUpdateStrategyFactory>().To<UpdateStrategyFactory>();
        }
    }
}
