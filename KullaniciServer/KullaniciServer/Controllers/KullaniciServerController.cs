using KullaniciServer.Database;
using KullaniciServer.Dto;
using KullaniciServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KullaniciServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KullaniciServerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public KullaniciServerController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _db.Users.Where(user => user.IsDelete == false).ToListAsync();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _db.Users.FirstOrDefaultAsync(user => user.id == id);
            if (response == null || response.IsDelete == true)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Created([FromBody] UsersDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Users()
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Floor = newUser.Floor,
                IsStudent = newUser.IsStudent,
                BrithDate = newUser.BrithDate,
                CreatedDate = DateTime.Now,
                IsDelete = false
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UsersDto update)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = update.FirstName;
            user.LastName = update.LastName;
            user.Floor = update.Floor;
            user.IsStudent = update.IsStudent;
            user.BrithDate = update.BrithDate;
            await _db.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.id == id);
            if(user == null)
            {
                return NotFound();
            }
            user.IsDelete = true;
            await _db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
