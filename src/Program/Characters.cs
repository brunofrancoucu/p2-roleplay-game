using RoleplayGame.Items;

namespace RoleplayGame.Characters
{
    public class Character : Inventory
    {
        
    }

    public class Wizard : Character
    {
        private int _spell;
        SpellBook book;

        protected override int _maxHealth()
        {
            int spellDefence = book.Sum(spell => spell.damage);
            int armour = GetItemsOfType<Armour>().Sum(arm => arm.defence);
            return armour + spellDefence;
        }

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
            health = Math.Min(health + healAmount, _maxHealth());
        }
    }
}

