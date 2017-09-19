using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Insert;
using Microsoft.Extensions.Configuration;

namespace portail.Controllers
{
    public class DeltaController : Controller
    {


        private IConfigurationRoot configuration;
        public IConfigurationRoot Configuration { get => configuration; }


        public DeltaController(IConfigurationRoot configurationRoot)
        {
            configuration = configurationRoot;

        }



        // GET: Delta
        public ActionResult Index(string sortOrder = "", string searchStringDirection = "", string searchStringTeam = "", int page = 1, string searchString = "", string deltaChoice = "")
        {


            float totalCount;
            double TotalPages;
            int ElementsPerPage = 30;
            string ForSwitchCase = null;

            ViewData["PageIndex"] = page;

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CoverageSortParm"] = sortOrder == "Coverage" ? "Coverage_desc" : "Coverage";
            ViewData["DirectionSortParm"] = sortOrder == "Direction" ? "Direction_desc" : "Direction";
            ViewData["TeamSortParm"] = sortOrder == "Team" ? "Team_desc" : "Team";
            ViewData["NumberLinesSortParm"] = sortOrder == "NumberLines" ? "NumberLines_desc" : "NumberLines";
            ViewData["TotalTestsSortParm"] = sortOrder == "TotalTests" ? "TotalTests_desc" : "TotalTests";
            ViewData["PassedTestsSortParm"] = sortOrder == "PassedTests" ? "PassedTests_desc" : "PassedTests";
            ViewData["BugsSortParm"] = sortOrder == "Bugs" ? "Bugs_desc" : "Bugs";
            ViewData["CodeSmellsSortParm"] = sortOrder == "CodeSmells" ? "CodeSmells_desc" : "CodeSmells";
            ViewData["VulnerabilitiesSortParm"] = sortOrder == "Vulnerabilities" ? "Vulnerabilities_desc" : "Vulnerabilities";
            ViewData["DuplicationSortParm"] = sortOrder == "Duplication" ? "Duplication_desc" : "Duplication";
            ViewData["ComplexitySortParm"] = sortOrder == "Complexity" ? "Complexity_desc" : "Complexity";
            ViewData["DocumentationSortParm"] = sortOrder == "Documentation" ? "Documentation_desc" : "Documentation";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentFilterDirection"] = searchStringDirection;
            ViewData["CurrentFilterTeam"] = searchStringTeam;


            if (searchString != null)
            {
                HttpContext.Session.SetString("CurrentFilterDelta", searchString);
            }


            if (searchStringDirection != null)
            {
                HttpContext.Session.SetString("CurrentFilterDirectionDelta", searchStringDirection);
            }

            if (searchStringTeam != null)
            {
                HttpContext.Session.SetString("CurrentFilterTeamDelta", searchStringTeam);
            }



            if (deltaChoice != null)
            {
                HttpContext.Session.SetString("deltaChoice", deltaChoice);
            }




            List<MetricViewModel> models = DataServiceMetrics.GetDeltaMetricsBox(Configuration, deltaChoice);

            


            if (sortOrder != null)
            {
                HttpContext.Session.SetString("SortOrderDelta", sortOrder);
                ForSwitchCase = HttpContext.Session.GetString("SortOrderDelta");

            }
            else
            {
                //ForSwitchCase = sortOrder;
            }

            String test = HttpContext.Session.GetString("CurrentFilterDelta");

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentFilterDelta")) && !searchString.Equals(""))
            {

                models = models.Where(s => s.ServiceName.ToLower().Contains(HttpContext.Session.GetString("CurrentFilterDelta").ToLower())).ToList();

            }


            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentFilterDirectionDelta")) && !searchStringDirection.Equals(""))
            {

                models = models.Where(s => s.DirectionName.ToLower().Contains(HttpContext.Session.GetString("CurrentFilterDirectionDelta").ToLower())).ToList();

            }

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentFilterTeamDelta")) && !searchStringTeam.Equals(""))
            {

                models = models.Where(s => s.TeamName.ToLower().Contains(HttpContext.Session.GetString("CurrentFilterTeamDelta").ToLower())).ToList();

            }




            totalCount = models.Count();
            if (totalCount <= ElementsPerPage)
            {
                TotalPages = 1;
            }
            else
            {
                TotalPages = Math.Round(totalCount / ElementsPerPage);
            }

            ViewData["TotalPages"] = Convert.ToInt32(TotalPages);




            switch (ForSwitchCase)
            {
                case "name_desc":
                    models = models.OrderBy(s => s.ServiceName).ToList();
                    break;
                case "Coverage_desc":
                    models = models.OrderByDescending(s => s.Coverage).ToList();
                    break;
                case "Direction_desc":
                    models = models.OrderByDescending(s => s.DirectionName).ToList();
                    break;
                case "Direction":
                    models = models.OrderBy(s => s.DirectionName).ToList();
                    break;
                case "Team_desc":
                    models = models.OrderByDescending(s => s.TeamName).ToList();
                    break;
                case "Team":
                    models = models.OrderBy(s => s.TeamName).ToList();
                    break;
                case "Coverage":
                    models = models.OrderBy(s => s.Coverage).ToList();
                    break;
                case "NumberLines_desc":
                    models = models.OrderByDescending(s => s.Size).ToList();
                    break;
                case "NumberLines":
                    models = models.OrderBy(s => s.Size).ToList();
                    break;
                case "TotalTests_desc":
                    models = models.OrderByDescending(s => s.TotalTests).ToList();
                    break;
                case "TotalTests":
                    models = models.OrderBy(s => s.TotalTests).ToList();
                    break;
                case "PassedTests_desc":
                    models = models.OrderByDescending(s => s.PassedTests).ToList();
                    break;
                case "PassedTests":
                    models = models.OrderBy(s => s.PassedTests).ToList();
                    break;
                case "Bugs_desc":
                    models = models.OrderByDescending(s => s.NumberBugs).ToList();
                    break;
                case "Bugs":
                    models = models.OrderBy(s => s.NumberBugs).ToList();
                    break;
                case "CodeSmells_desc":
                    models = models.OrderByDescending(s => s.NumberCodeSmells).ToList();
                    break;
                case "CodeSmells":
                    models = models.OrderBy(s => s.NumberCodeSmells).ToList();
                    break;
                case "Vulnerabilities_desc":
                    models = models.OrderByDescending(s => s.NumberVulnerabilities).ToList();
                    break;
                case "Vulnerabilities":
                    models = models.OrderBy(s => s.NumberVulnerabilities).ToList();
                    break;
                case "Duplication_desc":
                    models = models.OrderByDescending(s => s.Duplication).ToList();
                    break;
                case "Duplication":
                    models = models.OrderBy(s => s.Duplication).ToList();
                    break;
                case "Complexity_desc":
                    models = models.OrderByDescending(s => s.Complexity).ToList();
                    break;
                case "Complexity":
                    models = models.OrderBy(s => s.Complexity).ToList();
                    break;
                case "Documentation_desc":
                    models = models.OrderByDescending(s => s.Documentation).ToList();
                    break;
                case "Documentation":
                    models = models.OrderBy(s => s.Documentation).ToList();
                    break;
                default:
                    models = models.OrderBy(s => s.ServiceName).ToList();
                    break;
            }

            List<MetricViewModel> allPagebleNumbers = models.Skip((page - 1) * ElementsPerPage).Take(ElementsPerPage).ToList();

            foreach (MetricViewModel MetricViewModel in allPagebleNumbers)
            {
                MetricViewModel.ServiceName = MetricViewModel.ServiceName.Replace(" Dev", "");
            }

            return View(allPagebleNumbers);


        }


        // GET: Delta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Delta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Delta/Create
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

        // GET: Delta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Delta/Edit/5
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

        // GET: Delta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Delta/Delete/5
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