#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member - Will be done later

namespace LunchFinder.Server.Places;

using LunchFinder.Server.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PlacesController(LunchFinderServerContext context) : ControllerBase
{
    // GET: api/Places
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
    {
        return await context.Places.ToListAsync();
    }

    // GET: api/Places/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Place>> GetPlace(int id)
    {
        var place = await context.Places.FindAsync(id);

        if (place == null) return NotFound();

        return place;
    }

    // PUT: api/Places/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPlace(int id, Place place)
    {
        if (id != place.Id) return BadRequest();

        context.Entry(place).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PlaceExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Places
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Place>> PostPlace(Place place)
    {
        context.Places.Add(place);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetPlace", new { id = place.Id }, place);
    }

    // DELETE: api/Places/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlace(int id)
    {
        var place = await context.Places.FindAsync(id);
        if (place == null) return NotFound();

        context.Places.Remove(place);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool PlaceExists(int id)
    {
        return context.Places.Any(e => e.Id == id);
    }
}