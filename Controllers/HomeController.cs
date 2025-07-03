using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to Home API");
        }

        [HttpGet("user")]
        public IActionResult GetUsers()
        {
            var users = _dbContext.Users.ToList();
            return Ok(users);
        }

        [HttpPost("user")]
        public IActionResult PostUser(AddUserDTO addUserDTO)
        {
            var user = new User
            {
                FirstName = addUserDTO.FirstName,
                LastName = addUserDTO.LastName,
                Email = addUserDTO.Email
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Ok(user);
        }

    }
}
