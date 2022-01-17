using System.Collections.Generic;

namespace DuranceBagKataGitHub
{
    public class Bag
    {
        public int Size { get; set; }

        public List<Item> Items = new List<Item>();
        public Category Category;
    }
}
