using RoleplayGame.Characters;
using RoleplayGame.Items;
namespace LibraryTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Battle1()
    {
        // Create Items / Spells
        Armour helmet = new Armour("Dark Helmet", 10);
        SpellWeapon stick = new SpellWeapon("Staff of Power", 15, 5);
        Spell fireball = new Spell("Fireball", 25, 0);
        Spell shield1 = new Spell("Magic Shield", 0, 2);
        Spell shield2 = new Spell("Shield of Darkness", 1, 8);

        // Create spellbook and add spells
        SpellBook magicBookUltra = new SpellBook();
        magicBookUltra.LearnSpell(fireball);
        magicBookUltra.LearnSpell(shield1);
        
        // Create Wizard attacker (total damage: 25 + 0 + 15) 
        Wizard gandalf = new Wizard("Gandalf", 100);
        gandalf.Book = magicBookUltra;
        gandalf.AddItem(helmet);
        gandalf.AddItem(stick);
        
        // Create Wizard defender
        Wizard saruman = new Wizard("Saruman", 100);
        saruman.Book = new SpellBook();
        saruman.Book.LearnSpell(shield2);
        saruman.AddItem(helmet);
        
        gandalf.Attack(saruman);
        
        Assert.That(saruman.Health, Is.EqualTo(60));    // Post Gandalf attack health (test wpn type)
        saruman.Heal(80);
        Assert.That(saruman.Health, Is.EqualTo(118));   // Post self heal health (test max)
    }
}