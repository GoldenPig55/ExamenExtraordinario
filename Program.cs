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
            Console.WriteLine("Que tipo de habilidad desea registrar? [ 1) Pasiva  2)  Activa ]\n");
            string SeleccionPoA = Console.ReadLine();

            string SeleccionNombre;
            int SeleccionRequiredLvl, SeleccionManaCost, SeleccionPotency;
            bool SeleccionSelfCastable;
            AbilityTypeDoH SeleccionDoH;
            PlayerClass SeleccionPlayerClass;

            switch (SeleccionPoA)
            {
                case "1":
                    Console.WriteLine("Registrando habilidad pasiva. Cual es el nombre?");
                    SeleccionNombre = Console.ReadLine();
                    Console.WriteLine("Que nivel necesitas ser para utilizar esta habilidad?");
                    SeleccionRequiredLvl = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Que clase puede utilizar esta habilidad? [ 1) Warrior  2) Rogue  3) Wizard ]");
                    SeleccionPlayerClass = (PlayerClass)Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Cuanto de mana cuesta?");
                    SeleccionManaCost = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Que tipo de habilidad es? [ 1) Daño  2) Curativa ]");
                    SeleccionDoH = (AbilityTypeDoH)Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Es auto aplicable? (ingrese true o false)");
                    SeleccionSelfCastable = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("Cuanto es su potencia?");
                    SeleccionPotency = Convert.ToInt32(Console.ReadLine());
                    RegisterActiveAbility(SeleccionNombre, SeleccionRequiredLvl, SeleccionPlayerClass, SeleccionManaCost, SeleccionSelfCastable, SeleccionDoH, SeleccionPotency);
                    Console.WriteLine("\nRegistro Completo.\n");
                    Console.WriteLine($"{SeleccionNombre}\nNivel requerido: {SeleccionRequiredLvl}\nTipo: Pasiva\nClase asociada: {SeleccionPlayerClass}\nCosto mana: {SeleccionManaCost}\nAutoaplicable: {SeleccionSelfCastable}\nTipoEfecto: {SeleccionDoH}\nPotencia: {SeleccionPotency}");
                    break;
                case "2":

                    break;
                default:
                    Console.WriteLine("Seleccion invalida.");
                    AddAbility();
                    break;
            }

        }
        public ActiveAbility RegisterActiveAbility(string name, int requiredLvl, PlayerClass playerClass, int manaCost, bool selfCastable, AbilityTypeDoH abilityTypeDoH, int potency)
        {
            ActiveAbility newActiveAbility = new ActiveAbility(name, requiredLvl, playerClass, manaCost, selfCastable, abilityTypeDoH, potency);
            _activeAbilityList.Add(newActiveAbility);
            return newActiveAbility;
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
        Warrior = 1,
        Rogue = 2,
        Wizard = 3
    }
    public enum AbilityTypeDoH // Ability type Damage or Heal
    {
        Damage = 1,
        Heal = 2
    }
}