using W13_EFCore_InClass.Models;

namespace W13_EFCore_InClass.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(GameContext context)
        {
            if (context.Players.Any()) return;

            // Items
            var sword = new Item { Name = "Sword of Truth", Type = "Weapon" };
            var shield = new Item { Name = "Shield of Valor", Type = "Armor" };
            var potion = new Item { Name = "Healing Potion", Type = "Consumable" };
            var bow = new Item { Name = "Bow of Eternity", Type = "Weapon" };
            var helmet = new Item { Name = "Helmet of Wisdom", Type = "Armor" };

            // Equipment
            var equipment1 = new Equipment { Weapon = sword, Armor = shield };
            var equipment2 = new Equipment { Weapon = bow, Armor = helmet };

            // Players
            var player1 = new Player
            {
                Name = "Elandor",
                Level = 10,
                Gold = 100,
                Equipment = equipment1,
                Inventory = new List<Item> { sword, shield, potion }
            };

            var player2 = new Player
            {
                Name = "Archeron",
                Level = 8,
                Gold = 75,
                Equipment = equipment2,
                Inventory = new List<Item> { bow, helmet, potion }
            };

            var player3 = new Player
            {
                Name = "Myranda",
                Level = 12,
                Gold = 150,
                Equipment = new Equipment { Weapon = sword },
                Inventory = new List<Item> { potion, shield }
            };

            // Add to context
            context.Players.AddRange(player1, player2, player3);
            context.SaveChanges();
        }
    }
}
