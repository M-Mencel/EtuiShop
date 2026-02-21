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
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");

            if (cart == null || !cart.Any())
                return RedirectToAction("Index", "Cart");

            var total = cart.Sum(x => x.Price * x.Quantity);

            var CartViewModel = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = total,
                Dane = new Dane()
            };

            return View(CartViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(CartViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "Cart");

            if (cart == null || !cart.Any())
                return RedirectToAction("Index", "Cart");

            var total = cart.Sum(x => x.Price * x.Quantity);

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

                TotalAmount = total,
                Status = OrderStatus.Pending,

                Items = cart.Select(c => new OrderItem
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("Success", new { orderId = order.Id });
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

                HttpContext.Session.Remove("Cart");

                return RedirectToAction("Success", new { id = order.Id });
            }

            order.Status = OrderStatus.Failed;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Success(int orderId)
        {
            var order = _context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(o => o.Id == orderId);

            if (order == null)
                return NotFound();

            return View(order);
        }

        public IActionResult Payment(int orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderId);

            if (order == null)
                return NotFound();

            return View(order);
        }

        public IActionResult Processing(string stripeToken, string stripeEmail) 
        { 
            var optionCust = new CustomerCreateOptions { Email = stripeEmail, Name = "Rizwan Yousaf", Phone = "338595119" }; 
            var serviceCust = new CustomerService(); 
            Customer customer = serviceCust.Create(optionCust); 
            var optionsCharge = new ChargeCreateOptions { Amount = Convert.ToInt64(TempData["TotalAmount"]), Currency = "USD", Description = "Pet Selling amount", Source = stripeToken, ReceiptEmail = stripeEmail }; 
            var serviceCharge = new ChargeService(); Charge charge = serviceCharge.Create(optionsCharge); 
            if (charge.Status == "succeeded") 
            { 
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100; ViewBag.Customer = customer.Name; } 
            return View(); 
        }
    }
}
    



