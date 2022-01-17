using DuranceBagKataGitHub;
using DuranceBagKataGitHub.Items;
using System;
using Xunit;

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
            Assert.Equal(2, d.Backpack.Items.Count);
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
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Copper());
            d.Find(new Iron());
            d.Find(new Copper());

            // Assert
            Assert.Equal(8, d.Backpack.Items.Count);
            Assert.Single(d.Bags[0].Items);
        }
    }
}
