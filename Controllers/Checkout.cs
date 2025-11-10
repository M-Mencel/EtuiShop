using Etui.Helper;
using Etui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Etui.Controllers
{
    public class Checkout : Controller
    {

            [TempData]
        public string TotalAmount { get; set; }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            if (cart != null && cart.Count() > 0)
            {
                ViewBag.DollarAmount = cart.Sum(item => item.Price * item.Quantity);
                ViewBag.total = Math.Round(ViewBag.DollarAmount, 2) * 100;
                ViewBag.total = Convert.ToInt64(ViewBag.total);
                long total = ViewBag.total;
                TotalAmount = total.ToString();
            }




            //TempData["TotalAmount"] = TotalAmount;
            return View();
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


