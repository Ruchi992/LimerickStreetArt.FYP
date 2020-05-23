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
    public class IndexModel : PageModel
    {
        private readonly LimerickStreetArt.Web.Data.LimerickStreetArtWebContext _context;

        public IndexModel(LimerickStreetArt.Web.Data.LimerickStreetArtWebContext context)
        {
            _context = context;
        }

        public IList<StreetArt> StreetArt { get;set; }

        public async Task OnGetAsync()
        {
            StreetArt = await _context.StreetArt.ToListAsync();
        }
    }
}
