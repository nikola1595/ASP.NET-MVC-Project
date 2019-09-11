using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SteamApp.Models;
using SteamApp.ViewModels;
using System.Data.Entity;

namespace SteamApp.Controllers
{
    
    public class GamesController : Controller
    {

        private ApplicationDbContext _context;


        public GamesController()
        {
            _context =  new ApplicationDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        [AllowAnonymous]
        public ViewResult Index()
        {
           
                var games = _context.Games.Include(c => c.Category).ToList();
                return View(games);

            

                        

            


          
        }

        
        public ActionResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new GameFormViewModel
            {
                Game = new Game(),
                Categories = categories
            };

            return View("GameForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Save(Game game)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel
                {
                    Game = game,
                    Categories = _context.Categories.ToList()
                };


                return View("GameForm", viewModel);
            }


            if (game.GameID == 0)
            {
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(c => c.GameID == game.GameID);

                gameInDb.Name = game.Name;
                gameInDb.GameFor = game.GameFor;
                gameInDb.GamePrice = game.GamePrice;
                gameInDb.GameYearPublished = game.GameYearPublished;
                gameInDb.CategoryID = game.CategoryID;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Games");
        }


        //Edit purchase
        
        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            var viewModel = new GameFormViewModel
            {
                Game = game,
                Categories = _context.Categories.ToList()
            };

            return View("GameForm", viewModel);
        }

        
        public ActionResult Details(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.GameID == id);

            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Game game = _context.Games.Find(id);
            return View(game);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Game game = _context.Games.Find(id);
                _context.Games.Remove(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



        /*public ActionResult Random()
        {
            var game = new Game() { Name = "Dota 2" };


            var clients = new List<Client>
            {
                new Client{Name = "Client 1"},
                new Client{Name = "Client 2"}
            };

            var viewModel = new RandomGameViewModel
            {
                Game = game,
                Clients = clients
            };


            return View(viewModel);

        }*/

        /*public ActionResult ByReleaseYear( int year, int month)
        {
            return Content(year + "/" + month);
        }
        */

    }
}