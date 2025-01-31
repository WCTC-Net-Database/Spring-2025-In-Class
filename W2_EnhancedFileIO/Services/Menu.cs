namespace W2_EnhancedFileIO.Services
{
    public class Menu
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
        }
        public static void DisplayCharacter(string name, string profession, string level, string hitPoints, string equipment)
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Job: {profession}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Hit Points: {hitPoints}");
            Console.WriteLine($"Equipment: {equipment}");
            Console.WriteLine("-----------");
        }
        public static void AddCharacter(string name)
        {
            using (StreamWriter writer = new StreamWriter("input.csv", true))
            {
                writer.WriteLine(name);
            }
        }
    }
}
