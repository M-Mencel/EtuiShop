using Microsoft.AspNetCore.Mvc;
using Etui.Infrastructure;
using Etui.Models;
using Etui.Models.ViewModels;

namespace Etui.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };


            return View(cartVM);
        }
        public IActionResult Summary()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };


            return View(cartVM);
        }
        public async Task<IActionResult> Add(long id)
        {
            Product product = await _context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(long id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else if(cartItem.Quantity == 1)
            {
               cartItem.Quantity = 1; // Mozna? Mozna.
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }
/*        public async Task<IActionResult> Buy(long id)
        {

            //    ProductModel productModel = new ProductModel();

            var pet = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = await _context.Products.FindAsync(Id), Quantity = 1 });
                SessionHelper.SetObjectasJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartItem> cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
                int index = IsExist(Id);
                if (index != -1)
                {
                    cart[index].quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = await _context.Products.FindAsync(Id), Quantity = 1 });
                }
                SessionHelper.SetObjectasJson(HttpContext.Session, "cart", cart);

            }
            return RedirectToAction("Index");
        }*/

        public async Task<IActionResult> Remove(long id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}