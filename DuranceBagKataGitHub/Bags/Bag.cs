using System.Collections.Generic;

namespace DuranceBagKataGitHub.Bags
{
    public class Bag
    {
        public string BagName { get; set; }
        public int Size { get; set; }

        public List<Item> Items = new List<Item>();
        public BagCategory BagCategory;
    }
}
