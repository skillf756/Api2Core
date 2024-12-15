using Api2Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Api2Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly MyDbContext contex;

        public ApiController(MyDbContext contex)
        {
            this.contex = contex;
        }
        [HttpGet]
        public async Task<ActionResult<List<StudentDb>>> getStudent()
        {
            var data=await contex.StudentDbs.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<StudentDb>>> getStudent(int id)
        {
            var data = await contex.StudentDbs.FindAsync(id);
            if (data==null)
            {
              return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<List<StudentDb>>> CreateData(StudentDb std)
        {
            await contex.StudentDbs.AddAsync(std);
            await contex.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDb> >UpdateData(int id,StudentDb stu)
        {
            if (id != stu.Id)
            {
                BadRequest();
            }
            contex.Entry(stu).State=EntityState.Modified;   
            await contex.SaveChangesAsync();
            return Ok(stu);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StudentDb>>> DeleteData(int id)
        {
            var stu=await contex.StudentDbs.FindAsync(id);
            if (stu == null)
            {
                return NotFound();
            }
            contex.StudentDbs.Remove(stu);
            await contex.SaveChangesAsync();
            return Ok();
        }
    }
}
