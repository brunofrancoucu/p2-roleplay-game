@startuml
class Armour {
    # aggHealth: int
    # name: String
}

class Weapon {
    # damage: int
    # name: String
}

class Spell {
    + defence: int
    + attach: int
    + spell: int
}

class SpellBook {
    + spell: List<Spell>
}

class Character {
    + name: String
    + age: int

    - health: int         ' current health
    - maxHealth: int      ' depends on armour

    - armour: List<Armour>
    - weapon: Weapon

    + attack(Character character): void ' value depends on weapon
    + defend(): void  
}

class Mago {
    spell: int ' depends on spells (book)
}

class Elfo {
    + help(): void
}

class Enano

Character --|> Mago
Character --|> Elfo
Character --|> Enano

@enduml
