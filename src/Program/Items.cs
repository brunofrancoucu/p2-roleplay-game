namespace RoleplayGame.Items
{
    // Character Inventory Management 
    public class Inventory
    {
        private List<Item> _items;
        
        public List<T> GetItemsOfType<T>() where T : Item
        {
            return _items.OfType<T>().ToList();
        }
        
        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }
    }
}

