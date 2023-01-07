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

namespace Proiect_Magazin_Mobila.Pages.Registrations
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
            var furnitureList = _context.Furniture
             .Include(b => b.Designer)
             .Select(x => new
           {
              x.ID,
     FurnitureFullName = x.Name + " - " + x.Designer.LastName + " " +
x.Designer.FirstName
 });

            ViewData["FurnitureID"] = new SelectList(furnitureList, "ID", "FurnitureFullName");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Registration Registration { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Registration.Add(Registration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
