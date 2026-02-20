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
                Status = "Pending",

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


        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            var optionCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Rizwan Yousaf",
                Phone = "338595119"
            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionCust);
            var optionsCharge = new ChargeCreateOptions
            {
                Amount = Convert.ToInt64(TempData["TotalAmount"]),
                Currency = "USD",
                Description = "Pet Selling amount",
                Source = stripeToken,
                ReceiptEmail = stripeEmail

            };
            var serviceCharge = new ChargeService();
            Charge charge = serviceCharge.Create(optionsCharge);
            if (charge.Status == "succeeded")
            {
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                ViewBag.Customer = customer.Name;
            }
            return View();



        }
    }
}


