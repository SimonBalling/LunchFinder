#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member - Will be done later

namespace LunchFinder.Server.Tags;

using LunchFinder.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class TagsController(LunchFinderServerContext context) : ControllerBase
{
    // GET: api/Tags
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
    {
        return await context.Tags.ToListAsync();
    }

    /// <summary>
    ///     Get Tag by ID
    /// </summary>
    /// <param name="id">The tags ID</param>
    /// <returns></returns>
    /// <response code="404">fghfghf</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Tag>> GetTag(int id)
    {
        var tag = await context.Tags.FindAsync(id);

        if (tag == null) return NotFound();

        return tag;
    }

    // PUT: api/Tags/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTag(int id, Tag tag)
    {
        if (id != tag.Id) return BadRequest();

        context.Entry(tag).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TagExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Tags
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Tag>> PostTag(Tag tag)
    {
        context.Tags.Add(tag);
        await context.SaveChangesAsync();

        return CreatedAtAction("GetTag", new { id = tag.Id }, tag);
    }

    // DELETE: api/Tags/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        var tag = await context.Tags.FindAsync(id);
        if (tag == null) return NotFound();

        context.Tags.Remove(tag);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool TagExists(int id)
    {
        return context.Tags.Any(e => e.Id == id);
    }
}