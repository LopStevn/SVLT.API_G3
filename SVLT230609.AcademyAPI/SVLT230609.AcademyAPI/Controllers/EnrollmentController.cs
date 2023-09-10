using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SVLT230609.AcademyAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SVLT230609.AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnrollmentController : ControllerBase
    {
        static List<Enrollment> enrollments = new List<Enrollment>();

        // GET: api/<EnrollmentController>
        [HttpGet]
        public IEnumerable<Enrollment> Get()
        {
            return enrollments;
        }

        // GET api/<EnrollmentController>/5
        [HttpGet("{id}")]
        public Enrollment Get(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.Id == id);
            return enrollment;
        }

        // POST api/<EnrollmentController>
        [HttpPost]
        public IActionResult Post(int id, string fullName, string degree, int year)
        {
            // Crea una nueva instancia de Enrollment utilizando los datos proporcionados
            var enrollment = new Enrollment
            {
                Id = id,
                FullName = fullName,
                Degree = degree,
                Year = year
            };

            enrollments.Add(enrollment);
            return Ok();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Enrollment enrollment)
        {
            var existingEnrollment = enrollments.FirstOrDefault(e => e.Id == id);
            if (existingEnrollment != null)
            {
                existingEnrollment.FullName = enrollment.FullName;
                existingEnrollment.Degree = enrollment.Degree;
                existingEnrollment.Year = enrollment.Year;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
