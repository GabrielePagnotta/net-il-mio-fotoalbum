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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Photo data)
        {
            if(!ModelState.IsValid)
            {
                return View("Create",data);
            }
            Photo newphoto = new Photo();
            newphoto.Title = data.Title;
            newphoto.Description = data.Description;
            newphoto.ImageUrl = data.ImageUrl;
            _context.Photos.Add(newphoto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Photo editphoto = _context.Photos.Where(photo => photo.Id == id).FirstOrDefault();
            if(editphoto == null)
            {
                return NotFound();
            }
            else
            {
                return View(editphoto);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Photo data)
        {
           /* if(ModelState.IsValid)
            {
                return View("Edit", data);
            }*/
            Photo newphotoedit = _context.Photos.Where(p=> p.Id == id).FirstOrDefault();

            if(newphotoedit != null)
            {
                newphotoedit.Title= data.Title;
                newphotoedit.Description= data.Description;
                newphotoedit.ImageUrl = data.ImageUrl;
                _context.SaveChanges();
                return RedirectToAction("Index", data);

            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Photo phototodelete =_context.Photos.Where(m=>m.Id==id).FirstOrDefault();

            if(phototodelete != null)
            {
                _context.Photos.Remove(phototodelete);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
