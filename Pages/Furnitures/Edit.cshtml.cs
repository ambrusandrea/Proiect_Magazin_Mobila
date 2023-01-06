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
    public class EditModel : PageModel
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Furniture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnitureExists(Furniture.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FurnitureExists(int id)
        {
          return _context.Furniture.Any(e => e.ID == id);
        }
    }
}
