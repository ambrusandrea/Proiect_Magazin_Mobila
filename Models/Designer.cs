using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Magazin_Mobila.Models
{
    public class Designer
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Furniture>? Furnitures { get; set; }
    }
}
