namespace Proiect_Magazin_Mobila.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string MaterialName { get; set; }
        public ICollection<FurnitureMaterial>? FurnitureMaterials { get; set; }
    }
}
