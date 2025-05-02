using System;
using System.Collections.Generic;
using System.Linq;
using W14_Final_Review.Data;
using W14_Final_Review.Models;

namespace W14_Final_Review.Services
{
    public class FinalExampleService
    {
        // C-level: Add a new character to the database.
        public void AddNewCharacter(GameContext context)
        {
            Console.WriteLine("---- Add New Character ----");
            Console.Write("Enter character name: ");
            var name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter character level (used as health): ");
            int level = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter gold amount: ");
            int gold = int.Parse(Console.ReadLine() ?? "0");

            var newPlayer = new Player
            {
                Name = name,
                Level = level,
                Gold = gold
            };

            context.Players.Add(newPlayer);
            context.SaveChanges();

            Console.WriteLine("Character added successfully.");
            // Log the interaction
            Console.WriteLine("[LOG] Added new character: " + name);
            Console.ReadKey();
        }

        // C-level: Edit an existing character.
        public void EditCharacter(GameContext context)
        {
            Console.WriteLine("---- Edit Existing Character ----");
            Console.Write("Enter character id to edit: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var player = context.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                Console.WriteLine("Character not found.");
                return;
            }

            Console.Write($"Current Level (Health): {player.Level}. Enter new level: ");
            player.Level = int.Parse(Console.ReadLine() ?? player.Level.ToString());
            // For demonstration, we allow editing Gold as an extra attribute
            Console.Write($"Current Gold: {player.Gold}. Enter new gold: ");
            player.Gold = int.Parse(Console.ReadLine() ?? player.Gold.ToString());

            context.SaveChanges();

            Console.WriteLine("Character updated successfully.");
            Console.WriteLine("[LOG] Edited character with Id: " + id);
            Console.ReadKey();
        }

        // C-level: Display all characters.
        public void DisplayAllCharacters(GameContext context)
        {
            Console.WriteLine("---- Display All Characters ----");
            var players = context.Players.ToList();
            foreach (var player in players)
            {
                Console.WriteLine($"Id: {player.Id}, Name: {player.Name}, Level: {player.Level}, Gold: {player.Gold}");
            }
            Console.WriteLine("[LOG] Displayed all characters");
            Console.ReadKey();
        }

        // C-level: Search for a specific character by name (case-insensitive).
        public void SearchCharacterByName(GameContext context)
        {
            Console.WriteLine("---- Search Character By Name ----");
            Console.Write("Enter character name or part of it: ");
            string searchName = Console.ReadLine() ?? string.Empty;

            var players = context.Players.ToList()
                .Where(p => p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));

            if (players.Any())
            {
                foreach (var player in players)
                {
                    Console.WriteLine($"Id: {player.Id}, Name: {player.Name}, Level: {player.Level}, Gold: {player.Gold}");
                }
            }
            else
            {
                Console.WriteLine("No matching characters found.");
            }
            Console.WriteLine("[LOG] Searched characters by name: " + searchName);
            Console.ReadKey();
        }

        // C-level: Add an Ability to a Character.
        public void AddAbilityToCharacter(GameContext context)
        {
            Console.WriteLine("---- Add Ability to Character ----");
            Console.Write("Enter character id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var player = context.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                Console.WriteLine("Character not found.");
                return;
            }

            Console.Write("Enter ability name: ");
            var abilityName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter attack bonus: ");
            int attackBonus = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter defense bonus: ");
            int defenseBonus = int.Parse(Console.ReadLine() ?? "0");

            // Create and add ability
            var ability = new Ability
            {
                Name = abilityName,
                AttackBonus = attackBonus,
                DefenseBonus = defenseBonus,
                PlayerId = player.Id,
                Player = player
            };

            context.Abilities.Add(ability);
            context.SaveChanges();

            Console.WriteLine("Ability added successfully to character " + player.Name);
            Console.WriteLine("[LOG] Added ability '" + abilityName + "' to character id " + id);
            Console.ReadKey();
        }

        // C-level: Display Abilities for a selected character.
        public void DisplayCharacterAbilities(GameContext context)
        {
            Console.WriteLine("---- Display Character Abilities ----");
            Console.Write("Enter character id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var abilities = context.Abilities.Where(a => a.PlayerId == id).ToList();
            if (abilities.Any())
            {
                foreach (var ability in abilities)
                {
                    Console.WriteLine($"Ability Id: {ability.Id}, Name: {ability.Name}, " +
                        $"Attack Bonus: {ability.AttackBonus}, Defense Bonus: {ability.DefenseBonus}");
                }
            }
            else
            {
                Console.WriteLine("No abilities found for this character.");
            }
            Console.WriteLine("[LOG] Displayed abilities for character id " + id);
            Console.ReadKey();
        }

        // C-level: Execute an ability during an attack.
        public void ExecuteAbilityDuringAttack(GameContext context)
        {
            Console.WriteLine("---- Execute Ability During Attack ----");
            Console.Write("Enter character id: ");
            int playerId = int.Parse(Console.ReadLine() ?? "0");

            var abilities = context.Abilities.Where(a => a.PlayerId == playerId).ToList();
            if (!abilities.Any())
            {
                Console.WriteLine("No abilities found for this character.");
                return;
            }

            Console.WriteLine("Select an ability to execute:");
            foreach (var ability in abilities)
            {
                Console.WriteLine($"Id: {ability.Id} - {ability.Name}");
            }
            int abilityId = int.Parse(Console.ReadLine() ?? "0");
            var abilityToExecute = abilities.FirstOrDefault(a => a.Id == abilityId);
            if (abilityToExecute == null)
            {
                Console.WriteLine("Ability not found.");
                return;
            }

            // For demo, we simulate an attack.
            Console.WriteLine($"Executing ability '{abilityToExecute.Name}'...");
            Console.WriteLine($"Attack Bonus: {abilityToExecute.AttackBonus}, Defense Bonus: {abilityToExecute.DefenseBonus}");
            Console.WriteLine("Attack executed successfully.");
            Console.WriteLine("[LOG] Executed ability id " + abilityId + " for character id " + playerId);
            Console.ReadKey();
        }

        // B-level: Add a new room.
        public void AddNewRoom(GameContext context)
        {
            Console.WriteLine("---- Add New Room ----");
            Console.Write("Enter room name: ");
            var name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter room description: ");
            var desc = Console.ReadLine() ?? string.Empty;

            var room = new Room
            {
                Name = name,
                Description = desc
            };

            context.Rooms.Add(room);
            context.SaveChanges();

            Console.WriteLine("Room added successfully.");
            Console.WriteLine("[LOG] Added room: " + name);
            Console.ReadKey();
        }

        // B-level: Display details of a room and its inhabitants.
        public void DisplayRoomDetails(GameContext context)
        {
            Console.WriteLine("---- Display Room Details ----");
            Console.Write("Enter room id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var room = context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            Console.WriteLine($"Room Name: {room.Name}");
            Console.WriteLine($"Description: {room.Description}");

            Console.WriteLine("Players:");
            foreach (var p in room.Players)
            {
                Console.WriteLine($"- {p.Name} (Id: {p.Id})");
            }


            // Load inhabitants (players) in the room
            var inhabitants = context.Players.Where(p => p.RoomId == room.Id).ToList();
            if (inhabitants.Any())
            {
                Console.WriteLine("Inhabitants:");
                foreach (var p in inhabitants)
                {
                    Console.WriteLine($"- {p.Name} (Id: {p.Id})");
                }
            }
            else
            {
                Console.WriteLine("No characters in this room.");
            }
            Console.WriteLine("[LOG] Displayed details for room id " + id);
            Console.ReadKey();
        }

        // B-level: Navigate the rooms.
        public void NavigateRooms(GameContext context)
        {
            Console.WriteLine("---- Navigate Rooms ----");
            Console.Write("Enter your character id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var player = context.Players.FirstOrDefault(p => p.Id == id);
            if (player == null || player.Room == null)
            {
                Console.WriteLine("Character or current room not found.");
                return;
            }

            var currentRoom = player.Room;
            Console.WriteLine("Current Room: " + currentRoom.Name);
            Console.WriteLine("Available Exits: " +
                (currentRoom.NorthRoom != null ? " N" : "") +
                (currentRoom.SouthRoom != null ? " S" : "") +
                (currentRoom.EastRoom != null ? " E" : "") +
                (currentRoom.WestRoom != null ? " W" : ""));
            Console.Write("Enter direction to move (N/S/E/W): ");
            var direction = Console.ReadLine()?.ToUpper();

            Room? newRoom = null;
            switch (direction)
            {
                case "N":
                    newRoom = currentRoom.NorthRoom;
                    break;
                case "S":
                    newRoom = currentRoom.SouthRoom;
                    break;
                case "E":
                    newRoom = currentRoom.EastRoom;
                    break;
                case "W":
                    newRoom = currentRoom.WestRoom;
                    break;
                default:
                    Console.WriteLine("Invalid direction.");
                    return;
            }

            if (newRoom == null)
            {
                Console.WriteLine("No room in that direction.");
            }
            else
            {
                player.Room = newRoom;
                player.RoomId = newRoom.Id;
                context.SaveChanges();
                Console.WriteLine("Moved to room: " + newRoom.Name);
            }
            Console.WriteLine("[LOG] Character id " + id + " navigated to a new room.");
            Console.ReadKey();
        }

        // A-level: List characters in a room matching a selected attribute.
        public void ListCharactersByAttribute(GameContext context)
        {
            Console.WriteLine("---- List Characters In Room By Attribute ----");
            Console.Write("Enter room id: ");
            int roomId = int.Parse(Console.ReadLine() ?? "0");

            var inhabitants = context.Players.Where(p => p.RoomId == roomId).ToList();
            if (!inhabitants.Any())
            {
                Console.WriteLine("No characters found in this room.");
                return;
            }

            Console.Write("Enter attribute to filter by (Name/Level): ");
            string attribute = Console.ReadLine() ?? string.Empty;

            IEnumerable<Player> filtered = inhabitants;
            if (attribute.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter the name to search: ");
                string name = Console.ReadLine() ?? string.Empty;
                filtered = filtered.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }
            else if (attribute.Equals("Level", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Enter minimum level: ");
                int minLevel = int.Parse(Console.ReadLine() ?? "0");
                filtered = filtered.Where(p => p.Level >= minLevel);
            }
            else
            {
                Console.WriteLine("Invalid attribute.");
                return;
            }

            foreach (var p in filtered)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Level: {p.Level}");
            }
            Console.WriteLine("[LOG] Listed characters in room id " + roomId + " by attribute " + attribute);
            Console.ReadKey();
        }

        // A-level: List all rooms with all characters in them, grouped by room.
        public void ListAllRoomsWithCharacters(GameContext context)
        {
            Console.WriteLine("---- List All Rooms With Characters ----");
            var rooms = context.Rooms.ToList();

            foreach (var room in rooms)
            {
                Console.WriteLine($"Room Id: {room.Id}, Name: {room.Name}");
                var inhabitants = context.Players.Where(p => p.RoomId == room.Id).ToList();
                if (inhabitants.Any())
                {
                    foreach (var p in inhabitants)
                    {
                        Console.WriteLine($"   - {p.Name} (Level: {p.Level})");
                    }
                }
                else
                {
                    Console.WriteLine("   - No inhabitants.");
                }
            }
            Console.WriteLine("[LOG] Listed all rooms with their inhabitants.");
            Console.ReadKey();
        }

        // A-level: Find a specific piece of equipment and list the associated character and location.
        public void FindEquipmentAndLocation(GameContext context)
        {
            Console.WriteLine("---- Find Equipment and Associated Character ----");
            Console.Write("Enter item name to search for: ");
            string itemName = Console.ReadLine() ?? string.Empty;

            // Search in Equipment (both Weapon and Armor)
            var result = context.Players
                .AsEnumerable()
                .Where(p => (p.Equipment != null &&
                        ((p.Equipment.Weapon != null && p.Equipment.Weapon.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase)) ||
                            (p.Equipment.Armor != null && p.Equipment.Armor.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase))))
                    || p.Inventory.Any(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase)))
                .Select(p => new { p.Name, RoomName = p.Room != null ? p.Room.Name : "No Room" })
                .FirstOrDefault();

            if (result != null)
            {
                Console.WriteLine($"Item '{itemName}' is held by {result.Name} currently in room: {result.RoomName}");
            }
            else
            {
                Console.WriteLine("Item not found with any character.");
            }
            Console.WriteLine("[LOG] Searched equipment: " + itemName);
            Console.ReadKey();
        }

        // A+ level: Stretch feature - a mini "quest" system demonstration.
        public void StretchFeatureMiniQuest(GameContext context)
        {
            Console.WriteLine("---- Mini Quest System ----");
            Console.WriteLine("A secret quest is available:");
            Console.WriteLine("Defeat the virtual dragon by selecting your best ability!");

            Console.Write("Enter your character id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            var abilities = context.Abilities.Where(a => a.PlayerId == id).ToList();
            if (!abilities.Any())
            {
                Console.WriteLine("You have no abilities to complete the quest!");
                return;
            }

            Console.WriteLine("Select an ability for the quest:");
            foreach (var ability in abilities)
            {
                Console.WriteLine($"Id: {ability.Id} - {ability.Name}");
            }

            int abilityId = int.Parse(Console.ReadLine() ?? "0");
            var selectedAbility = abilities.FirstOrDefault(a => a.Id == abilityId);
            if (selectedAbility == null)
            {
                Console.WriteLine("Invalid ability selected.");
                return;
            }

            Console.WriteLine($"You used '{selectedAbility.Name}' and defeated the dragon!");
            Console.WriteLine("[LOG] Completed mini quest using ability id " + selectedAbility.Id);
            Console.ReadKey();
        }
    }
}
