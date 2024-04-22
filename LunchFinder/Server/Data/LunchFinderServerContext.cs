﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LunchFinder.Server.Tags;

namespace LunchFinder.Server.Data
{
    public class LunchFinderServerContext(DbContextOptions<LunchFinderServerContext> options) : DbContext(options)
    {
        public DbSet<Tag> Tags { get; set; } = default!;
    }
}
