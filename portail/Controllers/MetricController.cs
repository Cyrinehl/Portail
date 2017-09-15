using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Insert;
using Microsoft.Extensions.Configuration;
using Cdiscount.Export;
using System;
using System.IO;
using System.Security.Claims;

namespace portail.Controllers
{
    public class MetricController : Controller
    {

        private IConfigurationRoot configuration;
        public IConfigurationRoot Configuration { get => configuration; }


        public MetricController(IConfigurationRoot configurationRoot)
        {
            configuration = configurationRoot;
           
        }
        // GET: Metric        


        public ActionResult Index(string sortOrder = "", string searchStringDirection = "", string searchStringTeam = "", int page = 1, string searchString = "")
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


            if (searchString != null )
            {
                HttpContext.Session.SetString("CurrentFilter", searchString);
            }


            if (searchStringDirection != null)
            {
                HttpContext.Session.SetString("CurrentFilterDirection", searchStringDirection);
            }

            if (searchStringTeam != null)
            {
                HttpContext.Session.SetString("CurrentFilterTeam", searchStringTeam);
            }

            List<MetricViewModel> models = DataServiceMetrics.GetLastestMetrics(Configuration);


            if (sortOrder != null)
            {
                HttpContext.Session.SetString("SortOrder", sortOrder);
                ForSwitchCase = HttpContext.Session.GetString("SortOrder");

            }
            else
            {
                //ForSwitchCase = sortOrder;
            }

            String test = HttpContext.Session.GetString("CurrentFilter");

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentFilter")) && !searchString.Equals(""))
            {
                
                models = models.Where(s => s.ServiceName.ToLower().Contains(HttpContext.Session.GetString("CurrentFilter").ToLower())).ToList();
                                    
            }


            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentFilterDirection")) && !searchStringDirection.Equals(""))
            {

                models = models.Where(s => s.DirectionName.ToLower().Contains(HttpContext.Session.GetString("CurrentFilterDirection").ToLower())).ToList();

            }

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CurrentFilterTeam")) && !searchStringTeam.Equals(""))
            {

                models = models.Where(s => s.TeamName.ToLower().Contains(HttpContext.Session.GetString("CurrentFilterTeam").ToLower())).ToList();

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

            List<MetricViewModel> allPagebleNumbers = models.Skip((page - 1)* ElementsPerPage).Take(ElementsPerPage).ToList();
          
            return View(allPagebleNumbers);

        }

        public RedirectToActionResult GenerateExcel()
        {
            List<MetricViewModel> models = DataServiceMetrics.GetLastestMetrics(Configuration);
            //MetricViewModel MetricViewModel = new MetricViewModel();
            //MetricViewModel.ServiceName = "Service Name";
            //MetricViewModel.ServiceProfile = "Quality Profile";
            //MetricViewModel.Coverage = "Coverage";
            //MetricViewModel.Complexity = "Complexity";
            //MetricViewModel.Documentation = "Documentation";
            //MetricViewModel.Duplication = "Duplication";
            //MetricViewModel.NumberBugs = "NumberBugs";
            //MetricViewModel.NumberCodeSmells = "NumberCodeSmells";
            //MetricViewModel.NumberVulnerabilities = "NumberVulnerabilities";
            //MetricViewModel.PassedTests = "PassedTests";
            //MetricViewModel.TotalTests = "TotalTests";
            //MetricViewModel.Size = "Size";

            //models.Insert(0,MetricViewModel);

           
            GenerateFile(models.Select(r => $"{r.ServiceName};{r.ServiceProfile};{r.Coverage};{r.Complexity};{r.Documentation};{r.Duplication};{r.NumberBugs};{r.NumberCodeSmells};{r.NumberVulnerabilities};{r.PassedTests};{r.TotalTests};{r.Size}"));

            return RedirectToAction("Index");



        }

        public void GenerateFile(IEnumerable<string> lines )
        {
            try
            {
                string generalFile = Directory.GetCurrentDirectory() + "\\wwwroot\\tmp\\Export.csv";
                if (System.IO.File.Exists(generalFile))
                {
                    System.IO.File.Delete(generalFile);
                }
                else
                {
                    System.IO.File.Create(generalFile);

                }

                System.IO.File.WriteAllLines(generalFile, lines);
                HttpContext.Session.SetString("FilePath", generalFile);                

            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }


      



        // GET: Metric/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Metric/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Metric/Create
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

        // GET: Metric/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Metric/Edit/5
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

        // GET: Metric/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Metric/Delete/5
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