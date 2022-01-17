using System.Collections.Generic;
using System.Linq;

namespace DuranceBagKataGitHub
{
    public class Durance
    {
        public List<Bag> Bags { get; set; } = new List<Bag>();

        public Durance()
        {
            AddBags();
        }

        private void AddBags()
        {
            Bags.AddRange(new List<Bag>
                {
                    new Backpack(),
                    new IronBag(),
                    new NormalBag(),
                    new WeaponsBag(),
                    new NormalBag()
                });
        }

        public void Organize()
        {
            List<Item> items = new List<Item>();
            foreach(var bag in Bags)
            {
                items.AddRange(bag.Items);
                bag.Items.Clear();
            }

            items.OrderBy(x => x.ItemName);

            foreach (var item in items)
            {
                bool itemAdded = HasItemBeenAddedInCategorizedBag(item, item.Category);

                if (!itemAdded)
                {
                    AddItemDependingOnBagOrder(item);
                }
            }
        }

        public void Find(Item item)
        {
            AddItemDependingOnBagOrder(item);
        }

        private void AddItemDependingOnBagOrder(Item item)
        {
            foreach (var bag in Bags)
            {
                if (bag.Items.Count < bag.Size)
                {
                    bag.Items.Add(item);
                    break;
                }
            }
        }

        private bool HasItemBeenAddedInCategorizedBag(Item item, Category category)
        {
            var categorizedBags = Bags.Where(x => x.Category == category).ToList();
            foreach (var categorizedBag in categorizedBags)
            {
                if (categorizedBag.Items.Count < categorizedBag.Size)
                {
                    categorizedBag.Items.Add(item);
                    return true;
                }
            }

            return false;
        }
    }
}
