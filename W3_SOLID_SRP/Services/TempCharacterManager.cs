namespace W3_SOLID_SRP.Services
{
    public class TempCharacterManager
    {
        public static void DisplayCharacters()
        {
            var lines = File.ReadAllLines("Files/input.csv");

            var header = lines[0];

            for (int i = 1; i < lines.Length; i++)
            {
                string name = "";
                string job = "";
                string level = "";
                string hitPoints = "";
                string equipment = "";

                // does the line start with a " ?
                var firstQuoteLocation = lines[i].IndexOf('"');

                // if " is not found
                if (firstQuoteLocation < 0)
                {
                    var cols = lines[i].Split(",");

                    name = cols[0];
                    job = cols[1];
                    level = cols[2];
                    hitPoints = cols[3];
                    equipment = cols[4];
                    //var items = equipment.Split("|");

                }
                else
                {
                    lines[i] = lines[i].TrimStart('"');
                    var parts = lines[i].Split('"');
                    var firstPart = parts[0];
                    var secondPart = parts[1].Substring(1);
                    
                    var cols = secondPart.Split(",");
                    name = firstPart;
                    job = cols[0];
                    level = cols[1];
                    hitPoints = cols[2];
                    equipment = cols[3];
                }

                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Job: {job}");
                Console.WriteLine($"Level: {level}");
                Console.WriteLine($"Hit Points: {hitPoints}");
                Console.WriteLine($"Equipment: {equipment}");
                Console.WriteLine("-----------");
            }
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
