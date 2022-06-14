using BlazorApp.Server.Data;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext dbContext;

        public StudentController(StudentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Student), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> Create(Student student)
        {
            StudentResponse response = new();
            try
            {
                if (dbContext == null)
                {
                    response.HasErrors = true;
                    response.Errors.Add("Database service is not available.");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, response);
                }
                else
                {
                    Student? existingStudent = await dbContext.Students.FindAsync(student.Id);

                    if (existingStudent != null)
                    {
                        response.HasErrors = true;
                        response.Errors.Add(string.Format("A student already exists with the following id ({0}).", student.Id));
                        return Conflict(response);
                    }
                    else
                    {
                        await dbContext.Students.AddAsync(student);
                        await dbContext.SaveChangesAsync();
                        return CreatedAtAction(nameof(Create), new { student.Id }, student);
                    }
                }
            }
            catch (Exception ex)
            {
                response.HasErrors = true;
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> Get()
        {
           StudentResponse response = new();
            try
            {
                if (dbContext == null)
                {
                    response.HasErrors = true;
                    response.Errors.Add("Database service is not available.");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, response);
                }
                else
                {
                    List<Student> students = await dbContext.Students.ToListAsync();
                    if (students.Count == 0)
                    {
                        return NoContent();
                    }
                    else
                    {
                        foreach (Student student in students)
                        {
                            response.Students.Add(student);
                        }
                        return Ok(response);
                    }
                }
            }
            catch (Exception ex)
            {
                response.HasErrors = true;
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> GetById(string id)
        {
            StudentResponse response = new();
            try
            {
                if (dbContext == null)
                {
                    response.HasErrors = true;
                    response.Errors.Add("Database service is not available.");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, response);
                }
                else
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        response.HasErrors = true;
                        response.Errors.Add("The Id value was null or empty.");
                        return NotFound(response);
                    }
                    else
                    {
                        Student? student = await dbContext.Students.FindAsync(id);
                        if (student == null)
                        {
                            response.HasErrors = true;
                            response.Errors.Add(string.Format("Could not find a record with an id value ({0}).", id));
                            return NotFound(response);
                        }
                        else
                        {
                            response.Students.Add(student);
                            return Ok(response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.HasErrors = true;
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> Update(string Id, Student student)
        {
            StudentResponse response = new();
            try
            {
                if (dbContext == null)
                {
                    response.HasErrors = true;
                    response.Errors.Add("Database service is not available.");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, response);
                }
                else
                {
                    if (Id != student.Id)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        dbContext.Entry(student).State = EntityState.Modified;
                        await dbContext.SaveChangesAsync();
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                response.HasErrors = true;
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> Delete(string Id)
        {
            StudentResponse response = new();
            try
            {
                if (dbContext == null)
                {
                    response.HasErrors = true;
                    response.Errors.Add("Database service is not available.");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, response);
                }
                else
                {
                    Student? studentToDelete = await dbContext.Students.FindAsync(Id);
                    if (studentToDelete == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        dbContext.Students.Remove(studentToDelete);
                        await dbContext.SaveChangesAsync();
                        return NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                response.HasErrors = true;
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}