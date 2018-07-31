﻿using Sjerrul.CharacterForge.Builder;
using Sjerrul.CharacterForge.Builder.OutputGeneration;
using Sjerrul.CharacterForge.Core;
using Sjerrul.CharacterForge.Core.Classes;
using Sjerrul.CharacterForge.Core.Races;
using Sjerrul.CharacterForge.Core.Races.Subraces.Dwarf;
using System;
using System.IO;

namespace Sjerrul.CharacterForge.ConsoleGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CHARACTERFORGE - A D&D Character Generator");
            Console.WriteLine("==========================================");
            Console.WriteLine("This application currently Only used as a");
            Console.WriteLine("test driver applicaiton and will generate a");
            Console.WriteLine("pre-defined character sheet");

            

            CharacterSheetBuilder builder = new CharacterSheetBuilder();
            CharacterSheet sheet = builder.Build(BuildCharacter());

            MarkdownGenerator generator = new MarkdownGenerator();
            string output = generator.Generate(sheet);

            File.WriteAllText("charactersheet.md", output);
        }

        private static Character BuildCharacter()
        {
            Character character = new Character
            {
                BaseCharisma = 10,
                BaseConstitution = 12,
                BaseDexterity = 8,
                BaseIntelligence = 14,
                BaseStrength = 17,
                BaseWisdom = 10
            };

            character.SetLevel(1);
            character.SetRace(new Dwarf());
            character.SetRace(new HillDwarf());
            character.AddClass(new Fighter());

            return character;
        }
    }
}