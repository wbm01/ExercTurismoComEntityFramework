﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using Turismo_EntityF.Data;
using Turismo_EntityF.Models;

namespace Turismo_EntityF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly Turismo_EntityFContext _context;

        public TicketsController(Turismo_EntityFContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            
            if (_context.Ticket == null)
            {
                return NotFound();
            }

            await _context.Ticket.Include(o => o.Origin).ToListAsync();
            await _context.Address.Include(c => c.City).ToListAsync();
            await _context.Ticket.Include(t => t.Destiny).ToListAsync();
            await _context.Ticket.Include(c => c.ClientTicket).ToListAsync();

            return await _context.Ticket.ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
          if (_context.Ticket == null)
          {
              return NotFound();
          }
            await _context.Ticket.Include(o => o.Origin).ToListAsync();
            await _context.Address.Include(c => c.City).ToListAsync();
            await _context.Ticket.Include(t => t.Destiny).ToListAsync();
            await _context.Ticket.Include(c => c.ClientTicket).ToListAsync();

            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            var origin = _context.Address.Find(ticket.Origin.Id);
            var destiny = _context.Address.Find(ticket.Destiny.Id);
            var client = _context.Client.Find(ticket.ClientTicket.Id);

            ticket.Origin = origin;
            ticket.Destiny = destiny;
            ticket.ClientTicket = client;

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
          if (_context.Ticket == null)
          {
              return Problem("Entity set 'Turismo_EntityFContext.Ticket'  is null.");
          }
            var origin = _context.Address.Find(ticket.Origin.Id);
            var destiny = _context.Address.Find(ticket.Destiny.Id);
            var client = _context.Client.Find(ticket.ClientTicket.Id);

            ticket.Origin = origin;
            ticket.Destiny = destiny;
            ticket.ClientTicket = client;

            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            if (_context.Ticket == null)
            {
                return NotFound();
            }
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return (_context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
