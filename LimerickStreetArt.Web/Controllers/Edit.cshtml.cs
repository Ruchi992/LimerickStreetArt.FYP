using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LimerickStreetArt;
using LimerickStreetArt.Web.Data;

namespace LimerickStreetArt.Web.Controllers
{
    public class EditModel : PageModel
    {
        private readonly LimerickStreetArt.Web.Data.LimerickStreetArtWebContext _context;

        public EditModel(LimerickStreetArt.Web.Data.LimerickStreetArtWebContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StreetArt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StreetArtExists(StreetArt.Id))
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

        private bool StreetArtExists(int id)
        {
            return _context.StreetArt.Any(e => e.Id == id);
        }
    }
}
