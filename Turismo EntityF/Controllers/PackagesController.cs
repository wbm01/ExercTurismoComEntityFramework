using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo_EntityF.Data;
using Turismo_EntityF.Models;

namespace Turismo_EntityF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly Turismo_EntityFContext _context;

        public PackagesController(Turismo_EntityFContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackage()
        {
          if (_context.Package == null)
          {
              return NotFound();
          }
            
            await _context.Package.Include(c => c.HotelPackage).ToListAsync();
            await _context.Package.Include(c => c.TicketPackage).ToListAsync();
            await _context.Package.Include(c => c.ClientPackage).ToListAsync();
            await _context.Hotel.Include(c => c.AddressHotel).ToListAsync();
            await _context.Address.Include(c => c.City).ToListAsync();
            await _context.Ticket.Include(c => c.Origin).ToListAsync();
            await _context.Ticket.Include(c => c.Destiny).ToListAsync();
            await _context.Ticket.Include(c => c.ClientTicket).ToListAsync();
            await _context.Client.Include(c => c.AddressClient).ToListAsync();

            return await _context.Package.ToListAsync();
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
          if (_context.Package == null)
          {
              return NotFound();
          }

            await _context.Package.Include(c => c.HotelPackage).ToListAsync();
            await _context.Package.Include(c => c.TicketPackage).ToListAsync();
            await _context.Package.Include(c => c.ClientPackage).ToListAsync();
            await _context.Hotel.Include(c => c.AddressHotel).ToListAsync();
            await _context.Address.Include(c => c.City).ToListAsync();
            await _context.Ticket.Include(c => c.Origin).ToListAsync();
            await _context.Ticket.Include(c => c.Destiny).ToListAsync();
            await _context.Ticket.Include(c => c.ClientTicket).ToListAsync();
            await _context.Client.Include(c => c.AddressClient).ToListAsync();

            var package = await _context.Package.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, Package package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
          if (_context.Package == null)
          {
              return Problem("Entity set 'Turismo_EntityFContext.Package'  is null.");
            }

            var ticket = _context.Ticket.Find(package.TicketPackage.Id);
            var client = _context.Client.Find(package.ClientPackage.Id);
            var hotel = _context.Hotel.Find(package.HotelPackage.Id);

            package.TicketPackage = ticket;
            package.ClientPackage = client;
            package.HotelPackage = hotel;

            _context.Package.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            if (_context.Package == null)
            {
                return NotFound();
            }
            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageExists(int id)
        {
            return (_context.Package?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
