using NFQ.GildedRose.Domain.Factories;
using System.Reflection;
using NFQ.GildedRose.Domain.Entities;
using Ninject;

namespace NFQ.GildedRose.Console
{
    public class Program
    {
        private readonly IUpdateStrategyFactory _updateStrategyFactory;
        private readonly IList<Item> _items =  DefaultItems();

        public Program(IUpdateStrategyFactory updateStrategyFactory)
        {
            _updateStrategyFactory = updateStrategyFactory;
        }

        public static void Main()
        {
            System.Console.WriteLine("OMGHAI!");

            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var updateStrategyFactory = kernel.Get<IUpdateStrategyFactory>();

            var app = new Program(updateStrategyFactory);

            app.UpdateQualityForMonth();
            System.Console.ReadKey();
        }

        private void UpdateQualityForMonth()
        {
            for (var i = 0; i < 31; i++)
            {
                System.Console.WriteLine("-------- day " + i + " --------");
                System.Console.WriteLine("name, sellIn, quality");
                foreach (var item in _items)
                {
                    System.Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }
                System.Console.WriteLine("");
                UpdateQuality();
            }
        }

        private void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var updateStrategy = _updateStrategyFactory.Create(item);
                updateStrategy.UpdateItem(item);
            }
        }

        private static List<Item> DefaultItems()
        {
            return new List<Item>
            {
                new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }

            };
        }
    }
}