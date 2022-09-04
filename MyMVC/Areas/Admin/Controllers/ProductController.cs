using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;

namespace MyMVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitofwork;

        public ProductController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            ProductVM vm = new ProductVM();
            vm.products = _unitofwork.Product.GetAll();
            return View(vm);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{

        //    return View();
        //}

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.category = _unitofwork.Category.GetById(x => x.Id == id);
                if (vm.category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }

            }
            
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




        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitofwork.Category.Add(category);
        //        _unitofwork.save();
        //        TempData["Success"] = "Category Created Successfully.";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {

        //        return View(category);
        //    }
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.category.Id == 0)
                {
                    _unitofwork.Category.Add(vm.category);
                    TempData["Success"] = "Category Created Successfully.";
                }
                else
                {
                    _unitofwork.Category.Update(vm.category);
                    TempData["Success"] = "Category Updated Successfully.";

                }
                    _unitofwork.save();
                    
                    return RedirectToAction("Index");
                
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitofwork.Category.GetById(x => x.Id == id);
            if (category == null)
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
