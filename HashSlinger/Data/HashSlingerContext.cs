using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HashSlinger.Models;

namespace HashSlinger.Data
{
    public class HashSlingerContext : DbContext
    {
        public HashSlingerContext (DbContextOptions<HashSlingerContext> options)
            : base(options)
        {
        }

        public DbSet<HashSlinger.Models.HashList> HashList { get; set; } = default!;
    }
}
