using foto.Models;
using Microsoft.AspNetCore.Mvc;

namespace foto.Controllers
{
    public class PhotoController : Controller
    {
        private readonly PhotoContext _context;
        

        public PhotoController(PhotoContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
