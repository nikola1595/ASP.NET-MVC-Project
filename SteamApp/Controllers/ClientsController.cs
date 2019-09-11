using SteamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SteamApp.ViewModels;

namespace SteamApp.Controllers
{
    
    public class ClientsController : Controller
    {

        //Create client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Client client)
        {

            if(!ModelState.IsValid)
            {
                var viewModel = new ClientFormViewModel
                {
                    Client = client,
                    ConsoleTypes = _context.ConsoleTypes.ToList()
                };


                return View("ClientForm", viewModel);
            }


            if(client.ClientID == 0 )
            {
                _context.Clients.Add(client);
            }
            else
            {
                var clientInDb = _context.Clients.Single(c => c.ClientID == client.ClientID);

                clientInDb.Name = client.Name;
                clientInDb.IsSubscribedOnSteam = client.IsSubscribedOnSteam;
                clientInDb.ConsoleTypeID = client.ConsoleTypeID;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index","Clients");
        }
        
        //Edit client
        public ActionResult Edit(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.ClientID == id);
            if(client == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ClientFormViewModel
            {
                Client = client,
                ConsoleTypes = _context.ConsoleTypes.ToList()
            };

            return View("ClientForm", viewModel);
        }


       [HttpGet]
       public ActionResult Delete(int id)
       {
            Client client = _context.Clients.Find(id);
            return View(client);
       }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if(ModelState.IsValid)
            {
                Client client = _context.Clients.Find(id);
                _context.Clients.Remove(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



        
        [Authorize(Roles = RoleName.CanManageGames)]
        public ViewResult New()
        {
            var consoleTypes = _context.ConsoleTypes.ToList();

            var viewModel = new ClientFormViewModel
            {
                Client = new Client(),
                ConsoleTypes = consoleTypes
            };

            return View("ClientForm",viewModel);
        }


        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageGames))
            {
                return View("List");
            }
            return View("ReadOnlyList");
            
        }



        public ActionResult Details(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.ClientID == id);

            if(client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        
    }
}