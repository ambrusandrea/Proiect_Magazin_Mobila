using System.ComponentModel.DataAnnotations;

namespace Proiect_Magazin_Mobila.Models
{
    public class Registration
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? FurnitureID { get; set; }
        public Furniture? Furniture { get; set; }
        public int? DesignerID { get; set; }
        public Designer? Designer { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
