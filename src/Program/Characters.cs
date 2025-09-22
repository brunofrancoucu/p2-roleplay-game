using RoleplayGame.Items;

namespace RoleplayGame.Characters;

// Clase abstracta Character: sirve como plantilla para todos los personajes
// No se puede crear directamente un Character, solo sus subclases (Wizard,Dwarf,etc)
public abstract class Character : Inventory
{
    public string Name { get; private set; } // Nombre del Personaje
    private int health;                      // Vida actual del personaje

    // Constructor( inicializa el nombre y la vida inicial del personaje)
    public Character(string name, int initialHealth)
    {
        Name = name;
        health = initialHealth;
    }

   // Propiedad para acceder a la vida actual
   public int Health
    {
        get { return health; }
    }

    // Metodo que devuelve la vida maxima 
    // protected: solo accesible dentro de esta clase y sus subclases
    // virtual: permite que las subclases sobrescriban este método usando override
    protected virtual int MaxHealth()
    {
        return 100; // valor generico
    }

    // Metodo para recibir daño, (defensa aumenta la vida, alt: disiminuye el dano).
    public void ReceiveDamage(int damage)
    {
        // int totalDefence = GetItemsOfType<Armour>().Sum(arm => arm.defence);
        // int damageTaken = Math.Max(damage - totalDefence, 0); // Si la defensa supera el daño, no se resta vida

        // Calcula el daño final que realmente afectará la vida
        health = Math.Max(health - damage, 0); // Evita que la vida sea negativa
    }

    // Método para curar al personaje
    public void Heal(int healAmount = 20)
    {
        health = Math.Min(health + healAmount, MaxHealth()); // No permite que supere la vida máxima
    }

    // Método abstractos que deben implementar las clases hijas
    public abstract void Attack(Character character);  // Ataque a otro personaje
}

// Wizard, presenta dominio de la mágia.
// La magia provee capacidades de ataque y de defensa a traves del SpellBook.
public class Wizard : Character
{
    public SpellBook Book = null;

        public Wizard(string name, int initialHealth) : base(name, initialHealth) {}

    protected override int MaxHealth()
    {
        int spellDefence = Book.spells.Sum(spell => spell.defence);
        int armour = GetItemsOfType<Armour>().Sum(arm => arm.defence);
        return 100 + armour + spellDefence;
    }
    
    public override void Attack(Character character)
    {
        int wpnsSpell = GetItemsOfType<SpellWeapon>().Sum(wpn => wpn.damage); // Only spell weapons
        int learntSpell = Book.spells.Sum(spell => spell.damage);
        character.ReceiveDamage(learntSpell + wpnsSpell);
    }
}

    // Elf: puede tener ataques mágicos también
public class Elf : Character
{
    public Elf(string name, int initialHealth) : base(name, initialHealth) {}

    protected override int MaxHealth()
    {
        return 90; // por ejemplo, un elfo con menos vida máxima
    }

    public override void Attack(Character character)
    {
        // simplificado: ataque base mágico/físico a definir
        int baseAttack = 15;
        character.ReceiveDamage(baseAttack);
    }
}

    // Dwarf: fuerte en combate físico
public class Dwarf : Character
{
    public Dwarf(string name, int initialHealth) : base(name, initialHealth) {}

    protected override int MaxHealth()
    {
        return 120; //  más resistentes
    }

    public override void Attack(Character character)
    {
        int baseAttack = 20; // ataque físico fuerte
        character.ReceiveDamage(baseAttack);
    }
}
