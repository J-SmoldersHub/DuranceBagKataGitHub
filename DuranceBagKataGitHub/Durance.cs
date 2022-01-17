using DuranceBagKataGitHub.Bags;
using System;
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

        public void Find(Item item)
        {
            AddItemDependingOnBagOrder(item);
        }

        public void Organize()
        {
            List<Item> items = new List<Item>();
            foreach(var bag in Bags)
            {
                items.AddRange(bag.Items);
                bag.Items.Clear();
            }

            items = items.OrderBy(x => x.ItemName).ToList();

            foreach (var item in items)
            {
                bool itemAdded = HasItemBeenAddedInCategorizedBag(
                    item,
                    ConvertToBagCategory(item.Category)
                    );

                if (!itemAdded)
                {
                    AddItemDependingOnBagOrder(item);
                }
            }
        }

        public void DisplayItems()
        {
            foreach (var bag in Bags)
            {
                Console.WriteLine(bag.BagName + ": ");
                foreach(var item in bag.Items)
                {
                    Console.WriteLine($"- {item.ItemName}");
                }

                Console.WriteLine();
            }
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

        private void AddBags()
        {
            Bags.AddRange(new List<Bag>
                {
                    new Backpack(),
                    new IronBag(),
                    new NormalBag(),
                    new WeaponsBag(),
                    new ClothingBag()
                });
        }

        private BagCategory ConvertToBagCategory(ItemCategory category)
        {
            switch (category)
            {
                case ItemCategory.None:
                    return BagCategory.None;
                case ItemCategory.Clothing:
                    return BagCategory.Clothing;
                case ItemCategory.Metal:
                    return BagCategory.Metal;
                case ItemCategory.Herbs:
                    return BagCategory.Herbs;
                case ItemCategory.Weapons:
                    return BagCategory.Weapons;
                default:
                    return BagCategory.None;
            }
        }

        private bool HasItemBeenAddedInCategorizedBag(Item item, BagCategory category)
        {
            var categorizedBags = Bags.Where(x => x.BagCategory == category).ToList();
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
