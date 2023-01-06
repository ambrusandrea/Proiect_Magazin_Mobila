using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Mobila.Data;
using Proiect_Magazin_Mobila.Models;

namespace Proiect_Magazin_Mobila.Pages.Furnitures
{
    public class CreateModel : FurnitureMaterialPageModel
    {
        private readonly Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext _context;

        public CreateModel(Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID", "FullName");
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID",
"CategoryName");
            var furniture = new Furniture();
            furniture.FurnitureMaterials = new List<FurnitureMaterial>();
            PopulateAssignedMaterialData(_context, furniture);

            return Page();
        }

        [BindProperty]
        public Furniture Furniture { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedMaterials)
        {
            var newFurniture = new Furniture();
            if (selectedMaterials != null)
            {
                newFurniture.FurnitureMaterials = new List<FurnitureMaterial>();
                foreach (var cat in selectedMaterials)
                {
                    var catToAdd = new FurnitureMaterial
                    {
                        MaterialID = int.Parse(cat)
                    };
                    newFurniture.FurnitureMaterials.Add(catToAdd);
                }
            }
            Furniture.FurnitureMaterials = newFurniture.FurnitureMaterials;
            _context.Furniture.Add(Furniture);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
       // PopulateAssignedMaterialData(_context, newFurniture);
       // return Page();
    }
}
