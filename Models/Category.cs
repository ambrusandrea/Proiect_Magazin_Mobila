namespace Proiect_Magazin_Mobila.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Furniture>? Furnitures { get; set; }

    }
}
