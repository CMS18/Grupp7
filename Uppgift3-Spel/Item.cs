namespace Uppgift3_Spel
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public int ItemId { get; }

        public Item(string name, string description, int id)
        {
            Name = name;
            Description = description;
            ItemId = id;
        }

        public virtual void Use()
        {

        }

        public void InspectItem()
        {
            
        }
    }
}
