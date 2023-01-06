using System.Security.Policy;

namespace Proiect_Magazin_Mobila.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Furniture> Furnitures { get; set; }

    }
}
