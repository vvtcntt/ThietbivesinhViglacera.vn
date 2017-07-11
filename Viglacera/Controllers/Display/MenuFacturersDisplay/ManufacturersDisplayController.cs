using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
using PagedList;
using PagedList.Mvc;
namespace Viglacera.Controllers.Display.MenuFacturersDisplay
{
    public class ManufacturersDisplayController : Controller
    {
        //
        // GET: /ManufacturersDisplay/
        ViglaceraContext db = new ViglaceraContext();
        public ActionResult Index( )
        {
            return View();
         }
        public ActionResult ListMenufacturers(int? page,string tag)
        {
            var ListManFacturers = db.tblAgencies.Where(p => p.Active == true).OrderByDescending(p => p.Ord).ToList();
            ViewBag.Name = "Hệ thống phân phối";
            ViewBag.Title = "<title>Hệ thống phân phối Viglacera</title>";
            ViewBag.Description = "<meta name=\"description\" content=\"Hệ thống phân phối chính hãng sản phẩm thiết bị vệ sinh Viglacera trên toàn quốc. Địa chỉ : 391 - Nguyễn Xiển - Thanh Xuân - HN\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"Hệ thống phân phối thiết bị vệ sinh Viglacera\" /> ";
            if (tag != "" && tag != null)
            {
                int idMenu;
                string Chuoi = tag;
                string[] Mang = Chuoi.Split('-');
                int one = int.Parse(Mang.Length.ToString());
                string chuoi1 = Mang[one - 1].ToString();
                string[] Mang1 = chuoi1.Split('.');
                idMenu = int.Parse(Mang1[0].ToString());
                tblGroupAgency groupnew = db.tblGroupAgencies.Find(idMenu);
                ViewBag.Name = groupnew.Name;
                ViewBag.Title = "<title>" + groupnew.Name + "</title>";
                ViewBag.Description = "<meta name=\"description\" content=\"" + groupnew.Description + "\"/>";
                ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + groupnew.Name + "\" /> ";
                  ListManFacturers = db.tblAgencies.Where(p => p.Active == true && p.idMenu==idMenu).OrderByDescending(p => p.Ord).ToList();
            }
            
            const int pageSize = 10;
            var pageNumber = (page ?? 1);
            // Thiết lập phân trang
            var ship = new PagedListRenderOptions
            {
                DisplayLinkToFirstPage = PagedListDisplayMode.Always,
                DisplayLinkToLastPage = PagedListDisplayMode.Always,
                DisplayLinkToPreviousPage = PagedListDisplayMode.Always,
                DisplayLinkToNextPage = PagedListDisplayMode.Always,
                DisplayLinkToIndividualPages = true,
                DisplayPageCountAndCurrentLocation = false,
                MaximumPageNumbersToDisplay = 5,
                DisplayEllipsesWhenNotShowingAllPageNumbers = true,
                EllipsesFormat = "&#8230;",
                LinkToFirstPageFormat = "Trang đầu",
                LinkToPreviousPageFormat = "«",
                LinkToIndividualPageFormat = "{0}",
                LinkToNextPageFormat = "»",
                LinkToLastPageFormat = "Trang cuối",
                PageCountAndCurrentLocationFormat = "Page {0} of {1}.",
                ItemSliceAndTotalFormat = "Showing items {0} through {1} of {2}.",
                FunctionToDisplayEachPageNumber = null,
                ClassToApplyToFirstListItemInPager = null,
                ClassToApplyToLastListItemInPager = null,
                ContainerDivClasses = new[] { "pagination-container" },
                UlElementClasses = new[] { "pagination" },
                LiElementClasses = Enumerable.Empty<string>()
            };
            ViewBag.ship = ship;
           
            return View(ListManFacturers.ToPagedList(pageNumber, pageSize));
         }
        public ActionResult ManufacturersDetail(string tag)
        {
            int idNew;
            string Chuoi = tag;
            string[] Mang = Chuoi.Split('-');
            int one = int.Parse(Mang.Length.ToString());
            string chuoi1 = Mang[one - 1].ToString();
            string[] Mang1 = chuoi1.Split('.');
            idNew = int.Parse(Mang1[0].ToString());
            tblAgency tblmanufacturers = db.tblAgencies.Find(idNew);
            string chuoinew = "";
            var listnew = db.tblAgencies.Where(p => p.id != tblmanufacturers.id && p.Active == true).OrderByDescending(p => p.Ord).Take(3).ToList();
            for (int i = 0; i < listnew.Count; i++)
            {
                chuoinew += "<a href=\"/4/" + listnew[i].Tag + "-" + listnew[i].id + ".aspx\" title=\"" + listnew[i].Name + "\"> - " + listnew[i].Name + "</a>";
            }
            ViewBag.chuoinew = chuoinew;
            ViewBag.Title = "<title>" + tblmanufacturers.Name + "</title>";
            ViewBag.Description = "<meta name=\"description\" content=\"" + tblmanufacturers.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + tblmanufacturers.Name + "\" /> ";
            //var GroupManufacturer = db.tblGroupAgencies.First(p => p.id == tblmanufacturers.idMenu);
            //int dodai = GroupManufacturer.Level.Length / 5;
            //string nUrl = "";
            //for (int i = 0; i < dodai; i++)
            //{
            //    var NameGroups = db.tblGroupAgencies.First(p => p.Level.Substring(0, (i + 1) * 5) == GroupManufacturer.Level.Substring(0, (i + 1) * 5));
            //    nUrl = nUrl + " <a href=\"/9/" + NameGroups.Tag + " -" + NameGroups.id + ".aspx\" title=\"\"> " + " " + NameGroups.Name + "</a> /";
            //}
            ViewBag.nUrl = "<a href=\"/\" title=\"Trang chu\" rel=\"nofollow\"><span class=\"iCon\"></span>Trang chủ</a> / Hệ thống phân phối ";
            return View(tblmanufacturers);
        }
    }
}
