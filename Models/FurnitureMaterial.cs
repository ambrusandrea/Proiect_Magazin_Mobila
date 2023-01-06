namespace Proiect_Magazin_Mobila.Models
{
    public class FurnitureMaterial
    {
        public int ID { get; set; }
        public int FurnitureID { get; set; }
        public Furniture Furniture { get; set; }
        public int MaterialID { get; set; }
        public Material Material { get; set; }
    }
}
