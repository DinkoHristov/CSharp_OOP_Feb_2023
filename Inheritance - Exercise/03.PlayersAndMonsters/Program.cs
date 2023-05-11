using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new Elf("Legolas", 100);

            Wizard wizard = new Wizard("Galdalf", 100);

            Knight knight = new Knight("Aragorn", 100);

            MuseElf museElf = new MuseElf("Galadriel", 50);

            DarkWizard darkWizard = new DarkWizard("Sauron", 50);

            DarkKnight darkKnight = new DarkKnight("Black Rider", 50);

            SoulMaster soulMaster = new SoulMaster("Elrond", 20);

            BladeKnight bladeKnight = new BladeKnight("Gimli", 30);

            Console.WriteLine(elf.ToString());
            Console.WriteLine(wizard.ToString());
            Console.WriteLine(knight.ToString());
            Console.WriteLine(museElf.ToString());
            Console.WriteLine(darkWizard.ToString());
            Console.WriteLine(darkKnight.ToString());
            Console.WriteLine(soulMaster.ToString());
            Console.WriteLine(bladeKnight.ToString());
        }
    }
}