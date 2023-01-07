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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext _context;

        public IndexModel(Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext context)
        {
            _context = context;
        }

        public IList<Registration> Registration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Registration != null)
            {
                Registration = await _context.Registration
                .Include(b => b.Furniture)
                .Include(b => b.Designer)
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
