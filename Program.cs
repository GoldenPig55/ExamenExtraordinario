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
        public AbilityTypePoA AbilityTypePoA { get; set; }
        public PlayerClass PlayerClass {  get; set; }
    }
    public interface IRangedAbility
    {
        public int ManaCost { get; set; }
        public bool SelfCast { get; set; }
        public AbilityTypeDoH AbilityTypeDoH { get; set; }
        public int Potency { get; set; }
        public void Throw();
    }
    public enum AbilityTypePoA // Ability Type Passive or Active
    {
        Passive = 0,
        Active = 1
    }
    public enum PlayerClass
    {
        Warrior = 0,
        Rogue = 1,
        Wizard = 2
    }
    public enum AbilityTypeDoH // Ability type Damage or Heal
    {
        Damage = 0,
        Heal = 1
    }
}