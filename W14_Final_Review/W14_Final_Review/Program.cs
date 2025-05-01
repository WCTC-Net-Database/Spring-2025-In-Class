using System;
using Microsoft.EntityFrameworkCore;
using W14_EFCore_Linq.Data;
using W14_EFCore_Linq.Models;

// Delete and recreate the database on every run.
using var context = new GameContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
DatabaseSeeder.Seed(context);

var player = context.Players.First(x => x.Id == 2);

bool exit = false;
while (!exit)
{
    Console.Clear();

    // Welcome section with player details at the top.
    Console.WriteLine($"Welcome, {player.Name}!");
    Console.WriteLine($"Weapon: {player.Equipment?.Weapon?.Name ?? "None"}");
    Console.WriteLine($"Armor: {player.Equipment?.Armor?.Name ?? "None"}");
    Console.WriteLine("Inventory:");
    foreach (var item in player.Inventory)
    {
        Console.WriteLine($"- {item.Name}");
    }

    // List abilities for the player
    Console.WriteLine("Abilities:");
    var abilities = context.Abilities
        .Where(a => a.PlayerId == player.Id)
        .ToList();
    if (abilities.Any())
    {
        foreach (var ability in abilities)
        {
            Console.WriteLine($"- {ability.Name} (Atk: {ability.AttackBonus}, Def: {ability.DefenseBonus})");
        }
    }
    else
    {
        Console.WriteLine("None");
    }

    Console.WriteLine();

    // Room details and exits.
    var room = player.Room;
    if (room != null)
    {
        Console.WriteLine($"Current Room: {room.Name}");
        Console.WriteLine(room.Description);
        Console.Write("Exits: ");
        if (room.NorthRoom != null)
            Console.Write($"N: {room.NorthRoom.Name} ");
        if (room.SouthRoom != null)
            Console.Write($"S: {room.SouthRoom.Name} ");
        if (room.EastRoom != null)
            Console.Write($"E: {room.EastRoom.Name} ");
        if (room.WestRoom != null)
            Console.Write($"W: {room.WestRoom.Name} ");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("You are not in any room.");
    }
    Console.WriteLine();

    // Ask for directional input.
    Console.Write("Choose direction to move (N/S/E/W) or Q to quit: ");
    var input = Console.ReadLine()?.ToUpper();

    if (input == "Q")
    {
        exit = true;
        break;
    }

    Room? newRoom = null;
    if (room != null)
    {
        switch (input)
        {
            case "N":
                newRoom = room.NorthRoom;
                break;
            case "S":
                newRoom = room.SouthRoom;
                break;
            case "E":
                newRoom = room.EastRoom;
                break;
            case "W":
                newRoom = room.WestRoom;
                break;
            default:
                Console.WriteLine("Invalid input. Please choose N, S, E, W or Q to quit.");
                break;
        }
    }

    if (newRoom != null)
    {
        player.Room = newRoom;
        context.SaveChanges();
    }
    else
    {
        Console.WriteLine("There is no room in that direction. Press any key to try again.");
        Console.ReadKey();
    }
}
