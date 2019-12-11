using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
namespace Viglacera.Controllers.Display.Session.ProductSyn
{
    public class ProductSynController : Controller
    {
        ViglaceraContext db = new ViglaceraContext();
        //
        // GET: /ProductSynDisplay/
        public ActionResult Index()
        {
            return View();
        }
        
     
        public ActionResult ProductSyn_Detail(string tag)
        {
            var tblproductSyn = db.tblProductSyns.First(p => p.Tag == tag);
            int id = int.Parse(tblproductSyn.id.ToString());
            string chuoi = "Khách hàng vui lòng kích vào chi tiết từng sản phẩm ở trên để xem thông thông số kỹ thuật !";
            ViewBag.Title = "<title>" + tblproductSyn.Title + "</title>";
            ViewBag.Description = "<meta name=\"description\" content=\"" + tblproductSyn.Description + "\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"" + tblproductSyn.Keyword + "\" /> ";
            //Load Images Liên Quan
            var listImage = db.tblImageProducts.Where(p => p.idProduct == id && p.Type==1).ToList();
            string chuoiimages = "";
            for (int i = 0; i < listImage.Count; i++)
            {
                chuoiimages += " <li class=\"Tear_pl\"><a href=\"" + listImage[i].Images + "\" rel=\"prettyPhoto[gallery1]\" title=\"" + listImage[i].Name + "\"><img src=\"" + listImage[i].Images + "\"   alt=\"" + listImage[i].Name + "\" /></a></li>";
            }
            ViewBag.chuoiimage = chuoiimages;
            int idsyn = int.Parse(tblproductSyn.id.ToString());
            //int visit = int.Parse(tblproductSyn.Visit.ToString());
            //if (visit > 0)
            //{
            //    tblproductSyn.Visit = tblproductSyn.Visit + 1;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    tblproductSyn.Visit = tblproductSyn.Visit + 1;
            //    db.SaveChanges();
            //}
            var Product = db.ProductConnects.Where(p => p.idSyn == idsyn).ToList();
            string chuoipr = "";
            string chuoisosanh = "";
            float tonggia = 0;
            if (Product.Count > 0)
            {
                chuoipr += "<div id=\"Content_spdb\">";
                chuoipr += "<span class=\"tinhnang\">&diams; Danh sách sản phẩm có trong " + tblproductSyn.Name + "</span>";
                chuoisosanh += "<div id=\"equa\">";
                chuoisosanh += "<div class=\"nVar_Equa\"><span>Bảng so sánh giá mua lẻ và mua theo bộ</span></div>";
                chuoisosanh += "<div class=\"Clear\"></div>";
                chuoisosanh += "<table width=\"200\" border=\"1\">";
                chuoisosanh += "<tr style=\"color:#333; text-transform:uppercase; line-height:25px; text-align:center\">";
                chuoisosanh += "<td style=\"width:5%;text-align:center\">STT</td>";
                chuoisosanh += "<td style=\"width:40%\">Tên Sản phẩm</td>";
                chuoisosanh += "<td style=\"width:10%;text-align:center\">Số lượng</td>";
                chuoisosanh += "<td style=\"width:20%;text-align:center\">Đơn Giá</td>";
                chuoisosanh += "<td style=\"text-align:center; width:20%\">Thành Tiền</td>";
                chuoisosanh += "</tr>";
                chuoisosanh += "</div>";
                for (int i = 0; i < Product.Count; i++)
                {
                    string codepd = Product[i].idpd;

                    var Productdetail = db.tblProducts.Where(p => p.Code == codepd && p.Active == true).Take(1).ToList();
                    if (Productdetail.Count > 0)
                    {
                        int idCate = int.Parse(Productdetail[0].idCate.ToString());
                        var ListGroup = db.tblGroupProducts.Find(idCate);
                        chuoipr += "<div class=\"Tear_syn\">";
                        chuoipr += "<div class=\"img_syn\">";
                        chuoipr += "<div class=\"nvar_Syn\">";
                        chuoipr += "<h2><a href=\"/1/" + ListGroup.Tag + "" + Productdetail[0].id + ".aspx\" title=\"" + Productdetail[0].Name + "\">" + Productdetail[0].Name + "</a></h2>";
                        chuoipr += "</div>";
                        chuoipr += "<div class=\"img_syn\">";
                        chuoipr += "<a href=\"/1/" + ListGroup.Tag + "" + Productdetail[0].id + ".aspx\" title=\"" + Productdetail[0].Name + "\"><img src=\"" + Productdetail[0].ImageLinkThumb + "\" alt=\"" + Productdetail[0].Name + "\" /></a>";
                        chuoipr += "</div>";
                        chuoipr += "</div>";
                        chuoipr += "</div>";
                        chuoisosanh += "<tr style=\"line-height:20px\">";
                        chuoisosanh += "<td style=\"width:5%;text-align:center\">" + (i + 1) + "</td>";
                        chuoisosanh += "<td style=\"width:40%; text-indent:7px\">" + Productdetail[0].Name + "</td>";
                        chuoisosanh += "<td style=\"width:10%;text-align:center\"> 1 </td>";
                        chuoisosanh += "<td style=\"width:20%;text-align:center\">" + string.Format("{0:#,#}", Productdetail[0].PriceSale) + "</td>";
                        chuoisosanh += "<td style=\"text-align:center; width:20%\">" + string.Format("{0:#,#}", Productdetail[0].PriceSale) + "</td>";
                        chuoisosanh += " </tr>";
                        tonggia = tonggia + float.Parse(Productdetail[0].PriceSale.ToString());
                    }

                }
                chuoipr += "</div>";
                chuoisosanh += "<tr style=\"line-height:25px \">";
                chuoisosanh += "<td colspan=\"4\"><span style=\"text-align:center; margin-right:5px; font-weight:bold; display:block\">TỔNG GIÁ MUA LẺ</span></td>";
                chuoisosanh += "<td style=\"font-weight:bold; font-size:16px; text-align:center\">" + string.Format("{0:#,#}", Convert.ToInt32(tonggia)) + " đ</td>";
                chuoisosanh += "</tr>";
                chuoisosanh += "<tr>";
                int sodu = Convert.ToInt32(tonggia) - int.Parse(tblproductSyn.PriceSale.ToString());

                chuoisosanh += "<td colspan=\"4\"><span style=\"text-align:center; margin-right:5px; font-weight:bold; display:block; color:#ff5400\">GIÁ MUA THEO BỘ</span></td>";
                chuoisosanh += "<td style=\"font-weight:bold; color:#ff5400; font-size:18px; font-family:UTMSwiss; text-align:center\">" + string.Format("{0:#,#}", tblproductSyn.PriceSale) + "đ<span style=\"font-style:italic; color:#333; font-size:12px; font-family:Arial, Helvetica, sans-serif; margin:5px; display:block; font-weight:normal\">Bạn đã tiết kiệm : " + string.Format("{0:#,#}", sodu) + "đ khi mua theo bộ</span></td>";
                chuoisosanh += "</tr>";
                chuoisosanh += "</table>";
            }

            ViewBag.chuoi = chuoi;
            ViewBag.chuoisosanh = chuoisosanh;
            ViewBag.chuoipr = chuoipr;
            return View(tblproductSyn);
        }
        public ActionResult list()
        {
            ViewBag.Title = "<title>Danh sách sản phẩm đồng bộ</title>";
            ViewBag.Description = "<meta name=\"description\" content=\"Danh sách sản phẩm đồng bộ\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"Danh sách sản phẩm đồng bộ\" /> ";
            StringBuilder plist = new StringBuilder();
            plist.Append("<span class=\"spanName\">Sản phẩm Caesar Đồng Bộ</span>   ");
 
            plist.Append("<div class=\"Product\">");

            plist.Append("<div class=\"Content_Product ProductSyn\">");


            var Product = db.tblProductSyns.Where(p => p.Active == true  ).OrderBy(p => p.Ord).ToList();
            for (int j = 0; j < Product.Count; j++)
            {
                plist.Append("<div class=\"Tear_2\">");
                plist.Append("<div class=\"img_thumb\">");
                plist.Append("<a href=\"/syn/" + Product[j].Tag + "\" title=\"" + Product[j].Name + "\"><img src=\"" + Product[j].ImageLinkThumb + "\" alt=\"" + Product[j].Name + "\" /></a>");
                plist.Append("</div>");
                plist.Append("<a class=\"Name\" href=\"/syn/" + Product[j].Tag + "\" title=\"" + Product[j].Name + "\">" + Product[j].Name + "</a>");
                plist.Append("<span class=\"Price\">Giá : " + string.Format("{0:#,#}", Product[j].Price) + " vnđ</span>");
                plist.Append("<p class=\"PriceSale\"><span class=\"iConKM\"></span>" + string.Format("{0:#,#}", Product[j].PriceSale) + " vnđ </p>");
                plist.Append("</div> ");

            }


            plist.Append("</div>");
            plist.Append("</div>");
            ViewBag.chuoisp = plist.ToString();
            return View();

        }

    }
}