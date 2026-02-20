using Etui.Enums;
using Etui.Helper;
using Etui.Infrastructure;
using Etui.Models;
using Etui.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using Stripe;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Etui.Controllers
{
    public class Checkout : Controller
    {
        private readonly DataContext _context;
        public Checkout(DataContext context)
        {
            _context = context;
        }


        public string TotalAmount { get; set; }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");

            if (cart == null || !cart.Any())
                return RedirectToAction("Index", "Cart");

            var total = cart.Sum(x => x.Price * x.Quantity);

            var CartViewModel = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = total
            };

            return View(CartViewModel);
        }


        [HttpPost]
        public IActionResult CreateOrder(CartViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var order = new Order
            {
                Imie = model.Dane.Imie,
                Nazwisko = model.Dane.Nazwisko,
                Email = model.Dane.Email,
                Ulica = model.Dane.Ulica,
                NrDomu = model.Dane.NrDomu,
                NrLokalu = model.Dane.NrLokalu,
                KodPocztowy = model.Dane.KodPocztowy,
                Miejscowosc = model.Dane.Miejscowosc,
                NrTelefonu = model.Dane.NrTelefonu,

                TotalAmount = model.GrandTotal,
                Status = OrderStatus.Pending,

                Items = model.CartItems.Select(c => new OrderItem
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();


            return RedirectToAction("Success");
        }


        [HttpPost]
        public IActionResult ProcessPayment(int orderId, string stripeToken)
        {
            var order = _context.Orders.Include(o => o.Items)
                                       .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
                return NotFound();

            var options = new ChargeCreateOptions
            {
                Amount = (long)(order.TotalAmount * 100),
                Currency = "usd",
                Source = stripeToken,
                Description = $"Order #{order.Id}"
            };

            var service = new ChargeService();
            var charge = service.Create(options);

            if (charge.Status == "succeeded")
            {
                order.Status = OrderStatus.Paid;
                _context.SaveChanges();

                HttpContext.Session.Remove("cart");

                return RedirectToAction("Success", new { id = order.Id });
            }

            order.Status = OrderStatus.Failed;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Success(int orderId)
        {
            var order = _context.Orders.Include(o => o.Items)
                                       .FirstOrDefault(o => o.Id == orderId);
            if (order == null) return NotFound();

            order.Status = OrderStatus.Paid;
            _context.SaveChanges();

            HttpContext.Session.Remove("cart");

            return View(order);
        }

    }
}


