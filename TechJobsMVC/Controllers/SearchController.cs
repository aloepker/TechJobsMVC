using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        private List<Job> jobs;
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }
        // TODO #3: Create an action method to process a search request and render the updated search view. 
       //2) The Results method should take in two parameters, specifying the type of search and the search term.
       //3) In order for these parameters to be properly passed in by ASP.NET, you need to name them appropriately, based on the corresponding form field names defined in Search/Index.
       //4) If the user leaves the search box empty, call the FindAll() method from JobData. Otherwise, send the search information to FindByColumnAndValue. Store the results in a jobs list.
       //5) Pass jobs into the Search/Index view via ViewBag.
       //6) Pass ListController.ColumnChoices into the view, as the existing search handler does
        public IActionResult Results(string searchType, string searchTerm)
       {
            if (string.IsNullOrEmpty(searchTerm))
            { ViewBag.Jobs = JobData.FindAll(); }
            else
            { ViewBag.Jobs = JobData.FindByColumnAndValue(searchType, searchTerm); }
            ViewBag.columns = ListController.ColumnChoices;
            return View("Index");
        }
    }
}