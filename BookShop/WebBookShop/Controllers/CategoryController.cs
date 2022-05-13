using BookShop.DataAccessLayer;
using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebBookShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            IEnumerable<Category> list = _db.Categories;
            return View(list);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create(int? id)
        {
            var get = _db.Categories.Find(id);
            return View(get);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            try
            {
                if (model.Name==model.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Name and Oder will not be matched");
                }
                if (ModelState.IsValid)
                {
                _db.Categories.Add(model);
                _db.SaveChanges();
                TempData["success"] = "Data Created successfully";

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int? id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                return View(category);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category model)
        {
            try
            {
                if (model.Name == model.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Name and Oder will not be matched");
                }
                if (ModelState.IsValid)
                {
                    _db.Categories.Update(model);
                    _db.SaveChanges();
                    TempData["success"] = "Data Updated successfully";

                    return RedirectToAction(nameof(Index));
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {

            var category = _db.Categories.Find(id);
            if (category != null)
            {
               
                return View(category);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category model)
        {
            try
            {
                    _db.Categories.Remove(model);
                    _db.SaveChanges();
                TempData["success"]= "Data deleted successfully";
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
