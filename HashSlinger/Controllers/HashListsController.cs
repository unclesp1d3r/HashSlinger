using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HashSlinger.Data;
using HashSlinger.Models;

namespace HashSlinger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashListsController : ControllerBase
    {
        private readonly HashSlingerContext _context;

        public HashListsController(HashSlingerContext context)
        {
            _context = context;
        }

        // GET: api/HashLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HashList>>> GetHashList()
        {
          if (_context.HashList == null)
          {
              return NotFound();
          }
            return await _context.HashList.ToListAsync();
        }

        // GET: api/HashLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HashList>> GetHashList(int id)
        {
          if (_context.HashList == null)
          {
              return NotFound();
          }
            var hashList = await _context.HashList.FindAsync(id);

            if (hashList == null)
            {
                return NotFound();
            }

            return hashList;
        }

        // PUT: api/HashLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHashList(int id, HashList hashList)
        {
            if (id != hashList.Id)
            {
                return BadRequest();
            }

            _context.Entry(hashList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HashListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HashLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HashList>> PostHashList(HashList hashList)
        {
          if (_context.HashList == null)
          {
              return Problem("Entity set 'HashSlingerContext.HashList'  is null.");
          }
            _context.HashList.Add(hashList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHashList", new { id = hashList.Id }, hashList);
        }

        // DELETE: api/HashLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHashList(int id)
        {
            if (_context.HashList == null)
            {
                return NotFound();
            }
            var hashList = await _context.HashList.FindAsync(id);
            if (hashList == null)
            {
                return NotFound();
            }

            _context.HashList.Remove(hashList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HashListExists(int id)
        {
            return (_context.HashList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
