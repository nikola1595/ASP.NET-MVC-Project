using SteamApp.Models;
using SteamApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SteamApp.Controllers
{
    [Authorize(Roles = RoleName.CanManageGames)]
    public class CategoriesController : Controller
    {


        ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Edit categories
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID == id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CategoryFormViewModel
            {
                Category = category,
                
            };

            return View("CategoryForm", viewModel);
        }

       
        public ActionResult New()
        {
            

            var viewModel = new CategoryFormViewModel
            {
                Category = new Category()
                
            };

            return View("CategoryForm", viewModel);
        }


        //Create category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CategoryFormViewModel
                {
                    Category = category
                    
                };


                return View("CategoryForm", viewModel);
            }


            if (category.CategoryID == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var categoryInDb = _context.Categories.Single(c => c.CategoryID == category.CategoryID);

                categoryInDb.CategoryName = category.CategoryName;
                categoryInDb.CategoryDetails = category.CategoryDetails;
                
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }

        [Authorize]
        public ViewResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }


        public ActionResult Details(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID == id);

            if(category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Category category = _context.Categories.Find(id);
                _context.Categories.Remove(category);
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