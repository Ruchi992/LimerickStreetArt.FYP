using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LimerickStreetArt;
using LimerickStreetArt.Web.Data;

namespace LimerickStreetArt.Web.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly LimerickStreetArt.Web.Data.LimerickStreetArtWebContext _context;

        public CreateModel(LimerickStreetArt.Web.Data.LimerickStreetArtWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StreetArt StreetArt { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StreetArt.Add(StreetArt);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
