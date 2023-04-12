using Student.Models;
using Student.Models.Details;
namespace Student.Data
{
    public static class SchoolStudentStore
    {
        public static List<SchoolStudent> SchoolStudentsList = new List<SchoolStudent>{
            new SchoolStudent{ ID = 1, Name = "Vijay", standard = 5 },
            new SchoolStudent{ID = 2, Name = "Abdul", standard = 6 }
            };
        public static List<SchoolStudentDetails> SchoolStudentsDetailsList = new List<SchoolStudentDetails>{
            new SchoolStudentDetails{ ID = 1, Name = "Vijay",Description = "New Admission" },
            new SchoolStudentDetails{ID = 2, Name = "Abdul", Description = " " }
            };
    }
}
