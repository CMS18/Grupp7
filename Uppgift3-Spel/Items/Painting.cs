namespace Uppgift3_Spel
{
    public class Painting : Item
    {
        public Painting(string name, string description, int id, string examine) : base(name, description, id, examine)
        {
        }

        public Item Use(Item item)
        {
            if (item.ItemId == this.ItemId)
            {
                return new Painting(
                    "Completed Painting",
                    "A complete picture of Mr. X",
                    0,
                    "There is some numbers here in the corner... 1, 8, 3, 9, 6"
                );
            }
            return null;
        }
    }
}
