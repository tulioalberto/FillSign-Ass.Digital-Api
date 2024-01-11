using FillSign.Ds.Application.CommandHandlers;
using FillSign.Ds.Data;
using FillSign.Ds.Domain;
using FillSign.Ds.Services.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FillSign.Ds.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/document")]
    public class DocumentController : ControllerBaseCustom
    {
        private readonly ApiDbContext _context;
        private readonly IDocumentApplication _documentApplication;
        private readonly INotificationDomain<NotificationDomainMessage>? _notifications;
        public DocumentController(ApiDbContext context, 
            INotificationDomain<NotificationDomainMessage>notifications,
            IDocumentApplication documentApplication) : base(context, notifications)
        {
            _context = context;
            _notifications = notifications;
            _documentApplication = documentApplication;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocoments()
        {
            return await _context.Documents.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _documentApplication.GetDocumentById(id);

            if (_notifications.HasNotifications())
                return NotFound(new { Errors = _notifications.GetAll() });

            return Ok(document);
        }

        [HttpPost]
        public async Task<ActionResult<Document>> PostDocument(Document document)
        {
            var createdDocument = await _documentApplication.CreateDocument(document);

            if (_notifications.HasNotifications())
                return BadRequest(new { Errors = _notifications.GetAll() });
            
            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDocument(int id, Document document)
        {
            var updateDocument = await _documentApplication.UpdateDocument(id, document);

            if (_notifications.HasNotifications())
                return NotFound(new { Errors = _notifications.GetAll() });

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDocument(int id, Document document)
        {
            var deleteDocument = await _documentApplication.DeleteDocument(id, document);

            if (_notifications.HasNotifications())
                return NotFound(new { Errors = _notifications.GetAll() });

            return NoContent();
        }
    }
}
