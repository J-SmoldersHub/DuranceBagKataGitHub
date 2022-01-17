using System.Collections.Generic;

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
                    new Bag(),
                    new WeaponsBag(),
                    new Bag()
                });
        }

        public void Find(Item item)
        {
            Backpack.Items.Add(item);
        }
    }
}
