namespace Item;

public class Item // Clase base que representa un Item del juego 
{
    // Aplico getters y setters 
    public string name { get; set; }  // Nombre del ítem 
    public int damage { get; set; }   // Daño del ítem 
    public int defence { get; set; } // Defensa del ítem 

    public Item(string name, int damage, int defence) // Inicializao el constructor 
    {
        this.name = name; // Inicializo el nombre del ítem 
        this.damage = damage; // Inicializo el daño del ítem 
        this.defence = defence; // Inicializo la defensa del ítem 
    }
}

public class Armour : Item // Armour hereda los atributos de Item. Base sirve para llamar al constructor de Item
{
    public Armour(string name, int defence) : base(name, 0, defence) { } // Armour solo tiene defensa, no daño
}

public class Weapon : Item // Weapon hereda los atributos de Item. 
{
    public Weapon(string name, int damage) : base(name, damage, 0) { } // Weapon solo tiene daño, no defensa
}

public class SpellWeapon : Item // SpellWeapon hereda los atributos de Item. 
{
    public SpellWeapon(string name, int damage, int defence) : base(name, damage, defence) { } // Arma mágica que tiene daño y defensa
}

public class Spell 
{
    public string name { get; set; }  // Nombre del hechizo 
    public int damage { get; set; } // Daño que inflige el hechizo 
    
    public Spell(string name, int damage) // Inicializo el constructor 
    {
        this.name = name;  // Inicializa el nombre del hechizo 
        this.damage = damage; // Inicializa el daño del hechizo 
    }
}

public class SpellBook 
{
    public List<Spell> spells { get; set; } // Lista de hechizos que contiene el libro  

    public SpellBook() // Inicializo el constructor
    {
        this.spells = new List<Spell>(); // Inicializo la lista de hechizos 
    }

    public void LearnSpell(Spell spell) // Método para agregar un hechizo nuevo 
    {
        this.spells.Add(spell); // Agrego el hechizo a la lista
    }

    public List<Spell> GetSpells() // Método para obtener la lista de hechizos 
    {
        return this.spells; // Devuelvo la lista de hechizos
    }
}