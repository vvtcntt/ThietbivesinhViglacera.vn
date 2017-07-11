using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
using PagedList;
using PagedList.Mvc;
namespace Viglacera.Controllers.Display.News
{
    public class NewsController : Controller
    {
        //
        // GET: /News/
        ViglaceraContext db = new ViglaceraContext();
        public ActionResult Index()
        {
            return View();
        }
        string nUrl = "";
        public string UrlNews(int idCate)
        {
            var ListMenu = db.tblGroupNews.Where(p => p.id == idCate).ToList();
            for (int i = 0; i < ListMenu.Count; i++)
            {
                nUrl = " <a href=\"/3/" + ListMenu[i].Tag + "-"+ListMenu[i].id+".aspx\" title=\"" + ListMenu[i].Name + "\"> " + " " + ListMenu[i].Name + "</a> <i></i>" + nUrl;
                string ids = ListMenu[i].ParentID.ToString();
                if (ids != null && ids != "")
                {
                    int id = int.Parse(ListMenu[i].ParentID.ToString());
                    UrlNews(id);
                }

            }
            return nUrl;
        }
        public ActionResult ListNews(int? page, string id,string tag)
        {
            int idMenu;
            string Chuoi = tag;
            string[] Mang = Chuoi.Split('-');
            int one = int.Parse(Mang.Length.ToString());
            string chuoi1 = Mang[one - 1].ToString();
            string[] Mang1 = chuoi1.Split('.');
            idMenu = int.Parse(Mang1[0].ToString());
            tblGroupNew groupnew = db.tblGroupNews.Find(idMenu);
            var ListNew = db.tblNews.Where(p => p.Active == true && p.idCate == idMenu).OrderByDescending(p => p.Ord).ToList();
            ViewBag.Name = groupnew.Name;
            ViewBag.Title = "<title>" + groupnew.Title + "</title>";
            ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + groupnew.Title + "\" />";
            ViewBag.Description = "<meta name=\"description\" content=\"" + groupnew.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + groupnew.Keyword + "\" /> ";
            ViewBag.canonical = "<link rel=\"canonical\" href=\"http://Thietbivesinhviglacera.vn/3/" + groupnew.Tag + "-" + groupnew.id + ".aspx\" />";
            string meta = "";
            meta += "<meta itemprop=\"name\" content=\"" + groupnew.Name + "\" />";
            meta += "<meta itemprop=\"url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta itemprop=\"description\" content=\"" + groupnew.Description + "\" />";
            meta += "<meta itemprop=\"image\" content=\"http://Thietbivesinhviglacera.vn" + groupnew.Images + "\" />";
            meta += "<meta property=\"og:title\" content=\"" + groupnew.Title + "\" />";
            meta += "<meta property=\"og:type\" content=\"product\" />";
            meta += "<meta property=\"og:url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta property=\"og:image\" content=\"http://Thietbivesinhviglacera.vn" + groupnew.Images + "\" />";
            meta += "<meta property=\"og:site_name\" content=\"http://Thietbivesinhviglacera.vn\" />";
            meta += "<meta property=\"og:description\" content=\"" + groupnew.Description + "\" />";
            meta += "<meta property=\"fb:admins\" content=\"\" />";
            ViewBag.Meta = meta; 
            ViewBag.nUrl = "<a href=\"/\" title=\"Trang chu\" rel=\"nofollow\"><span class=\"iCon\"></span>Trang chủ</a> /" + UrlNews(idMenu);
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
            return View(ListNew.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult NewsDetail(string tag)
        {

            int idNew;
            string Chuoi = tag;
            string[] Mang = Chuoi.Split('-');
            int one = int.Parse(Mang.Length.ToString());
            string chuoi1 = Mang[one - 1].ToString();
            string[] Mang1 = chuoi1.Split('.');
            idNew = int.Parse(Mang1[0].ToString());
            tblNew tblnew = db.tblNews.Find(idNew);
            string chuoinew = "";
            var listnew = db.tblNews.Where(p => p.idCate == tblnew.idCate && p.id != tblnew.id && p.Active == true).OrderByDescending(p => p.Ord).Take(3).ToList();
            for (int i = 0; i < listnew.Count; i++)
            {
                chuoinew += "<a href=\"/2/" + listnew[i].Tag + "-" + listnew[i].id + ".aspx\" title=\"" + listnew[i].Name + "\"> - " + listnew[i].Name + "</a>";


            }
            ViewBag.chuoinew = chuoinew;
            ViewBag.Title = "<title>" + tblnew.Title + "</title>";
            ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + tblnew.Title + "\" />";
            ViewBag.Description = "<meta name=\"description\" content=\"" + tblnew.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + tblnew.Keyword + "\" /> ";
            ViewBag.canonical = "<link rel=\"canonical\" href=\"http://Thietbivesinhviglacera.vn/2/" + tblnew.Tag + "-" + tblnew.id + ".aspx\" />";
            string meta = "";
            meta += "<meta itemprop=\"name\" content=\"" + tblnew.Name + "\" />";
            meta += "<meta itemprop=\"url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta itemprop=\"description\" content=\"" + tblnew.Description + "\" />";
            meta += "<meta itemprop=\"image\" content=\"http://Thietbivesinhviglacera.vn" + tblnew.Images + "\" />";
            meta += "<meta property=\"og:title\" content=\"" + tblnew.Title + "\" />";
            meta += "<meta property=\"og:type\" content=\"product\" />";
            meta += "<meta property=\"og:url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta property=\"og:image\" content=\"http://Thietbivesinhviglacera.vn" + tblnew.Images + "\" />";
            meta += "<meta property=\"og:site_name\" content=\"http://Thietbivesinhviglacera.vn\" />";
            meta += "<meta property=\"og:description\" content=\"" + tblnew.Description + "\" />";
            meta += "<meta property=\"fb:admins\" content=\"\" />";
            ViewBag.Meta = meta; 
            var Groupnews = db.tblGroupNews.First(p => p.id == tblnew.idCate);
            int idcate = Groupnews.id;
            ViewBag.nUrl = "<a href=\"/\" title=\"Trang chu\" rel=\"nofollow\"><span class=\"iCon\"></span>Trang chủ</a> / "+ UrlNews(idcate);
            tblConfig tblconfig = db.tblConfigs.FirstOrDefault();
            if (tblconfig.Coppy == true)
            {
                ViewBag.coppy = " <script src=\"/Scripts/disable-copyright.js\"></script> <link href=\"/Content/Display/Css/Coppy.css\" rel=\"stylesheet\" />";
            }
            return View(tblnew);
        }
    }
}