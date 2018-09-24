namespace Uppgift3_Spel.Items
{
    class Bottle : Item
    {
        public Bottle(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public override Item Use(Item item)
        {
            if (item.ItemId == this.ItemId)
            {
                item = new Item("Soaked Rags",
                    "Rags drained with Kerosene",
                    5,
                    "Rags drained with Kerosene, this can burn very well!");
                return item;
            }
            return null;
        }
    }
}
