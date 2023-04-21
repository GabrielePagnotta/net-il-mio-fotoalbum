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
            
            var foto = _context.Photos.ToArray();
            return View(foto);
            ;
        }

        public IActionResult Detail(int id)
        {
            Photo singleuser = _context.Photos.Where(h => h.Id == id).FirstOrDefault();

            if (singleuser == null)
            {
                return NotFound($"l'id numero {id} non è stato trovato");
            }

            return View(singleuser);
            ;
        }
    }
}
