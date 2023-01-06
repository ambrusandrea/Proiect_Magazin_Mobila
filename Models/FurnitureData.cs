namespace Proiect_Magazin_Mobila.Models
{
    public class FurnitureData
    {
        public IEnumerable<Furniture> Furnitures { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<FurnitureMaterial> FurnitureMaterials { get; set; }
    }
}
