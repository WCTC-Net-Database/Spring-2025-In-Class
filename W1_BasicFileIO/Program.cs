namespace W1_BasicFileIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var x1 = 0;
            //int x2 = "a";
            //int? x3 = null;

            //Animal animal = null;

            //Console.WriteLine("Enter a string:");
            //var input = Console.ReadLine();

            //Console.WriteLine("Your string is: " + input);
            //Console.WriteLine("Your string is: {0}", input);
            //Console.WriteLine($"Your string is: {input}");

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");

            var menuOption = Console.ReadLine();

            if (menuOption == "1")
            {
                var lines = File.ReadAllLines("input.csv");

                for (int i = 0; i < lines.Length; i++)
                {
                    var cols = lines[i].Split(",");

                    var name = cols[0];
                    var profession = cols[1];
                    var level = cols[2];
                    var hitPoints = cols[3];
                    var equipment = cols[4];
                    //var items = equipment.Split("|");

                    Console.WriteLine($"Name: {name}");
                    Console.WriteLine($"Job: {profession}");
                    Console.WriteLine($"Level: {level}");
                    Console.WriteLine($"Hit Points: {hitPoints}");
                    Console.WriteLine($"Equipment: {equipment}");
                }
            }

            if (menuOption == "2")
            {
                using (StreamWriter writer = new StreamWriter("input.csv", true))
                {
                    var n = "Jane";
                    writer.WriteLine(n);
                }
            }

            if (menuOption == "3")
            {

            }
        }

        public class Animal
        {

        }
    }
}