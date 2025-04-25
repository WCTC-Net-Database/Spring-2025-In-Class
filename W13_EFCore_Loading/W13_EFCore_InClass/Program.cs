using Microsoft.EntityFrameworkCore;
using W13_EFCore_InClass.Data;

using var context = new GameContext();
DatabaseSeeder.Seed(context);

var player = context.Players.Where(x => x.Id == 2)
    //.Include(x => x.Equipment)
    //    .ThenInclude(x => x.Weapon)
    //.Include(x => x.Equipment)
    //    .ThenInclude(x => x.Armor)
    .First();

// simulating lazy loading
//Console.WriteLine("* Simulating lazy loading");
//context.Entry(player).Reference(x => x.Equipment).Load();
//context.Entry(player.Equipment).Reference(x => x.Weapon).Load();
//context.Entry(player.Equipment).Reference(x => x.Armor).Load();


Console.WriteLine($"Player: {player.Name}");

//var inventory = player.Inventory;

Console.WriteLine($"Weapon: {player.Equipment.Weapon.Name}");
Console.WriteLine($"Armor: {player.Equipment.Armor.Name}");

foreach (var item in player.Inventory)
{
    Console.WriteLine($"Item: {item.Name}");
}
