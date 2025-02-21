namespace W5_SOLID_ISP_LSP.Models;

public class Character : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Move()
    {
        Console.WriteLine($"{Name} moves");
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} attacks");
    }

}
