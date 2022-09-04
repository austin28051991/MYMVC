using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;

namespace MyMVC.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitofwork;
        
        public CategoryController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories= _unitofwork.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var category = _unitofwork.Category.GetById(x=>x.Id==id);
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitofwork.Category.GetById(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            { 
            _unitofwork.Category.Add(category);
            _unitofwork.save();
                TempData["Success"] = "Category Created Successfully.";
            return RedirectToAction("Index");
            }
            else
            {

                return View(category);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.Category.Update(category);
                _unitofwork.save();
                TempData["Success"] = "Category Updated Successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitofwork.Category.GetById(x => x.Id == id);
            if (category==null)
            {
                return NotFound();
            }
            _unitofwork.Category.Delete(category);
            _unitofwork.save();
            TempData["Success"] = "Category Deleted Successfully.";
            return RedirectToAction("Index");
            
        }


    }
}
