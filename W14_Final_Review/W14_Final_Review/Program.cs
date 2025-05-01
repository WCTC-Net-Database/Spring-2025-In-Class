using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using W14_EFCore_Linq.Data;
using W14_EFCore_Linq.Models;
using W14_Final_Review.Services;

// Delete and recreate the database on every run.
using var context = new GameContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
DatabaseSeeder.Seed(context);

var exampleService = new FinalExampleService();

// Select the character to use in the game (for Regular Game mode).
var player = context.Players.First(x => x.Id == 2);

bool mainExit = false;
while (!mainExit)
{
    Console.Clear();
    Console.WriteLine("=== Main Menu ===");
    Console.WriteLine("1: Regular Game");
    Console.WriteLine("2: Examples Menu");
    Console.WriteLine("Q: Quit");
    Console.Write("Select an option: ");
    var mainChoice = Console.ReadLine()?.ToUpper();

    if (mainChoice == "Q")
    {
        mainExit = true;
        break;
    }
    else if (mainChoice == "1")
    {
        // Regular Game mode loop (navigating rooms)
        bool gameExit = false;
        while (!gameExit)
        {
            Console.Clear();

            // Welcome section with player details.
            Console.WriteLine($"Welcome, {player.Name}!");
            Console.WriteLine($"Weapon: {player.Equipment?.Weapon?.Name ?? "None"}");
            Console.WriteLine($"Armor: {player.Equipment?.Armor?.Name ?? "None"}");
            Console.WriteLine("Inventory:");
            foreach (var item in player.Inventory)
            {
                Console.WriteLine($"- {item.Name}");
            }

            // List abilities for the player.
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
            Console.Write("Choose direction to move (N/S/E/W) or B to go back to Main Menu: ");
            var gameInput = Console.ReadLine()?.ToUpper();

            if (gameInput == "B")
            {
                break;
            }

            Room? newRoom = null;
            if (room != null)
            {
                switch (gameInput)
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
                        Console.WriteLine("Invalid input. Please choose N, S, E, W, or B.");
                        Console.ReadKey();
                        continue;
                }
            }

            if (newRoom != null)
            {
                player.Room = newRoom;
                player.RoomId = newRoom.Id;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("There is no room in that direction. Press any key to try again.");
                Console.ReadKey();
            }
        }
    }
    else if (mainChoice == "2")
    {
        // Examples Menu loop.
        bool examplesExit = false;
        while (!examplesExit)
        {
            Console.Clear();
            Console.WriteLine("=== Examples Menu ===");
            Console.WriteLine("1: Add New Character");
            Console.WriteLine("2: Edit Character");
            Console.WriteLine("3: Display All Characters");
            Console.WriteLine("4: Search Character By Name");
            Console.WriteLine("5: Add Ability To Character");
            Console.WriteLine("6: Display Character Abilities");
            Console.WriteLine("7: Execute Ability During Attack");
            Console.WriteLine("8: Add New Room");
            Console.WriteLine("9: Display Room Details");
            Console.WriteLine("A: Navigate Rooms");
            Console.WriteLine("B: List Characters By Attribute");
            Console.WriteLine("C: List All Rooms With Characters");
            Console.WriteLine("D: Find Equipment And Location");
            Console.WriteLine("E: Stretch Feature: Mini Quest");
            Console.WriteLine("X: Return to Main Menu");
            Console.Write("Select an option: ");
            var exChoice = Console.ReadLine()?.ToUpper();

            switch (exChoice)
            {
                case "1":
                    exampleService.AddNewCharacter(context);
                    break;
                case "2":
                    exampleService.EditCharacter(context);
                    break;
                case "3":
                    exampleService.DisplayAllCharacters(context);
                    break;
                case "4":
                    exampleService.SearchCharacterByName(context);
                    break;
                case "5":
                    exampleService.AddAbilityToCharacter(context);
                    break;
                case "6":
                    exampleService.DisplayCharacterAbilities(context);
                    break;
                case "7":
                    exampleService.ExecuteAbilityDuringAttack(context);
                    break;
                case "8":
                    exampleService.AddNewRoom(context);
                    break;
                case "9":
                    exampleService.DisplayRoomDetails(context);
                    break;
                case "A":
                    exampleService.NavigateRooms(context);
                    break;
                case "B":
                    exampleService.ListCharactersByAttribute(context);
                    break;
                case "C":
                    exampleService.ListAllRoomsWithCharacters(context);
                    break;
                case "D":
                    exampleService.FindEquipmentAndLocation(context);
                    break;
                case "E":
                    exampleService.StretchFeatureMiniQuest(context);
                    break;
                case "X":
                    examplesExit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    else
    {
        Console.WriteLine("Invalid selection. Press any key to try again.");
        Console.ReadKey();
    }
}
