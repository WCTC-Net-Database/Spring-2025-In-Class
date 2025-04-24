using EFCoreInMemoryRPG.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("== Eager vs Lazy Loading Demo ==");

using var context = new GameContext();
DatabaseSeeder.Seed(context); // Seed the database with sample data for demonstration purposes

// Eager loading example
Console.WriteLine("\n-- Eager Loading --");

// Eager loading explicitly loads related data at the time of querying.
// Here, we use the `Include` method to load the `Equipment` property of the `Player` model.
// Additionally, we use `ThenInclude` to load the `Weapon` and `Armor` properties of the `Equipment` model.
// We also include the `Inventory` property, which is a collection of `Item` objects.
var eagerPlayer = context.Players
    .Include(p => p.Equipment) // Load the Equipment navigation property
        .ThenInclude(e => e.Weapon) // Load the Weapon navigation property of Equipment
    .Include(p => p.Equipment) // Load the Equipment navigation property again
        .ThenInclude(e => e.Armor) // Load the Armor navigation property of Equipment
    .Include(p => p.Inventory) // Load the Inventory navigation property (a collection of Items)
    .FirstOrDefault(); // Retrieve the first player from the database

// Display the loaded data
Console.WriteLine($"Player: {eagerPlayer?.Name}"); // Display the player's name
Console.WriteLine($"  Level: {eagerPlayer?.Level}"); // Display the player's level
Console.WriteLine($"  Gold: {eagerPlayer?.Gold}"); // Display the player's gold
Console.WriteLine($"  Weapon: {eagerPlayer?.Equipment?.Weapon?.Name}"); // Display the name of the player's weapon
Console.WriteLine($"  Armor: {eagerPlayer?.Equipment?.Armor?.Name}"); // Display the name of the player's armor
Console.WriteLine($"  Inventory: {string.Join(", ", eagerPlayer?.Inventory.Select(i => $"{i.Name} ({i.Type})"))}"); // Display the names and types of items in the player's inventory

// Lazy loading (simulated)
Console.WriteLine("\n-- Lazy Loading Simulation --");

// Lazy loading defers the loading of related data until it is accessed.
// In this example, we simulate lazy loading by explicitly loading related data using the `Load` method.
// First, we query the `Player` without including any related data.
var lazyPlayer = context.Players.FirstOrDefault(); // Retrieve the first player without loading related data

// To simulate lazy loading, we explicitly load the `Equipment` and `Inventory` collections when they are accessed.
// The `Entry` method provides access to the metadata of the entity, and the `Reference` or `Collection` method specifies the navigation property to load.
context.Entry(lazyPlayer!).Reference(p => p.Equipment).Load(); // Load the Equipment navigation property
context.Entry(lazyPlayer!.Equipment!).Reference(e => e.Weapon).Load(); // Load the Weapon navigation property of Equipment
context.Entry(lazyPlayer!.Equipment!).Reference(e => e.Armor).Load(); // Load the Armor navigation property of Equipment
context.Entry(lazyPlayer!).Collection(p => p.Inventory).Load(); // Load the Inventory navigation property

// Display the loaded data
Console.WriteLine($"Player: {lazyPlayer?.Name}"); // Display the player's name
Console.WriteLine($"  Level: {lazyPlayer?.Level}"); // Display the player's level
Console.WriteLine($"  Gold: {lazyPlayer?.Gold}"); // Display the player's gold
Console.WriteLine($"  Weapon: {lazyPlayer?.Equipment?.Weapon?.Name}"); // Display the name of the player's weapon
Console.WriteLine($"  Armor: {lazyPlayer?.Equipment?.Armor?.Name}"); // Display the name of the player's armor
Console.WriteLine($"  Lazy Loaded Inventory: {string.Join(", ", lazyPlayer!.Inventory.Select(i => $"{i.Name} ({i.Type})"))}"); // Display the names and types of items in the player's inventory

/*
Key Concepts:
1. Eager Loading:
   - Loads related data as part of the initial query.
   - Uses `Include` and `ThenInclude` methods to specify the navigation properties to load.
   - Suitable when you know you will need the related data and want to minimize database queries.

2. Lazy Loading:
   - Defers the loading of related data until it is accessed.
   - Requires additional queries to the database for each navigation property accessed.
   - Can be simulated using the `Load` method in scenarios where lazy loading is not enabled.

3. Models:
   - `Player` (Player.cs): Represents a player with `Level`, `Gold`, `Equipment`, and an `Inventory` collection.
   - `Equipment` (Equipment.cs): Represents the player's equipment, including `Weapon` and `Armor` properties.
   - `Item` (Item.cs): Represents an item, such as a weapon, armor, or consumable, with a `Type` property.

4. Trade-offs:
   - Eager loading reduces the number of database queries but may load unnecessary data.
   - Lazy loading minimizes initial data retrieval but can result in the "N+1 query problem" if not managed carefully.
*/
