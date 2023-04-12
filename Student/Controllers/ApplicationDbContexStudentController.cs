using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Student.Data;
using Student.Models;
namespace Student.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ApplicationDbContexStudentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ApplicationDbContexStudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SchoolStudent>> GetStudents()
        {
            return Ok(_db.Students.ToList());
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public ActionResult<SchoolStudent> GetDetail(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var OutputVariable = _db.Students.FirstOrDefault(u => u.ID == id);
            if (OutputVariable == null)
            {
                return NotFound();
            }
            return Ok(OutputVariable);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<SchoolStudent> CreateDetail([FromBody] SchoolStudent student)
        {
            if (student == null)
            {
                return BadRequest(student);
            }
            if (_db.Students.FirstOrDefault(u => u.Name.ToLower() == student.Name.ToLower()) != null)
            {
                ModelState.AddModelError("ERROR", "Student Name already Exists!");
                return BadRequest(ModelState);
            }
            SchoolStudent model = new()
            {
                ID = student.ID,
                Name = student.Name,
                standard = student.standard
            };
            _db.Students.Add(model);
            _db.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public ActionResult DeleteDetail(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var StudentID = _db.Students.FirstOrDefault(u => u.ID == id);
            if (StudentID == null)
            {
                return NotFound();
            }
            _db.Students.Remove(StudentID);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult PutDetail(int id, [FromBody] SchoolStudent student)
        {
            if (id != student.ID || student == null)
            {
                return BadRequest();
            }
            SchoolStudent model = new()
            {
                ID = student.ID,
                Name = student.Name,
                standard = student.standard
            };
            _db.Students.Update(model);
            return NoContent();
        }

    }
}
