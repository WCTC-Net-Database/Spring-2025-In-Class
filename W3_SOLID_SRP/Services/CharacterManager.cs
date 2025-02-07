using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W3_SOLID_SRP.Models;

namespace W3_SOLID_SRP.Services
{
    // manage the list of characters
    public class CharacterManager
    {
        public List<Character> Characters { get; set; }

        // default constructor
        public CharacterManager()
        {
            // Imagine this is loaded from a file
            Characters = new List<Character>
            {
                new Character("Bill"),
                new Character("Jane"),
                new Character("Sally"),
                new Character("Jeremy"),
                new Character("Sam"),
                new Character("Jeremy"),
                new Character("Sammy")
            };
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }

        public void RemoveCharacter(Character character)
        {
            Characters.Remove(character);
        }

        public Character? FindCharacter(string name)
        {
            foreach (Character c in Characters)
            {
                if (c.Name == name)
                {
                    return c;
                }
            }

            return null;

        }

        public Character? FindCharacterLINQ(string name)
        {
            //var results = Characters.Where(c => CompareCharacterName(c));
            return Characters.Where(c => c.Name == name).FirstOrDefault();
        }

        public bool CompareCharacterName(Character c)
        {
            return c.Name == "Jeremy";
        }
    }
}
