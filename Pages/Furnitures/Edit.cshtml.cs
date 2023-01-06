using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Mobila.Data;
using Proiect_Magazin_Mobila.Models;

namespace Proiect_Magazin_Mobila.Pages.Furnitures
{
    public class EditModel : FurnitureMaterialPageModel
    {
        private readonly Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext _context;

        public EditModel(Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Furniture Furniture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Furniture == null)
            {
                return NotFound();
            }
            Furniture = await _context.Furniture
                 .Include(b => b.Designer)
                 .Include(b => b.FurnitureMaterials).ThenInclude(b => b.Material)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            PopulateAssignedMaterialData(_context, Furniture);


            var furniture =  await _context.Furniture.FirstOrDefaultAsync(m => m.ID == id);
            if (furniture == null)
            {
                return NotFound();
            }
            Furniture = furniture;
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID", "FirstName", "LastName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedMaterials)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var furnitureToUpdate = await _context.Furniture
            .Include(i => i.Designer)
            .Include(i => i.FurnitureMaterials)
            .ThenInclude(i => i.Material)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (furnitureToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Furniture>(
            furnitureToUpdate,
            "Furniture",
            i => i.Name, i => i.Price,
            i => i.DesignerID))
            {
                UpdateFurnitureMaterials(_context, selectedMaterials, furnitureToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateFurnitureMaterials(_context, selectedMaterials, furnitureToUpdate);
            PopulateAssignedMaterialData(_context, furnitureToUpdate);
            return Page();
        }
    }

}
