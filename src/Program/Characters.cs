using Item;
using RoleplayGame.Characters;
using RoleplayGame.Items;

namespace RoleplayGame.Characters
{
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
       protected int Health
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

        // Metodo para recibir daño
        public void ReceiveDamage(int damage)
        {
            int totalDefence = 0;
            // Suma la defensa de todos los items que tiene el personaje
            foreach(var item in GetItemsOfType<Item>())
            {
                totalDefence += item.Defence; 
            }

            // Calcula el daño final que realmente afectará la vida
            int damageTaken = damage - totalDefence;
            if (damageTaken < 0)  // Si la defensa supera el daño, no se resta vida
                damageTaken = 0;

            health -= damageTaken;  // Reduce la vida por el daño recibido

            if (health < 0)  // Evita que la vida sea negativa
                health = 0;
        }

        // Método para curar al personaje
        public void Heal(int healAmount = 20)
        {
            health += healAmount;  // Aumenta la vida en healAmount
            if (health > MaxHealth())  // No permite que supere la vida máxima
                health = MaxHealth();
        }

        // Métodos abstractos que deben implementar las clases hijas
        public abstract void Attack(Character character);  // Ataque a otro personaje
        public abstract void Defend();                     // Defensa del personaje
    }
}
    public class Wizard : Character
    {
        private int _spell;
        SpellBook book;

        protected override int _MaxHealth()
        {
            int spellDefence = book.Sum(spell => spell.damage);
            int armour = GetItemsOfType<Armour>().Sum(arm => arm.defence);
            return armour + spellDefence;
        }

        // Learn / apply magic from current spell book
        public void Learn()
        {
            _spell = book.spells.Sum(spell => spell.damage);
        }
        
        public override void Attack(Character character)
        {
            // isDefending = false;
            int wpnSpell = GetItemsOfType<SpellWeapon>().Sum(wpn => wpn.damage); // Only spell weapons
            character.health = Math.Max(health - (_spell + wpnSpell), 0);
        }
        
        public override void Defend()
        {
            // isDefending = true;
        }
        
        public override void Heal(int  healAmount = 20)
        {
            health = Math.Min(health + healAmount,_MaxHealth());
        }
    }
}

