using System.Collections.Generic;
using System.Linq;

namespace DuranceBagKataGitHub
{
    public class Durance
    {
        public Backpack Backpack { get; set; }
        public List<Bag> Bags { get; set; } = new List<Bag>();

        public Durance()
        {
            Backpack = new Backpack();
            AddBags();
        }

        private void AddBags()
        {
            Bags.AddRange(new List<Bag>
                {
                    new IronBag(),
                    new NormalBag(),
                    new WeaponsBag(),
                    new NormalBag()
                });
        }

        public void Organize()
        {
            List<Item> items = new List<Item>();

            items.AddRange(Backpack.Items);
            Backpack.Items.Clear();

            foreach(var bag in Bags)
            {
                items.AddRange(bag.Items);
                bag.Items.Clear();
            }

            items.OrderBy(x => x.ItemName);

            foreach (var item in items)
            {
                bool itemAdded = false;
                if (item.Category == Category.Metal)
                {
                    var metalBags = Bags.Where(x => x.Category == Category.Metal).ToList();
                    foreach (var metalBag in metalBags)
                    {
                        if (metalBag.Items.Count < metalBag.Size)
                        {
                            metalBag.Items.Add(item);
                            itemAdded = true;
                        }
                    }
                }

                if (!itemAdded)
                {
                    Backpack.Items.Add(item);
                }
            }
        }

        public void Find(Item item)
        {
            if (Backpack.Items.Count < Backpack.Size)
            {
                Backpack.Items.Add(item);
            }
            else
            {
                foreach (var bag in Bags)
                {
                    if (bag.Items.Count < bag.Size)
                    {
                        bag.Items.Add(item);
                        continue;
                    }
                }
            }
        }
    }
}
