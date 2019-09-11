using SteamApp.Models;
using SteamApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamApp.Controllers
{
    [Authorize(Roles =RoleName.CanManageGames)]
    public class PurchasesController : Controller
    {
        public ActionResult Index()
        {
            var purchases = _context.Purchases.ToList();

            return View(purchases);
        }
       
        ApplicationDbContext _context;

        public PurchasesController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult New()
        {
            var paymentMethods = _context.PaymentMethods.ToList();

            var clients = _context.Clients.ToList();

            var games = _context.Games.ToList();

            var viewModel = new PurchaseFormViewModel
            {
                Clients = clients,
                Games = games,
                PaymentMethods = paymentMethods
            };

            return View("PurchaseForm", viewModel);
        }


        public ActionResult Edit(int id)
        {
            var purchase = _context.Purchases.SingleOrDefault(c => c.PurchaseID == id);

            if(purchase == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PurchaseFormViewModel(purchase)
            {
                Clients = _context.Clients.ToList(),
                Games = _context.Games.ToList(),
                PaymentMethods = _context.PaymentMethods.ToList()
            };

            return View("PurchaseForm", viewModel);
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Purchase purchase)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new PurchaseFormViewModel
                {
                    Clients = _context.Clients.ToList(),
                    Games = _context.Games.ToList(),
                    PaymentMethods = _context.PaymentMethods.ToList()
                };


                return View("PurchaseForm", viewModel);
            }


            if (purchase.PurchaseID == 0)
            {
                purchase.DateOfPurchase = DateTime.Now;
                _context.Purchases.Add(purchase);
            }
            else
            {
                var purchaseInDb = _context.Purchases.Single(c => c.PurchaseID == purchase.PurchaseID);
                

                purchaseInDb.ClientID = purchase.ClientID;
                purchaseInDb.GameID = purchase.GameID;
                purchaseInDb.PaymentMethodID = purchase.PaymentMethodID;
                
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Purchases");
        }

        

        public ActionResult Details(int id)
        {
            var purchase = _context.Purchases.SingleOrDefault(m => m.PurchaseID == id);

            if(purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Purchase purchase = _context.Purchases.Find(id);
            return View(purchase);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Purchase purchase = _context.Purchases.Find(id);
                _context.Purchases.Remove(purchase);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}