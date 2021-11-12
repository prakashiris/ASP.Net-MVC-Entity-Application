using EntitytoDatabse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntitytoDatabse.Controllers
{
    public class CategoryController : Controller
    {
        private StoreContext _context;

        public CategoryController(){
            _context = new StoreContext();   
        }
        // GET: Category
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View(new Category { Id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Category _category)
        {
            if (!ModelState.IsValid)
                return View("Create", _category);
            if (_category.Id > 0)
                _context.Entry(_category).State = System.Data.Entity.EntityState.Modified;
            else
                _context.Categories.Add(_category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if(id == null){
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if(category == null)
            {
                return HttpNotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();



            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var _category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (_category == null)
                return HttpNotFound();

            return View("Create", _category);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}