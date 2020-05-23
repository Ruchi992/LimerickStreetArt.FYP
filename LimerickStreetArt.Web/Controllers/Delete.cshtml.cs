using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LimerickStreetArt;
using LimerickStreetArt.Web.Data;

namespace LimerickStreetArt.Web.Controllers
{
    public class DeleteModel : PageModel
    {
        private readonly LimerickStreetArt.Web.Data.LimerickStreetArtWebContext _context;

        public DeleteModel(LimerickStreetArt.Web.Data.LimerickStreetArtWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StreetArt StreetArt { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StreetArt = await _context.StreetArt.FirstOrDefaultAsync(m => m.Id == id);

            if (StreetArt == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StreetArt = await _context.StreetArt.FindAsync(id);

            if (StreetArt != null)
            {
                _context.StreetArt.Remove(StreetArt);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
