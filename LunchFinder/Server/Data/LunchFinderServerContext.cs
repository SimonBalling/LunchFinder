#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace LunchFinder.Server.Data;

using Microsoft.EntityFrameworkCore;
using Places;
using Tags;

public class LunchFinderServerContext(DbContextOptions<LunchFinderServerContext> options) : DbContext(options)
{
    public DbSet<Tag> Tags { get; set; } = default!;
    public DbSet<Place> Places { get; set; } = default!;

    public DbSet<Address> Address { get; set; } = default!;
}