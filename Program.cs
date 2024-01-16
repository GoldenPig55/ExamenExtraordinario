using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamenExtraordinario
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class ActiveAbility : IAbility, IRangedAbility
    {
        private static int lastId = 0;
        private int id;
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string Name { get; set; }
        public int RequiredLvl { get; set; }
        public AbilityTypePoA AbilityTypePoA { get; set; }
        public PlayerClass PlayerClass { get; set; }
        public int ManaCost { get; set; }
        public bool SelfCastable { get; set; }
        public AbilityTypeDoH AbilityTypeDoH { get; set; }
        public int Potency { get; set; }
        public ActiveAbility(string name, int requiredLvl, PlayerClass playerClass, int manaCost, bool selfCastable, AbilityTypeDoH abilityTypeDoH, int potency)
        {
            Name = name;
            RequiredLvl = requiredLvl;
            PlayerClass = playerClass;
            ManaCost = manaCost;
            SelfCastable = selfCastable;
            AbilityTypeDoH = abilityTypeDoH;
            Potency = potency;
            AbilityTypePoA = AbilityTypePoA.Active;
            Id = lastId + 1;
            lastId++;
        }
        public void Throw()
        {

        }
    }
    public class PassiveAbility : IAbility, IRangedAbility, IStatusAbility
    {
        private int lastId = 0;
        private int id;
        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string Name { get; set; }
        public int RequiredLvl { get; set; }
        public AbilityTypePoA AbilityTypePoA { get; set; }
        public PlayerClass PlayerClass { get; set; }
        public int ManaCost { get; set; }
        public bool SelfCastable { get; set; }
        public AbilityTypeDoH AbilityTypeDoH { get; set; }
        public int Potency { get; set; }
        public PassiveAbility()
        {
            Id = lastId + 1;
            lastId++;
        }
        public void Throw()
        {

        }
        public void ApplyEffect()
        {

        }
    }
    public class AbilityRepository
    {
        public List<ActiveAbility> _activeAbilityList;
        public List<PassiveAbility> _passiveAbilityList;
        public AbilityRepository()
        {
            _activeAbilityList = new List<ActiveAbility>();
            _passiveAbilityList = new List<PassiveAbility>();
        }
        public void FindAbility()
        {
            string SeleccionNombre, SeleccionPoA;
            int SeleccionID;
            char SeleccionYN;
            string pasivabuscada = "a", activabuscada = "a";

            Console.WriteLine("Que tipo de abilidad esta buscando? [ 1) Pasiva 2) Activa ]");
            SeleccionPoA = Console.ReadLine();
            switch (SeleccionPoA)
            {
                case "1":
                    Console.WriteLine("Ingrese el ID de su habilidad pasiva.");
                    SeleccionID = Convert.ToInt32(Console.ReadLine());
                   // var pasivabucada = Program.AbilityRepository._passiveAbilityList.Find(x => x.Id == SeleccionID);
                    if (pasivabuscada != null)
                    {
                        Console.WriteLine(pasivabuscada);
                    }
                    else
                    {
                        Console.WriteLine("No se encontro ninguna habilidad pasiva con ese ID. Desea buscar por nombre? (Y/N)");
                        SeleccionYN = Convert.ToChar(Console.ReadLine());
                        switch (SeleccionYN)
                        {
                            case 'Y':
                            case 'y':
                                Console.WriteLine("Ingrese el nombre de su habilidad pasiva.");
                                SeleccionNombre = Console.ReadLine();
                               // pasivabucada = Program.AbilityRepository._passiveAbilityList.Find(x => x.Id == SeleccionID);
                                if (pasivabuscada != null)
                                {
                                    Console.WriteLine(pasivabuscada);
                                }
                                else
                                {
                                    Console.WriteLine("No se encontro ninguna habilidad pasiva con ese nombre.");
                                }
                                break;
                            case 'N':
                            case 'n':
                                break;
                            default:
                                Console.WriteLine("Seleccion invalida.");
                                FindAbility();
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Ingrese el ID de su habilidad activa.");
                    SeleccionID = Convert.ToInt32(Console.ReadLine());
                    // var activabuscada = Program.AbilityRepository._activeAbilityList.Find(x => x.Id == SeleccionID);
                    if (activabuscada != null)
                    {
                        Console.WriteLine(activabuscada);
                    }
                    else
                    {
                        Console.WriteLine("No se encontro ninguna habilidad activa con ese ID. Desea buscar por nombre? (Y/N)");
                        SeleccionYN = Convert.ToChar(Console.ReadLine());
                        switch (SeleccionYN)
                        {
                            case 'Y':
                            case 'y':
                                Console.WriteLine("Ingrese el nombre de su habilidad activa.");
                                SeleccionNombre = Console.ReadLine();
                               // activabuscada = Program.registro._activeAbilityList.Find(x => x.Nombre == SeleccionNombre);
                                if (activabuscada != null)
                                {
                                    Console.WriteLine(activabuscada);
                                }
                                else
                                {
                                    Console.WriteLine("No se encontro ninguna mascota con ese nombre.");
                                }
                                break;
                            case 'N':
                            case 'n':
                                break;
                            default:
                                Console.WriteLine("Seleccion invalida.");
                                FindAbility();
                                break;
                        }

                    }
                    break;
                default:
                    Console.WriteLine("Seleccion invalida.");
                    FindAbility();
                    break;
            }
        }
        public void AddAbility()
        {
            Console.WriteLine("");
        }
    }
    public interface IAbility
    {
        private static int lastId = 0;
        public string Name { get; set; }
        public int RequiredLvl { get; set; }
        public AbilityTypePoA AbilityTypePoA { get; set; }
        public PlayerClass PlayerClass { get; set; }
    }
    public interface IRangedAbility
    {
        public int ManaCost { get; set; }
        public bool SelfCastable { get; set; }
        public AbilityTypeDoH AbilityTypeDoH { get; set; }
        public int Potency { get; set; }
        public void Throw();
    }
    public interface IStatusAbility
    {
        public void ApplyEffect();
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