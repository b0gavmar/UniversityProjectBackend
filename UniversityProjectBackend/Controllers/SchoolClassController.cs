using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProjectBackend.Models;

namespace UniversityProjectBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly DatabaseContext _context = new();

        //1. Készíts egy REST API végpontot, amely visszaadja egy hallgató nevét a megadott email alapján.
        [HttpGet("/api/student/{email}/name")]
        public async Task<IActionResult> GetStudentNameByEmail(string email)
        {
            return Ok(await _context.Students.Where(s => s.Email == email).Select(s=>s.Name).FirstOrDefaultAsync());
        }

        // 2.Készíts egy REST API végpontot, amely visszaadja, hogy egy hallgató be van-e iratkozva, a nevének megadásával.
        [HttpGet("/api/student/{name}/Enrolled")]
        public async Task<IActionResult> GetStudentEnrollmentByName(string name)
        {
            return Ok(await _context.Students.Where(s => s.Name == name).Select(s => s.Enrolled).FirstOrDefaultAsync());
        }

        //3. Feladat: Készíts egy REST API végpontot, amely visszaadja az egyes tanszékekhez tartozó hallgatók számát.
        [HttpGet("/api/departments/numberofstudents")]
        public async Task<IActionResult> GetDepartmentsStudentsNumber()
        {
            return Ok(await _context.Students.GroupBy(s=> s.DepartmentId).Select(g=> new { depId = g.Key, value = g.Count() }).ToListAsync());
        }

        //4. Feladat: Készíts egy REST API végpontot, amely visszaadja az összes tanár nevét és a hozzájuk tartozó tanszék nevét.
        [HttpGet("/api/departments/teachers")]
        public async Task<IActionResult> GetTeachersDepartments()
        {
            return Ok(await _context.Teachers.GroupBy(s => s.DepartmentId).Select(g => new { depId = g.Key, list = g.ToList() }).ToListAsync());
        }
    }
}
