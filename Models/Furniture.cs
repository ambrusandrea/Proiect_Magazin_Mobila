using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect_Magazin_Mobila.Models
{
    public class Furniture
    {
        public int ID { get; set; }
        [Display(Name = "Furniture Name")]

        public string Name { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 100000)]

        public decimal Price { get; set; }
        public int? CategoryID { get; set; }
        public Category? Categories { get; set; }
        public int? DesignerID { get; set; }
        public Designer? Designer { get; set; }
       
        public ICollection<FurnitureMaterial>? FurnitureMaterials { get; set; }

    }
}
