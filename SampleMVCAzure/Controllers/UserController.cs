using SampleMVCAzure.DataAccess;
using SampleMVCAzure.Models;
using Microsoft.AspNetCore.Mvc;

namespace SampleMVCAzure.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;


        public UserController(IConfiguration config, ILogger<UserController> logger, ApplicationDbContext context)
        {
            _config = config;
            _logger=logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Message = _config["FeatureSettings:BannerMessage"];
            var users = _context.Users.ToList();
            return View(users);
        }


        public IActionResult ShowUserDetail()
        {
            Users users = new();
            return View("_User", users);
        }

        [HttpPost]
        public IActionResult Create(Users user)
        {
            
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var users = _context.Users.Find(id);
            return View("_User", users);
        }

        [HttpPost]
        public IActionResult Edit(Users emp)
        {
            _context.Users.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

