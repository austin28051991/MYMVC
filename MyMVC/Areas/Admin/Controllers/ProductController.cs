using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace MyMVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitofwork;
        private IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitofwork, IWebHostEnvironment webHostEnvironment = null)
        {
            _unitofwork = unitofwork;
            _webHostEnvironment = webHostEnvironment;
        }


        #region APICALL
        public IActionResult AllProducts()
        {
            var products = _unitofwork.Product.GetAll(includeProperties: "category");
            return Json(new { data = products });

        }

        #endregion
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
            ProductVM vm = new ProductVM()
            {
                product = new(),
                Categories = _unitofwork.Category.GetAll().Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }
                )
            };
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.product = _unitofwork.Product.GetById(x => x.Id == id);
                if (vm.product == null)
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
        public IActionResult CreateUpdate(ProductVM vm,IFormFile file)
        {
            string FileName = "";
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string uploaddir = Path.Combine(_webHostEnvironment.WebRootPath, "ProductImage");
                    FileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filepath = Path.Combine(uploaddir, FileName);

                    if (vm.product.ImageUrl!=null)
                    {
                        var oldpath = Path.Combine(_webHostEnvironment.WebRootPath, vm.product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldpath))
                        {
                            System.IO.File.Delete(oldpath);
                        }
                    }


                    using (var fileStream = new FileStream(filepath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    vm.product.ImageUrl = @"\ProductImage\" + FileName;
                }
                if(vm.product.Id==0)
                {
                    _unitofwork.Product.Add(vm.product);
                    TempData["success"] = "Product Created";
                }
                else
                {
                    _unitofwork.Product.Update(vm.product);
                    TempData["success"] = "Product Updated";
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
