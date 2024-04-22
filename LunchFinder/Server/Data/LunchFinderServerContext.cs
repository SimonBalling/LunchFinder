using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LunchFinder.Shared.Models;

namespace LunchFinder.Server.Data
{
    public class LunchFinderServerContext : DbContext
    {
        public LunchFinderServerContext (DbContextOptions<LunchFinderServerContext> options)
            : base(options)
        {
        }

        public DbSet<LunchFinder.Shared.Models.Tag> Tags { get; set; } = default!;
    }
}
