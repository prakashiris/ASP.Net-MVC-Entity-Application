using EntitytoDatabse.Models;
using EntitytoDatabse.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace EntitytoDatabse.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext _context;

        public ProductController()
        {
            _context = new StoreContext();

        }

        public ActionResult Create()
        {
            var _categories = _context.Categories.ToList();

            var viewModel = new ProductFormViewModel
            {
                Product = new Product(),
                Categories = _categories
            };
            return View(viewModel);
        }
        
      
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View("Create", product);
            if (product.Id > 0)
                _context.Entry(product).State = EntityState.Modified;
            else
               _context.Product.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {



            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var _product = _context.Product.SingleOrDefault(p => p.Id == id);

            if (_product == null)
                return HttpNotFound();


            var viewModel = new ProductFormViewModel
            {
                Product = _product,
                Categories = _context.Categories.ToList()
            };
            return View("Create", viewModel);
        }
        
        // GET: Product
        public ActionResult Index()
        {
            var products = _context.Product.Include(c => c.Category).ToList();
            return View(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
}