namespace ClassLibraryGame
{
    public class Mage : Character
    {
        public int MagicPower { get; set; }
        Random rnd = new Random();

        public Mage()
        {
            MagicPower = rnd.Next(1, 10);
        }

        public Mage(string name, int age, int strength, int agility, int intellect, int magicPower)
            : base(name, age, strength, agility, intellect)
        {
            MagicPower = magicPower*intellect;
        }

        public void CastSpell()
        {
            Console.WriteLine($"{Name} кастует заклинание с магической силой {MagicPower}!");
        }

        // Переопределение метода printCharacterSkills для включения магической силы
        public override void printCharacterSkills()
        {
            base.printCharacterSkills();
            Console.WriteLine($"Магическая сила: {MagicPower}");
        }
    }
}
