namespace LimerickStreetArt.Web.Controllers
{
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    using LimerickStreetArt.MySQL;
    using LimerickStreetArt.Repository;
    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class StreetArtControlle : Controller
    {
        private readonly StreetArtRepository streetArtRepository;
        public StreetArtControlle(IConfiguration configuration, StreetArtRepositoryClass StreetArtRepository)
        {
            var databaseClass = new DatabaseClass
            {
                ConnectionString = configuration.GetConnectionString("LocalDatabase"),
            };
            StreetArtRepository = new StreetArtRepositoryClass(databaseClass);
        }
        // GET: StreetArt
        public ActionResult Index()
        {
            return View();
        }

        // GET: StreetArt/Details/5
        public ActionResult Details(int id)
        {
            StreetArt streetArt = streetArtRepository.GetById(id);
            return View(streetArt);
        }

        // GET: StreetArt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StreetArt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StreetArt/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StreetArt/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StreetArt/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StreetArt/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}