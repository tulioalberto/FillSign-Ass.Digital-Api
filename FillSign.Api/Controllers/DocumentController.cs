using FillSign.Ds.Application.Models;
using FillSign.Ds.Domain.Data;
using FillSign.Ds.Services.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FillSign.Ds.Api.Controllers
{
    [ApiController]
    [Route("api/document")]
    public class DocumentController : ControllerBaseCustom
    {
        private readonly ApiDbContext _context;
        public DocumentController(ApiDbContext context, 
            INotificationDomain<NotificationDomainMessage>notifications) : base(notifications)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocoments()
        {
            return await _context.Documents.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Document>> GetDocoment(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            return document;
        }

        [HttpPost]
        public async Task<ActionResult<Document>> PostDocument(Document document)
        {
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocoment), new { id = document.Id }, document);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDocument(int id, Document document)
        {
            _context.Documents.Update(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDocument(Document document, int id)
        {
            var documents = await _context.Documents.FindAsync();
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
