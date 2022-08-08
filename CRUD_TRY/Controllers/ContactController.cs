using CRUD_TRY.Data;
using CRUD_TRY.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TRY.Controllers
{
    public class ContactController : Controller
    {

        private readonly ApplicationDbContext _db;
        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Contact> objContactList = _db.Contacts;
            return View(objContactList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact obj)
        {
            if(obj.PhoneNumber is not null)
            {
                if(!obj.PhoneNumber.All(char.IsDigit))
                {
                    ModelState.AddModelError("phonenumber", "PhoneNumber should only contains digits !");
                }
                
            }
            if(ModelState.IsValid)
            {
                _db.Contacts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Remove(int? id)
        {
    

            Contact? obj = _db.Contacts.Find(id);

            if(obj is not null)
            {
                _db.Contacts.Remove(obj);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Update(int? id)
        {
            Contact? obj = _db.Contacts.Find(id);
            if (obj is not null)
            {
                return View(obj);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Contact obj)
        {

            if (obj.PhoneNumber is not null)
            {
                if (!obj.PhoneNumber.All(char.IsDigit))
                {
                    ModelState.AddModelError("phonenumber", "PhoneNumber should only contains digits !");
                }

            }
            if (ModelState.IsValid)
            {
                _db.Contacts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
