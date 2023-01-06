using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Magazin_Mobila.Data;
using Proiect_Magazin_Mobila.Models;

namespace Proiect_Magazin_Mobila.Pages.Furnitures
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext _context;

        public CreateModel(Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DesignerID"] = new SelectList(_context.Set<Designer>(), "ID", "FirstName", "LastName");
            return Page();
        }

        [BindProperty]
        public Furniture Furniture { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Furniture.Add(Furniture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
