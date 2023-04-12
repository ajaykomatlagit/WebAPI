using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Student.Data;
using Student.Models.Details;
namespace Student.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SchoolStudentDetailsController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<SchoolStudentDetails> GetDetails()
        {
            return SchoolStudentStore.SchoolStudentsDetailsList;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public ActionResult<SchoolStudentDetails> GetDetail(int id) 
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var OutputVariable = SchoolStudentStore.SchoolStudentsDetailsList.FirstOrDefault(u => u.ID == id);
            if (OutputVariable == null)
            {
                return NotFound();
            }
            return OutputVariable;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<SchoolStudentDetails> CreateDetail([FromBody]SchoolStudentDetails student)
        {
            if (student == null)
            {
                return BadRequest(student);
            }
            if (SchoolStudentStore.SchoolStudentsDetailsList.FirstOrDefault(u=>u.Name.ToLower() == student.Name.ToLower()) != null)
            {
                ModelState.AddModelError("ERROR", "Student Name already Exists!");
                return BadRequest(ModelState);
            } 
            student.ID = SchoolStudentStore.SchoolStudentsDetailsList.OrderByDescending(u => u.ID).FirstOrDefault().ID + 1;
            SchoolStudentStore.SchoolStudentsDetailsList.Add(student);

            return (student);
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
            var StudentID = SchoolStudentStore.SchoolStudentsDetailsList.FirstOrDefault(u=>u.ID==id);
            if (StudentID == null) 
            {
                return NotFound();
            }
            SchoolStudentStore.SchoolStudentsDetailsList.Remove(StudentID);
            return NoContent();
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult PutDetail(int id,[FromBody]SchoolStudentDetails student)
        {
            if(id != student.ID  || student == null)
            {
                return BadRequest();
            }
            var UpdateVariable = SchoolStudentStore.SchoolStudentsDetailsList.FirstOrDefault(u=>u.ID == id);
            UpdateVariable.Name = student.Name;
            UpdateVariable.Description = student.Description;

            return NoContent();
        }
        [HttpPatch("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public ActionResult PatchDetail(int id, JsonPatchDocument<SchoolStudentDetails> patchstudent)
        {
            if (id == 0 || patchstudent == null)
            {
                return BadRequest();
            }
            var student = SchoolStudentStore.SchoolStudentsDetailsList.FirstOrDefault(u => u.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            patchstudent.ApplyTo(student, ModelState);
            return NoContent();
        }

    }
}
