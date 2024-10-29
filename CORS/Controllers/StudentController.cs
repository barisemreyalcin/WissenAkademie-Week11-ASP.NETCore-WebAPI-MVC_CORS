using CORS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		List<Student> studentList = new List<Student>()
		{
			new Student()
			{
				StudentNumber = "10001",
				FirstName = "John",
				LastName = "Doe",
				Address = "USA",
				Phone = "1234567890"
			},
			new Student()
			{
				StudentNumber = "10002",
				FirstName = "Jane",
				LastName = "Doe",
				Address = "USA",
				Phone = "2233445566"
			},
			new Student()
			{
				StudentNumber = "10003",
				FirstName = "Larry",
				LastName = "Doe",
				Address = "USA",
				Phone = "684562655"
			},
			new Student()
			{
				StudentNumber = "10004",
				FirstName = "Gary",
				LastName = "Doe",
				Address = "USA",
				Phone = "566684613"
			},
		};

		[HttpGet]
		[Route("GetAllStudents")]
		public IEnumerable<Student> GetAllStudents()
		{
			return studentList;
		}

		[HttpPost]
		[Route("GetStudentByNumber")]
		//public IActionResult GetStudentByQueryParams ([FromBody]QueryParams query)
		public IActionResult GetStudentByQueryParams(QueryParams query)
		{
			Student student = studentList.FirstOrDefault(x => x.StudentNumber == query.StudentNumber);
			return Ok(student);
		}
	}
}
