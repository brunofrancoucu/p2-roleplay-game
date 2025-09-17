class Inventory 
    public List<T> GetItemsOfType<T>() where T : Item
    {
        return items.OfType<T>().ToList();
    }


Character;
    public void EquipWeapon(Weapon weapon)
    {
        if (Inventory.GetItemsOfType<Weapon>().Contains(weapon))
            EquippedWeapon = weapon;
    }

    public void UseConsumable(Consumable consumable)
    {
        if (Inventory.GetItemsOfType<Consumable>().Contains(consumable))
        {
            consumable.Use();
            if (consumable.Quantity == 0)
                Inventory.RemoveItem(consumable);
        }
    }

