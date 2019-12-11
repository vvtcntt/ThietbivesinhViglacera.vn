using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
namespace Viglacera.Controllers.Display
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/
        ViglaceraContext db = new ViglaceraContext();
        public ActionResult Index()
        {
            tblConfig tblconfig = db.tblConfigs.First();
            ViewBag.Title = "<title>" + tblconfig.Title + "</title>";
            ViewBag.dcTitle = "<meta name=\"DC.title\" content=\"" + tblconfig.Title + "\" />";
            ViewBag.Description = "<meta name=\"description\" content=\"" + tblconfig.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + tblconfig.Keywords + "\" /> ";
            ViewBag.canonical = "<link rel=\"canonical\" href=\"http://Thietbivesinhviglacera.vn\" />";
            string meta = "";
            meta += "<meta itemprop=\"name\" content=\"" + tblconfig.Name + "\" />";
            meta += "<meta itemprop=\"url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta itemprop=\"description\" content=\"" + tblconfig.Description + "\" />";
            meta += "<meta itemprop=\"image\" content=\"http://Thietbivesinhviglacera.vn" + tblconfig.Logo + "\" />";
            meta += "<meta property=\"og:title\" content=\"" + tblconfig.Title + "\" />";
            meta += "<meta property=\"og:type\" content=\"product\" />";
            meta += "<meta property=\"og:url\" content=\"" + Request.Url.ToString() + "\" />";
            meta += "<meta property=\"og:image\" content=\"http://Thietbivesinhviglacera.vn" + tblconfig.Logo + "\" />";
            meta += "<meta property=\"og:site_name\" content=\"http://Thietbivesinhviglacera.vn\" />";
            meta += "<meta property=\"og:description\" content=\"" + tblconfig.Description + "\" />";
            meta += "<meta property=\"fb:admins\" content=\"\" />";
            ViewBag.Meta = meta; 
            Session["h1"] = "<h1 class=\"h1\">" + tblconfig.Title + "</h1>";
            return View();
        }
        public PartialViewResult partialquangcao()
        {
            var listImage=db.tblImages.Where(p=>p.idCate==10 && p.Active==true).OrderByDescending(p=>p.Ord).Take(1).ToList();
            if(listImage.Count>0)
            ViewBag.chuoi="<a href=\""+listImage[0].Url+"\" title=\""+listImage[0].Name+"\"><img src=\""+listImage[0].Images+"\" title=\""+listImage[0].Name+"\" alt=\""+listImage[0].Name+"\" style=\"width:100%; float:left; margin:0\" /></a>";
            return PartialView();
        }

        public PartialViewResult PartialMenuMobile()
        {
            StringBuilder chuoi = new StringBuilder();
            var listMenu = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID==null).OrderBy(p => p.Ord).ToList();
            for (int i = 0; i < listMenu.Count; i++)
            {
                chuoi.Append("<li> <a href=\"/0/"+listMenu[i].Tag+"-"+listMenu[i].id+".aspx\">" + listMenu[i].Name + "</a>");
                int idcate1 = listMenu[i].id;
                var LitsMenu1 = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID == idcate1).OrderBy(p => p.Ord).ToList();
                if (LitsMenu1.Count > 0)
                {
                    chuoi.Append("<ul>");
                    for (int j = 0; j < LitsMenu1.Count; j++)
                    {
                        chuoi.Append("<li><a href=\"/0/"+LitsMenu1[j].Tag+"-"+LitsMenu1[j].id+".aspx \">" + LitsMenu1[j].Name + "</a>");

                        int idcate2 = LitsMenu1[j].id;
                        var Listmenu2 = db.tblGroupProducts.Where(p => p.Active == true &&p.ParentID==idcate2).OrderBy(p => p.Ord).ToList();
                        if (Listmenu2.Count > 0)
                        {
                            chuoi.Append(" <ul>");
                            for (int k = 0; k < Listmenu2.Count; k++)
                            {
                                chuoi.Append("<li><a href=\"/0/"+Listmenu2[k].Tag+"-"+Listmenu2[k].id+".aspx\">" + Listmenu2[k].Name + "</a></li>");
                            }
                            chuoi.Append(" </ul>");
                        }
                        chuoi.Append("</li>");
                    }
                    chuoi.Append("</ul>");
                }
                chuoi.Append("</li>");
            }
            ViewBag.chuoimenu = chuoi;
            return PartialView();
        }
        public ActionResult Search(FormCollection collection)
        {
            if (collection["btnSearch"] != null)
            {
                if (collection["txtSearch"] != "")
                {
                    string Cate = collection["drMenu"];
                    string txtSearch = collection["txtSearch"];
                    Session["idCate"] = Cate;
                    Session["txtSearch"] = txtSearch;
                    return Redirect("/SearchProduct");
                }
            }
            return View();
        }
        public PartialViewResult PartialTop()
        {
            tblConfig tblconfig = db.tblConfigs.First();
            int Date1 = int.Parse(DateTime.Now.Hour.ToString());
            

                ViewBag.Chuoihotline = "<p><span class=\"icon_Phone\"></span> : " + tblconfig.Mobile2 + "- "+tblconfig.Mobile1+"</p> <p><span class=\"icon_Hotline\"></span> : Cơ sở 1 : " + tblconfig.Hotline2 + " - Cơ sở 2 : "+tblconfig.Hotline1+"</p>";
           
            var ListSupport = db.tblSupports.Where(p => p.Active == true).OrderBy(p => p.Ord).ToList();
            StringBuilder Yahoo = new StringBuilder();
            StringBuilder Skype = new StringBuilder();
            for (int i = 0; i < ListSupport.Count;i++ )
            {
                //Yahoo
                Yahoo.Append("<div class=\"Tear_Yahoo\">");
                Yahoo.Append("<div class=\"Left_Tear_Yahoo\">");
                Yahoo.Append("<span class=\"Func\">" + ListSupport[i].Name + " :</span>");
                Yahoo.Append("</div>");
                Yahoo.Append("<div class=\"Right_Tear_Yahoo\">");
                Yahoo.Append("<a href=\"ymsgr:sendim?" + ListSupport[i].Yahoo + "\">");
                Yahoo.Append("<img src=\"http://opi.yahoo.com/online?u=" + ListSupport[i].Yahoo + "&m=g&t=1\" alt=\"Yahoo\" class=\"imgYahoo\" />");
                Yahoo.Append("</a>");
                Yahoo.Append("</div>");
                Yahoo.Append("</div> ");
                //Skype
                Skype.Append("<div class=\"Tear_Skype\">");
                Skype.Append("<div class=\"Left_Tear_Skype\">");
                Skype.Append("<span class=\"Func\">" + ListSupport[i].Name + " :</span>");

                Skype.Append("</div>");
                Skype.Append("<div class=\"Right_Tear_Skype\">");
                Skype.Append("<a href=\"Skype:" + ListSupport[i].Skyper + "?chat\">");
                Skype.Append("<img class=\"imgSkyper\" src=\"/Content/Display/iCon/skype-icon.png\" title=\"" + ListSupport[i].Name + "\" alt=\"" + ListSupport[i].Skyper + "\">");
                Skype.Append("</a>");
                Skype.Append("</div>");
                Skype.Append("</div>");

            }
            ViewBag.yahoo = Yahoo;
            ViewBag.skype = Skype;
            if (Session["h1"]!=null)
            {
                ViewBag.h1 = Session["h1"];
                Session["h1"] = null;
            }

                return PartialView(tblconfig);
        }
        public PartialViewResult PartialBanner()
        {
            tblConfig tblconfig = db.tblConfigs.First();
            return PartialView(tblconfig);
        }
        public PartialViewResult PartialMenu()
        {
            StringBuilder Menu = new StringBuilder();
            var ListMenu = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID==null).OrderBy(p => p.Ord).ToList();
            for (int i = 0; i < ListMenu.Count;i++ )
            {
                Menu.Append("  <li class=\"li_1\">");
                Menu.Append(" <a href=\"/0/"+ListMenu[i].Tag+"-"+ListMenu[i].id+".aspx\" title=\""+ListMenu[i].Name+"\" rel=\"nofollow\"> "+ListMenu[i].Name+"</a>");
                int idCate = ListMenu[i].id;
                var listMenu1 = db.tblGroupProducts.Where(p => p.ParentID==idCate && p.Active == true).OrderBy(p => p.Ord).ToList();
                if(listMenu1.Count>0)
                {
                 Menu.Append(" <ul class=\"ul_2\">");
                 for (int j = 0; j < listMenu1.Count;j++ )
                 { 
                     Menu.Append(" <li class=\"li_2\">");
                     Menu.Append(" <a href=\"/0/" + listMenu1[j].Tag + "-" + listMenu1[j].id + ".aspx\" title=\"" + listMenu1[j].Name + "\"  rel=\"nofollow\"> <span class=\"iCon\"></span>" + listMenu1[j].Name + "</a>");
                        int idCate1=listMenu1[j].id;
                         var ListMenu2 = db.tblGroupProducts.Where(p => p.Active == true && p.ParentID==idCate1).OrderBy(p => p.Ord).ToList();
                            if(ListMenu2.Count>0)
                            {
                             Menu.Append(" <ul class=\"ul_3\">");
                             for (int k = 0; k < ListMenu2.Count;k++ )
                             {
                                 Menu.Append(" <li class=\"li_3\">");
                                 Menu.Append(" <a href=\"/0/" + ListMenu2[k].Tag + "-" + ListMenu2[k].id + ".aspx\" title=\"" + ListMenu2[k].Name + "\"  rel=\"nofollow\">› " + ListMenu2[k].Name + "</a>");
                                 Menu.Append(" </li>");
                             }
                             Menu.Append(" </ul>");
                            }
                     Menu.Append(" </li>");
                 }
                 Menu.Append(" </ul>");
                }

             Menu.Append(" </li>");


            }
            ViewBag.Menu = Menu;
                return PartialView();
        }
        public PartialViewResult PartialHeader()
        {
            var listImage = db.tblImages.Where(p => p.Active == true && p.idCate == 4).OrderBy(p => p.Ord).ToList();
            StringBuilder chuoi = new StringBuilder();
            for(int i=0;i<listImage.Count;i++)
            {
                if (i == 0)
                {
                    chuoi.Append("url(" + listImage[i].Images + ") 0 0 no-repeat");
                }
                else
                    chuoi.Append(","+"url("+listImage[i].Images+") "+586*i+"px 0 no-repeat");
            }
            ViewBag.chuoi = chuoi;
            var video = db.tblVideos.Where(p => p.Active == true).OrderByDescending(p => p.Ord).Take(1).ToList();
            StringBuilder chuoivideo=new StringBuilder();
            if(video.Count>0)
            {
                if (video[0].AutoPlay == true)
                {
                    chuoivideo.Append(" <iframe width=\"100%\" height=\"242px\" src=\"http://www.youtube.com/embed/" + video[0].Code + "?;hl=en&amp;fs=1&amp;autoplay=1;loop=1;repeat=0;rel=0\" frameborder=\"0\" allowfullscreen></iframe>");
                }
                else
                {
                    chuoivideo.Append(" <iframe width=\"100%\" height=\"242px\" src=\"http://www.youtube.com/embed/" + video[0].Code + "?;hl=en&amp;fs=1&amp;autoplay=0;loop=1;repeat=0;rel=0\" frameborder=\"0\" allowfullscreen></iframe>");
                }
                ViewBag.chuoivideo = chuoivideo;
            }
           
            return PartialView(listImage);
        }
        public PartialViewResult PartialCenter_Headder()
        {
             var listimages = db.tblImages.Where(p => p.Active == true && p.idCate == 9).OrderBy(p => p.Ord).ToList();

             return PartialView(listimages);
        }
        public PartialViewResult PartialFootter()
        {
            tblConfig tblconfig = db.tblConfigs.First();   
             StringBuilder chuoipartner = new StringBuilder();
            var listPartner = db.tblPartners.Where(p => p.Active == true).OrderBy(p => p.Ord).ToList();
            for (int i = 0; i < listPartner.Count;i++ )
            { 
                 chuoipartner.Append("<h4>"+listPartner[i].Name+"</h4>");
                 chuoipartner.Append("<span class=\"Address_Company\">Địa chỉ : "+listPartner[i].Address+"</span>");
                 chuoipartner.Append("<span class=\"Mobile_Company\">Điện thoại :"+listPartner[i].Mobile+" Hotline : "+listPartner[i].Hotline+"</span>");
                 chuoipartner.Append("<span class=\"Email_Company\">Email : "+listPartner[i].Email+"</span>");
                
            }
            ViewBag.chuoipartner = chuoipartner;


            //sản phẩm chính\

            var listsanphamchinh = db.tblGroupProducts.Where(p => p.Active == true && p.Priority==true).OrderBy(p => p.Ord).ToList();
            StringBuilder sanphamchinh = new StringBuilder();
            for (int i = 0; i < listsanphamchinh.Count;i++ )
            {

                sanphamchinh.Append("<a href=\"/0/"+listsanphamchinh[i].Tag+"-"+listsanphamchinh[i].id+".aspx\" title=\""+listsanphamchinh[i].Name+"\">"+listsanphamchinh[i].Name+"</a>");
            }
            ViewBag.sanphamchinh = sanphamchinh;


            //Chính sách dịch vụ
            var listchinhsach = db.tblNews.Where(p => p.Active == true && p.idCate==16).OrderBy(p => p.Ord).ToList();
            StringBuilder chinhsach = new StringBuilder();
            for (int i = 0; i < listchinhsach.Count; i++)
            {

                chinhsach.Append("<a href=\"/2/" + listchinhsach[i].Tag + "-" + listchinhsach[i].id + ".aspx\" rel=\"nofollow\" title=\"" + listchinhsach[i].Name + "\">" + listchinhsach[i].Name + "</a>");
            }
            ViewBag.chinhsach = chinhsach;

            // Load Maps
            var map = db.tblMaps.First();
            ViewBag.maps = map.Content;
            var Imagesadw = db.tblImages.Where(p => p.Active == true && p.idCate == 11).OrderByDescending(p => p.Ord).Take(1).ToList();
            if (Imagesadw.Count > 0)
                ViewBag.Chuoiimg = "<a href=\"" + Imagesadw[0].Url + "\" title=\"" + Imagesadw[0].Name + "\"><img src=\"" + Imagesadw[0].Images + "\" alt=\"" + Imagesadw[0].Name + "\" style=\"max-width:100%;\" /> </a>";
             return PartialView(tblconfig);
        }
        public PartialViewResult Productdb()
        {
             //string level = db.tblGroupProducts.First(p => p.id == 139).Level.ToString();
            //var listMenu = db.tblGroupProducts.Where(p => p.ParentID==139 && p.Active == true).ToList();

            var listProductSyn = db.tblProductSyns.Where(p => p.Active == true).OrderBy(p => p.Ord).ToList();
            string chuoi = "";
            if (listProductSyn.Count > 0)
            {
                chuoi += "<div id=\"Product_Db\">   ";
                chuoi += "<div class=\"nVar_Product\">   ";
                chuoi += "<div class=\"Left_nVar_Product\"></div>";
                chuoi += "<div class=\"Center_nVar_Product\">   ";
                chuoi += "<span>Sản phẩm đồng bộ</span>   ";
                chuoi += "</div>   ";
                chuoi += "<div class=\"Right_nVar_Product\"></div>   ";
                chuoi += "</div>   ";
                chuoi += "<div id=\"Content_Product_Db\">   ";
                chuoi += "<div class=\"owl-carousel owl-theme\">";
                for (int i = 0; i < listProductSyn.Count; i++)
                {
                    chuoi += "<div class=\"item spdb\">";
                    chuoi += "<div class=\"sptb\"></div>";
                    chuoi += "<div class=\"img_spdb\">";
                    chuoi += "<a href=\"/syn/" + listProductSyn[i].Tag + "\" title=\"" + listProductSyn[i].Name + "\"><img src=\"" + listProductSyn[i].ImageLinkThumb + "\" alt=\"" + listProductSyn[i].Name + "\" /></a>";
                    chuoi += "</div>";
                    chuoi += "<a href=\"/syn/" + listProductSyn[i].Tag + "\" class=\"Name\" title=\"" + listProductSyn[i].Name + "\">" + listProductSyn[i].Name + "</a>";
                    chuoi += "<div class=\"Bottom_Tear_Sale\">";
                    chuoi += "<div class=\"Price\">";
                    chuoi += "<p class=\"PriceSale\">" + string.Format("{0:#,#}", listProductSyn[i].PriceSale) + " <span>đ</span></p>";
                    chuoi += " <p class=\"Price_s\">" + string.Format("{0:#,#}", listProductSyn[i].Price) + "</p>";
                    chuoi += "</div>";
                    chuoi += "</div>";
                    chuoi += "</div>";
                }

                chuoi += "</div>   ";
                chuoi += "</div>   ";
            }
            ViewBag.productdb = chuoi;
             return PartialView();
        }
        public PartialViewResult callPartial()
        {
            return PartialView(db.tblConfigs.First());
        }
        //Homes

        //Count Online
        //public JsonResult UserConnected()
        //{
        //    string ip = Request.UserHostAddress;

        //    if (MvcApplication.ConnectedtUsers.ContainsKey(ip))
        //    {
        //        MvcApplication.ConnectedtUsers[ip] = DateTime.Now;
        //    }
        //    else
        //    {
        //        MvcApplication.ConnectedtUsers.Add(ip, DateTime.Now);
        //    }

        //    int connected = MvcApplication.ConnectedtUsers.Where(c => c.Value.AddSeconds(30d) > DateTime.Now).Count();

        //    foreach (string key in MvcApplication.ConnectedtUsers.Where(c => c.Value.AddSeconds(30d) < DateTime.Now).Select(c => c.Key))
        //    {
        //        MvcApplication.ConnectedtUsers.Remove(key);
        //    }

        //    return Json(new { count = connected }, JsonRequestBehavior.AllowGet);
        //}
    }
}
