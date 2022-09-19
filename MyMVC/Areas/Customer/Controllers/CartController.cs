using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.DataAccessLayer.Infrastructure.Repository;
using MyApp.Models;
using MyApp.Models.ViewModels;
using System.Security.Claims;

namespace MyMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
       
        private IUnitOfWork _unitofwork;
        public CartVM vm { get; set; }
       
        public CartController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

             vm = new CartVM()
            {
                ListofCart = _unitofwork.Cart.GetAll(x => x.ApplicationUserId == claims.Value,includeProperties: "Product")
            };
            foreach(var item in vm.ListofCart)
            {
                vm.Total = vm.Total + (item.Product.Price * item.Count);
            }
            return View(vm);
        }
       
        public IActionResult plus(int id)
        {
            var cart = _unitofwork.Cart.GetById(x => x.Id == id);
            _unitofwork.Cart.IncreamentCartItem(cart,1);
            _unitofwork.save();
            return RedirectToAction(nameof(Index));

        }
       
        public IActionResult minus(int id)
        {
            var cart = _unitofwork.Cart.GetById(x => x.Id == id);
            if(cart.Count==1)
            {
                _unitofwork.Cart.Delete(cart);
            }
            else
            {
                _unitofwork.Cart.DecreamentCartItem(cart, 1);
            }
            
            _unitofwork.save();
            return RedirectToAction(nameof(Index));

        }
        
        public IActionResult delete(int id)
        {
            var cart = _unitofwork.Cart.GetById(x => x.Id == id);
           
            _unitofwork.Cart.Delete(cart);
           
            _unitofwork.save();
            return RedirectToAction(nameof(Index));

        }

    }
}
