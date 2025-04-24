# Entity Framework: Eager vs Lazy Loading  
*Demonstration with RPG Game Entities*

---

## Learning Objectives

- Understand the difference between **Eager Loading** and **Lazy Loading**
- Learn how to configure and demonstrate both using **EF Core**
- Discuss tradeoffs between performance and simplicity

---

## Key Concepts

### Eager Loading
- Loads related data **immediately** with the main query
- Reduces **round trips** to the database
- Use `.Include()` and `.ThenInclude()`

```csharp
var player = context.Players
    .Include(p => p.Equipment)
        .ThenInclude(e => e.Weapon)
    .Include(p => p.Inventory)
    .FirstOrDefault();
```

**Pros**:
- Fewer database hits
- Predictable performance

**Cons**:
- Can return **more data than needed**
- Slower query if overused

---

### Lazy Loading (Simulated)
- Loads related data **on-demand**
- You control when data is loaded using `context.Entry(...).Reference/Collection(...).Load()`

```csharp
var player = context.Players.FirstOrDefault();
context.Entry(player!).Collection(p => p.Inventory).Load();
```

**Pros**:
- Loads **only what you need**
- Cleaner initial queries

**Cons**:
- Risk of **N+1 query problem**
- Harder to debug performance

---

## RPG Demo Entities

- `Player`  
- `Equipment` (holds weapon slot)  
- `Item` (used for both equipment and inventory)

**Relationships**:
- One `Player` ➜ One `Equipment`
- One `Player` ➜ Many `Items` (Inventory)
- One `Equipment` ➜ One `Weapon` (Item)

---

## Demo Setup

- Using **.NET 8 Console App**
- **EF Core with InMemory provider**
- `DatabaseSeeder.Seed(context)` adds:
  - Player: *Elandor*
  - Items: *Sword, Shield, Potion*
  - Equipment: *Weapon = Sword*

---

## Eager vs Lazy - When to Use?

| Scenario                           | Eager Loading        | Lazy Loading        |
|------------------------------------|----------------------|---------------------|
| Known relationships upfront        | Best Fit             | Risky               |
| Simple app or limited queries      | Efficient            | Acceptable          |
| Many-to-many or nested navigation  | May get large        | More control        |
| Performance-critical queries       | One round-trip       | Risk of N+1         |

---

## Final Thoughts

- Prefer **eager loading** for predictable access patterns.
- Use **lazy loading** if entity relationships are optional or rarely accessed.
- Always test for **performance bottlenecks**—profiling is your friend.
