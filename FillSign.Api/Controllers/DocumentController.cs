using FillSign.Ds.Data;
using FillSign.Ds.Services.Notification;
using Microsoft.AspNetCore.Mvc;

namespace FillSign.Ds.Api.Controllers
{
    [ApiController]
    [Route("api/document")]
    public class DocumentController : ControllerBaseCustom
    {
        private readonly ApiDbContext _context;
        private readonly INotificationDomain<NotificationDomainMessage>? _notifications;
        public DocumentController(ApiDbContext context, 
            INotificationDomain<NotificationDomainMessage>notifications)
        {
            _context = context;
            _notifications = notifications;
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
