using CaseStudy_NAL.Data;
using CaseStudy_NAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy_NAL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactPersonController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactPersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactPerson>>> GetContactPersons()
        {
            return await _context.ContactPersons.Include(cp => cp.Vendor).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactPerson>> GetContactPerson(int id)
        {
            var contactPerson = await _context.ContactPersons.Include(cp => cp.Vendor).FirstOrDefaultAsync(cp => cp.Id == id);

            if (contactPerson == null)
            {
                return NotFound();
            }

            return contactPerson;
        }

        [HttpPost]
        public async Task<ActionResult<ContactPerson>> PostContactPerson(ContactPerson contactPerson)
        {
            _context.ContactPersons.Add(contactPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactPerson", new { id = contactPerson.Id }, contactPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactPerson(int id, ContactPerson contactPerson)
        {
            if (id != contactPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactPersonExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactPerson(int id)
        {
            var contactPerson = await _context.ContactPersons.FindAsync(id);
            if (contactPerson == null)
            {
                return NotFound();
            }

            _context.ContactPersons.Remove(contactPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactPersonExists(int id)
        {
            return _context.ContactPersons.Any(cp => cp.Id == id);
        }
    }

}
