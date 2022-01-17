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
                .Where(x => x.BagCategory == BagCategory.Backpack)
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

            var metalBag = d.Bags.Where(x => x.BagCategory == BagCategory.Metal).First();

            // Assert
            Assert.Equal(2, metalBag.Items.Count);
        }

        [Fact]
        public void OrganizeMetalsAndOnePieceOfHerbs()
        {
            // Arrange
            var d = new Durance();

            // Act
            d.Find(new Iron());
            d.Find(new Copper());
            d.Find(new Marigold());
            d.Organize();

            var backpack = d.Bags.Where(x => x.BagCategory == BagCategory.Backpack).Single();
            var metalBag = d.Bags.Where(x => x.BagCategory == BagCategory.Metal).First();

            // Assert
            Assert.Equal(2, metalBag.Items.Count);
            Assert.Single(d.Bags.Where(x => x.BagCategory == BagCategory.Backpack).Single().Items);
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
        public void OrganizeTooMuchMetal()
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

            d.Organize();

            var backpack = d.Bags[0];
            var metalBag = d.Bags.Where(x => x.BagCategory == BagCategory.Metal).Single();
            var weaponBag = d.Bags.Where(x => x.BagCategory == BagCategory.Weapons).Single();

            // Assert
            Assert.Equal(4, backpack.Items.Count);
            Assert.Equal(4, metalBag.Items.Count);
            Assert.Single(weaponBag.Items);
            Assert.False(metalBag.Items.Any(x => x.ItemName == "Iron"));
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

            d.Find(new Rose());

            var backpack = d.Bags[0];

            // Assert
            Assert.Equal(8, backpack.Items.Count); // backpack
            Assert.Equal(4, d.Bags[1].Items.Count);
            Assert.Equal(4, d.Bags[2].Items.Count);
            Assert.Equal(4, d.Bags[3].Items.Count);
            Assert.Equal(4, d.Bags[4].Items.Count);

            Assert.True(d.Bags.Where(x => x.Items.Any(y => y.ItemName == "Sword")).Any());
            Assert.False(d.Bags.Where(x => x.Items.Any(y => y.ItemName == "Rose")).Any());
        }
    }
}
