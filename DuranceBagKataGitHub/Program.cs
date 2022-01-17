using DuranceBagKataGitHub.Items;
using System;

namespace DuranceBagKataGitHub
{
    class Program
    {
        static void Main(string[] args)
        {
            var duranceTheWizard = new Durance();

            duranceTheWizard.Find(new Rose());
            duranceTheWizard.Find(new Sword());
            duranceTheWizard.Find(new Copper());
            duranceTheWizard.Find(new Iron());
            duranceTheWizard.Find(new Marigold());
            duranceTheWizard.Find(new Silk());
            duranceTheWizard.Find(new Iron());
            duranceTheWizard.Find(new Iron());
            duranceTheWizard.Find(new Wool());
            duranceTheWizard.Find(new Linen());
            duranceTheWizard.Find(new Copper());
            duranceTheWizard.Find(new Wool());
            duranceTheWizard.Find(new Wool());
            duranceTheWizard.Find(new Copper());
            duranceTheWizard.Find(new Marigold());
            duranceTheWizard.Find(new Silk());
            duranceTheWizard.Find(new Linen());
            duranceTheWizard.Find(new Marigold());
            duranceTheWizard.Find(new Rose());
            duranceTheWizard.Find(new Silk());
            duranceTheWizard.Find(new Linen());
            duranceTheWizard.Find(new Wool());

            duranceTheWizard.Organize();

            duranceTheWizard.DisplayItems();

            Console.ReadLine();
        }
    }
}
