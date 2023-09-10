using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SVLT230609.AcademyAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SVLT230609.AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        static List<Note> notes = new List<Note>();

        // GET: api/<NoteController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Note> Get()
        {
            return notes;
        }

        // POST api/<NoteController>
        [HttpPost]
        [Authorize]
        public IActionResult Post(int id, string alum, int not, string subject)
        {
            var note = new Note
            {
                Id = id,
                Alum = alum,
                not = not,
                Subjet = subject
            };

            notes.Add(note);
            return Ok();
        }
    }
}
