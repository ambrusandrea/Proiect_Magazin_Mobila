using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin_Mobila.Data;
using Proiect_Magazin_Mobila.Models;

namespace Proiect_Magazin_Mobila.Pages.Furnitures
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext _context;

        public DetailsModel(Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext context)
        {
            _context = context;
        }

      public Furniture Furniture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Furniture == null)
            {
                return NotFound();
            }

            var furniture = await _context.Furniture.FirstOrDefaultAsync(m => m.ID == id);
            if (furniture == null)
            {
                return NotFound();
            }
            else 
            {
                Furniture = furniture;
            }
            return Page();
        }
    }
}
