using MediatelExercise1.BusinessLogic;
using MediatelExercise1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MediatelExercise1.Controllers
{
    public class HomeController : Controller
    {
        public readonly int DefaultPageSize = 10;

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SearchAddress(MapRequestVM mapRequest)
        {
            try
            {
                MapSearchResultVM mapSearchResult = MapRequests.SearchForAddress(mapRequest);
                return PartialView(mapSearchResult);
            }
            catch (ValidationException e)
            {
                return PartialView("ValidationException", e);
            }
            
        }

        public ActionResult MapSearchRequestsHistory(int? page)
        {
            IList<MapSearchRequestHistoryVM> searchRequests = MapRequests.GetMapSearchRequestsHistory();
            int pageNumber = page ?? 1;
            return View(new PagedList<MapSearchRequestHistoryVM>(searchRequests, pageNumber, DefaultPageSize));
        }
    }
}