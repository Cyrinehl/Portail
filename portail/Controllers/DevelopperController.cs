using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DataAccess.Insert;

namespace portail.Controllers
{
    public class DevelopperController : Controller
    {



        private IConfigurationRoot configuration;
        public IConfigurationRoot Configuration { get => configuration; }


        public DevelopperController(IConfigurationRoot configurationRoot)
        {
            configuration = configurationRoot;

        }

        // GET: Developper
        public ActionResult Index(string DevelopperLogin = "")
        {
            DevelopperMetrics DevelopperMetrics = null;

            if (DevelopperLogin != null)
            {
                HttpContext.Session.SetString("DevelopperLogin", DevelopperLogin);
            }

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("DevelopperLogin")) && !DevelopperLogin.Equals(""))
            {
                DevelopperMetrics = DataDevelopper.GetDevelopperMetrics(DevelopperLogin, configuration);

            }

            return View(DevelopperMetrics);
        }

        // GET: Developper/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Developper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Developper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Developper/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Developper/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Developper/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Developper/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}