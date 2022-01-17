using DuranceBagKataGitHub;
using DuranceBagKataGitHub.Items;
using Xunit;
using System.Linq;

namespace DuranceBagKataGitHubTests
{
    public class BagTests
    {
        [Fact]
        public void AddItemToBackpack()
        {
            // Arrange
            var d = new Durance();

            // Act
            d.Find(new Iron());
            d.Find(new Copper());

            // Assert
            Assert.Equal(2, d.Bags
                .Where(x => x.Category == Category.Backpack)
                .Single().Items.Count);
        }

        [Fact]
        public void OrganizeMetals()
        {
            // Arrange
            var d = new Durance();

            // Act
            d.Find(new Iron());
            d.Find(new Copper());
            d.Organize();

            var metalBag = d.Bags.Where(x => x.Category == Category.Metal).First();

            // Assert
            Assert.Equal(2, metalBag.Items.Count);
        }

        [Fact]
        public void OrganizeMetalsAndOnePieceOfClothing()
        {
            // Arrange
            var d = new Durance();

            // Act
            d.Find(new Iron());
            d.Find(new Copper());
            d.Find(new Silk());
            d.Organize();

            var metalBag = d.Bags.Where(x => x.Category == Category.Metal).First();

            // Assert
            Assert.Equal(2, metalBag.Items.Count);
            Assert.Single(d.Bags.Where(x => x.Category == Category.Backpack).Single().Items);
        }

        [Fact]
        public void AddNineItemsToBackpack()
        {
            // Arrange
            var d = new Durance();

            // Act
            d.Find(new Iron());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Sword());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Iron());
            d.Find(new Copper());

            // Assert
            Assert.Equal(8, d.Bags[0].Items.Count);
            Assert.Single(d.Bags[1].Items);
        }

        [Fact]
        public void TotallyFillBags()
        {
            // Arrange
            var d = new Durance();

            // Act
            d.Find(new Iron());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Sword());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Iron());

            d.Find(new Iron());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Sword());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Iron());

            d.Find(new Iron());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Sword());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Iron());

            var rose = new Rose();
            d.Find(rose);

            // Assert
            Assert.Equal(8, d.Bags[0].Items.Count); // backpack
            Assert.Equal(4, d.Bags[1].Items.Count);
            Assert.Equal(4, d.Bags[2].Items.Count);
            Assert.Equal(4, d.Bags[3].Items.Count);
            Assert.Equal(4, d.Bags[4].Items.Count);

            Assert.True(d.Bags.Where(x => x.Items.Any(y => y.ItemName == "Sword")).Any());
            Assert.False(d.Bags.Where(x => x.Items.Any(y => y.ItemName == "Rose")).Any());
        }
    }
}
