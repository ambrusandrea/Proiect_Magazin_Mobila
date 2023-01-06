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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext _context;

        public IndexModel(Proiect_Magazin_Mobila.Data.Proiect_Magazin_MobilaContext context)
        {
            _context = context;
        }

        public IList<Furniture> Furniture { get; set; } = default!;

        public FurnitureData FurnitureD { get; set; }
        public int FurnitureID { get; set; }
        public int MaterialID { get; set; }
        public async Task OnGetAsync(int? id, int? materialID)
        {
            FurnitureD = new FurnitureData();

            FurnitureD.Furnitures = await _context.Furniture
            .Include(b => b.Designer)
            .Include(b => b.Categories)
            .Include(b => b.FurnitureMaterials)
            .ThenInclude(b => b.Material)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                FurnitureID = id.Value;
                Furniture furniture = FurnitureD.Furnitures
                .Where(i => i.ID == id.Value).Single();
                FurnitureD.Materials = furniture.FurnitureMaterials.Select(s => s.Material);
            }
        }

    }
}
