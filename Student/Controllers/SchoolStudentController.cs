using Student.Models;
using Microsoft.AspNetCore.Mvc;
using Student.Data;

namespace Student.Controllers
{
    [Route("api/SchoolStudentAPI")]
    [ApiController]
    public class SchoolStudentAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SchoolStudent> GetStudents()
        {
            return SchoolStudentStore.SchoolStudentsList;

        }

    }
}
