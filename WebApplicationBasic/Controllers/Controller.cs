using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBasic.Controllers;

[Route("api/[controller]")]
        [ApiController]
        public class StudentController : ControllerBase
        {
            private List<Student> _students = new List<Student>();

            [HttpGet]
            public ActionResult<IEnumerable<Student>> GetStudents()
            {
                return Ok(_students);
            }

            [HttpGet("{id}")]
            public ActionResult<Student> GetStudent(int id)
            {
                Student student = _students.Find(s => s.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(student);
                }
            }

            [HttpPost]
            public ActionResult<Student> AddStudent([FromBody] Student student)
            {
                student.Id = GenerateNewId();
                _students.Add(student);
                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }

            [HttpPut("{id}")]
            public ActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
            {
                Student student = _students.Find(s => s.Id == id);
                if (student != null)
                {
                    student.Name = updatedStudent.Name;
                    student.Age = updatedStudent.Age;
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }

            [HttpDelete("{id}")]
            public ActionResult DeleteStudent(int id)
            {
                Student student = _students.Find(s => s.Id == id);
                if (student != null)
                {
                    _students.Remove(student);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }

            private int GenerateNewId()
            {
                int maxId = -1;
                foreach (Student student in _students)
                {
                    if (student.Id > maxId)
                    {
                        maxId = student.Id;
                    }
                }
                return maxId + 1;
            }
        }

        public class Student
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        }
