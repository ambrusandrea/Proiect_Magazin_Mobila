using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Mobila.Data;
using Proiect_Magazin_Mobila.Models;

namespace Proiect_Magazin_Mobila.Pages.Registrations
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext _context;

        public DeleteModel(Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Registration Registration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration.FirstOrDefaultAsync(m => m.ID == id);

            if (registration == null)
            {
                return NotFound();
            }
            else 
            {
                Registration = registration;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Registration == null)
            {
                return NotFound();
            }
            var registration = await _context.Registration.FindAsync(id);

            if (registration != null)
            {
                Registration = registration;
                _context.Registration.Remove(Registration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
