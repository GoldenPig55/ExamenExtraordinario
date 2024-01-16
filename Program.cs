namespace ExamenExtraordinario
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public interface IAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RequiredLvl { get; set; }
        public AbilityType AbilityType { get; set; }
        public PlayerClass PlayerClass {  get; set; }
    }
    public enum AbilityType
    {
        Pasiva = 0,
        Activa = 1
    }
    public enum PlayerClass
    {
        Warrior = 0,
        Rogue = 1,
        Wizard = 2
    }
}