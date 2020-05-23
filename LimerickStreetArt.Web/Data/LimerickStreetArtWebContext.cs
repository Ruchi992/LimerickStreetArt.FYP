using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LimerickStreetArt;

namespace LimerickStreetArt.Web.Data
{
    public class LimerickStreetArtWebContext : DbContext
    {
        public LimerickStreetArtWebContext (DbContextOptions<LimerickStreetArtWebContext> options)
            : base(options)
        {
        }

        public DbSet<LimerickStreetArt.StreetArt> StreetArt { get; set; }
    }
}
