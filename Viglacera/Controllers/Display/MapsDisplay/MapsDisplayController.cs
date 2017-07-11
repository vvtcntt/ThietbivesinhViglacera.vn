using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
namespace Viglacera.Controllers.Display.MapsDisplay
{
    public class MapsDisplayController : Controller
    {
        //
        // GET: /MapsDisplay/
        ViglaceraContext db=new ViglaceraContext();
        public ActionResult Index()
        {
            var Map = db.tblMaps.First();
            ViewBag.Title = "<title>" + Map.Name + "</title>";
            ViewBag.Description = "<meta name=\"description\" content=\"" + Map.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + Map.Name + "\" /> ";
            return View(Map);
        }

    }
}
