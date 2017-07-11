using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
namespace Viglacera.Controllers.Display.Left
{
    public class LeftContentController : Controller
    {
        //
        // GET: /LeftContent/
        ViglaceraContext db = new ViglaceraContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialMenuProductAll()
        {
            var ListMenu = db.tblGroupProducts.Where(p => p.ParentID==null && p.Active == true).OrderBy(p => p.Ord).ToList();
            StringBuilder chuoi = new StringBuilder();
            for (int i = 0; i < ListMenu.Count;i++ )
            {
               chuoi.Append("<li class=\"li1\">");
                chuoi.Append("<a href=\"/0/"+ListMenu[i].Tag+"-"+ListMenu[i].id+".aspx\" title=\""+ListMenu[i].Name+"\"><span></span>"+ListMenu[i].Name+"</a>");
                int idCate = ListMenu[i].id;
                var ListMenu1 = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID == idCate).OrderBy(p => p.Ord).ToList();
                if(ListMenu1.Count>0)
                {
                chuoi.Append("<ul class=\"ul2\">");
                    for(int j=0;j<ListMenu1.Count;j++)
                    {
                     chuoi.Append("<li class=\"li2\">");
                         chuoi.Append("<a href=\"/0/"+ListMenu1[j].Tag+"-"+ListMenu1[j].id+".aspx\" title=\""+ListMenu1[j].Name+"\"><span></span>" +ListMenu1[j].Name+"</a>");
                         int idcate1 = ListMenu1[j].id;
                         var ListMenu2 = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID == idcate1).OrderBy(p => p.Ord).ToList();
                        if(ListMenu2.Count>0)
                        {
                         chuoi.Append("<ul class=\"ul3\">");
                            for(int k=0;k<ListMenu2.Count;k++)
                            {
                             chuoi.Append("<li class=\"li3\">");
                                 chuoi.Append("<a href=\"/0/"+ListMenu2[k].Tag+"-"+ListMenu2[k].id+".aspx\" title=\""+ListMenu2[k].Name+"\">› "+ListMenu2[k].Name+"</a>");
                             chuoi.Append("</li> ");
                                }
                        chuoi.Append(" </ul>");
                             }
                     chuoi.Append("</li>");
                     }
                  chuoi.Append("</ul>");
                    }
          chuoi.Append("</li>");
          ViewBag.chuoiMenu = chuoi;
            } 
            return PartialView();
        }
        public PartialViewResult PartialSupport()
        {
            var listSuport = db.tblSupports.Where(p => p.Active == true).OrderBy(p => p.Ord).ToList();
            tblConfig tblconfig = db.tblConfigs.First();
            DateTime dates = DateTime.Now;
            int Date1 = int.Parse(dates.Hour.ToString());
            if (Date1 > 0 && Date1 < 7)
            {
                ViewBag.Hotline = "<span style=\"font-size:13px;font-weight:normal\">Chưa làm việc !</span>";

            }
            else if (Date1 >= 7 && Date1 < 19)
            {

                ViewBag.Hotline = tblconfig.HotlineIN;
            }


            else if (Date1 >= 19 && Date1 < 22)
            {
                ViewBag.Hotline = tblconfig.HotlineOUT;

            }
            else if (Date1 >= 22 && Date1 < 24)
            {
                ViewBag.Hotline = "<span style=\"font-size:13px;font-weight:normal\">Hết giờ làm việc !</span>";

            }
            var listlnk = db.tblUrls.Where(p => p.Active == true).OrderBy(p => p.Ord).ToList();
            StringBuilder chuoi = new StringBuilder();
            for (int i = 0; i < listlnk.Count;i++ )
            {
                chuoi.Append("<a href=\""+listlnk[i].Url+"\" title=\""+listlnk[i].Name+"\" rel=\""+listlnk[i].Rel+"\">› "+listlnk[i].Name+"</a> ");

            }
            ViewBag.url = chuoi;
                return PartialView(listSuport);
        }
        public PartialViewResult MenuProductDetail()
        {

            var ListMenu = db.tblGroupProducts.Where(p => p.ParentID==null&& p.Active == true).OrderBy(p => p.Ord).ToList();
            StringBuilder chuoi = new StringBuilder();
            for (int i = 0; i < ListMenu.Count; i++)
            {
                chuoi.Append("<li class=\"li1\">");
                chuoi.Append( "<a href=\"/0/" + ListMenu[i].Tag + "-" + ListMenu[i].id + ".aspx\" rel=\"nofollow\" title=\"" + ListMenu[i].Name + "\"><span></span>" + ListMenu[i].Name + "</a>");
                int idcate = ListMenu[i].id;
                var ListMenu1 = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID==idcate).OrderBy(p => p.Ord).ToList();
                if (ListMenu1.Count > 0)
                {
                    chuoi.Append( "<ul class=\"ul2\">");
                    for (int j = 0; j < ListMenu1.Count; j++)
                    {
                        chuoi.Append( "<li class=\"li2\">");
                        chuoi.Append( "<a href=\"/0/" + ListMenu1[j].Tag + "-" + ListMenu1[j].id + ".aspx\" rel=\"nofollow\" title=\"" + ListMenu1[j].Name + "\"><span></span>" + ListMenu1[j].Name + "</a>");
                        int idcate1 = ListMenu1[j].id;
                        var ListMenu2 = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID == idcate1).OrderBy(p => p.Ord).ToList();
                        if (ListMenu2.Count > 0)
                        {
                            chuoi.Append( "<ul class=\"ul3\">");
                            for (int k = 0; k < ListMenu2.Count; k++)
                            {
                                chuoi.Append( "<li class=\"li3\">");
                                chuoi.Append( "<a href=\"/0/" + ListMenu2[k].Tag + "-" + ListMenu2[k].id + ".aspx\" rel=\"nofollow\" title=\"" + ListMenu2[k].Name + "\">› " + ListMenu2[k].Name + "</a>");
                                chuoi.Append( "</li> ");
                            }
                            chuoi.Append( " </ul>");
                        }
                        chuoi.Append( "</li>");
                    }
                    chuoi.Append( "</ul>");
                }
                chuoi.Append( "</li>");
                ViewBag.chuoiMenu = chuoi;
            }
            return PartialView();
        }
        public PartialViewResult PartialNews()
        {
            StringBuilder Menu = new StringBuilder();
            var listManufacturers = db.tblGroupAgencies.Where(p => p.Active == true).OrderByDescending(p => p.Ord).ToList();
            var listMenuNews = db.tblGroupNews.Where(p => p.Active == true).OrderBy(p => p.Ord).ToList();
            for (int i = 0; i < listMenuNews.Count; i++ )
            {
                Menu.Append(" <li class=\"li_n\"><a href=\"/3/"+listMenuNews[i].Tag+"-"+listMenuNews[i].id+".aspx\" title=\"Liên hệ\">"+listMenuNews[i].Name+"</a></li>");

            }
            ViewBag.Menu = Menu;
                return PartialView(listManufacturers);

        }
        public PartialViewResult NewHomes()
        {
            StringBuilder chuoi = new StringBuilder();
            var listNews = db.tblNews.Where(p => p.Active == true).OrderByDescending(p => p.Ord).Take(10).ToList();
            for (int i = 0; i < listNews.Count; i++)
            {

                if (listNews[i].ViewHomes == true)
                {

                    chuoi.Append( "<a href=\"/2/"+listNews[i].Tag+"-"+listNews[i].id+".aspx\" title=\""+listNews[i].Name+"\"><span class=\"rel\"></span>"+listNews[i].Name+"</a>");
                }
                else
                {
                    chuoi.Append( "<a href=\"/2/" + listNews[i].Tag + "-" + listNews[i].id + ".aspx\" title=\""+listNews[i].Name+"\">› "+listNews[i].Name+"</a>");

                }
            }
            ViewBag.Chuoi = chuoi;
                return PartialView();
        }
    }
}
