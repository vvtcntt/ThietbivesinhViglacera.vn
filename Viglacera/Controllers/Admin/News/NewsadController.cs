using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
using PagedList;
using PagedList.Mvc;
using System.Globalization;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Data.Entity;
namespace Viglacera.Controllers.Admin.News
{
    public class NewsadController : Controller
    {

        private ViglaceraContext db = new ViglaceraContext();
        List<SelectListItem> carlist = new List<SelectListItem>();
        List<SelectListItem> carlistProduct = new List<SelectListItem>();
       
        public ActionResult Index(int? page, string text, string idCate, string pageSizes, FormCollection collection)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            if (ClsCheckRole.CheckQuyen(5, 0, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                #region[Load Menu]

                var pro = db.tblGroupNews.OrderByDescending(p => p.Ord).Take(1).ToList();
                var menuModel = db.tblGroupNews.Where(m => m.ParentID == null).OrderBy(m => m.id).ToList(); carlist.Clear();
                string strReturn = "---";
                foreach (var item in menuModel)
                {
                    carlist.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });
                    StringClass.DropDownListNews(item.id, carlist, strReturn);
                    strReturn = "---";
                }
                if (idCate != "")
                {
                    ViewBag.drMenu = new SelectList(carlist, "Value", "Text", idCate);
                    ViewBag.idCate = idCate;
                    ViewBag.idMenu = idCate;
                }
                else
                {
                    ViewBag.drMenu = carlist;
                }
                #endregion
                if (Session["Thongbao"] != null && Session["Thongbao"] != "")
                {

                    ViewBag.thongbao = Session["Thongbao"].ToString();
                    Session["Thongbao"] = "";
                }
                if (collection["btnDelete"] != null)
                {
                    foreach (string key in Request.Form.Keys)
                    {
                        var checkbox = "";
                        if (key.StartsWith("chk_"))
                        {
                            checkbox = Request.Form["" + key];
                            if (checkbox != "false")
                            {
                                if (ClsCheckRole.CheckQuyen(5, 3, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
                                {
                                    int id = Convert.ToInt32(key.Remove(0, 4));
                                    tblNew tblnews = db.tblNews.Find(id);
                                    int ord = int.Parse(tblnews.Ord.ToString());
                                    int idCates = int.Parse(tblnews.idCate.ToString());
                                    var kiemtra = db.tblNews.Where(p => p.Ord > ord && p.idCate == idCates).ToList();
                                    if (kiemtra.Count > 0)
                                    {
                                        var ListNews = db.tblNews.Where(p => p.Ord > ord && p.idCate == idCates).ToList();
                                        for (int i = 0; i < ListNews.Count; i++)
                                        {
                                            int idp = int.Parse(ListNews[i].id.ToString());
                                            var NewsUpdate = db.tblNews.Find(idp);
                                            NewsUpdate.Ord = NewsUpdate.Ord - 1;
                                            db.SaveChanges();
                                        }
                                    }
                                    db.tblNews.Remove(tblnews);
                                    db.SaveChanges();
                                    clsSitemap.DeteleSitemap(id.ToString(), "News");

                                }
                                else
                                {
                                    return Redirect("/Users/Erro");

                                }
                            }
                        }
                    }
                    //dsd
                }
                return View();
            }
            else
            {
                return Redirect("/Users/Erro");

            }
        }
       
        public PartialViewResult PartialNews(int? page, string text, string idCate, string pageSizes)
        {
            var ListNews = db.tblNews.OrderByDescending(p => p.DateCreate).ToList();
            int pageSize = 20;
            var pageNumber = (page ?? 1);
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


            if (Request.IsAjaxRequest())
            {
                int idCatelogy;
                if (pageSizes != null)
                {
                    ViewBag.pageSizes = pageSizes;
                    pageSize = int.Parse(pageSizes.ToString());
                    ViewBag.chuoicout = "<span style='color: #A52A2A;'>" + pageSize + "</span> / <span style='color: #333;'>" + ListNews.Count.ToString() + "</span>";
                    return PartialView("PartialNews", ListNews.ToPagedList(pageNumber, pageSize));

                }
                if (text != null && text != "")
                {
                    ListNews = db.tblNews.Where(p => p.Name.ToUpper().Contains(text.ToUpper()) && p.Active == true).OrderByDescending(p => p.DateCreate).ToList();
                    ViewBag.chuoicout = "<span style='color: #A52A2A;'>" + ListNews.Count + "</span> ";

                    return PartialView("PartialNews", ListNews.ToPagedList(pageNumber, pageSize));
                }
                if (idCate != null && idCate != "")
                {
                    idCatelogy = int.Parse(idCate);
                    ListNews = db.tblNews.Where(p => p.idCate == idCatelogy).OrderByDescending(p => p.DateCreate).ToList();
                    ViewBag.chuoicout = "<span style='color: #A52A2A;'>" + ListNews.Count + "</span> ";
                    ViewBag.idMenu = idCate;
                    return PartialView("PartialNews", ListNews.ToPagedList(pageNumber, pageSize));
                }
                if (text != null && text != "" && idCate != null && idCate != "")
                {
                    idCatelogy = int.Parse(idCate);
                    ViewBag.idMenu = idCate;
                    ViewBag.chuoicout = "<span style='color: #A52A2A;'>" + ListNews.Count + "</span> ";
                    ListNews = db.tblNews.Where(p => p.Name.ToUpper().Contains(text.ToUpper()) && p.idCate == (int.Parse(idCate)) && p.Active == true).OrderByDescending(p => p.Ord).ToList();
                    return PartialView("PartialNews", ListNews);
                }
                else
                {
                    ListNews = db.tblNews.OrderByDescending(p => p.Ord).ToList();

                }

            }

            if (pageSizes != null)
            {
                ViewBag.pageSizes = pageSizes;
                pageSize = int.Parse(pageSizes.ToString());

            }
            ViewBag.chuoicout = "<span style='color: #A52A2A;'>" + pageSize + "</span> / <span style='color: #333;'>" + ListNews.Count.ToString() + "</span>";
            

             var menuModel = db.tblGroupNews.Where(m => m.ParentID == null).OrderBy(m => m.id).ToList();
            carlist.Clear();
            string strReturn = "---";
            foreach (var item in menuModel)
            {
                carlist.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });
                StringClass.DropDownListNews(item.id, carlist, strReturn);
                strReturn = "---";
            }
            if (idCate != null)
            {

                int idcates = int.Parse(idCate);
                ListNews = db.tblNews.Where(p => p.idCate == idcates && p.Active == true).OrderByDescending(p => p.DateCreate).ToList();
                ViewBag.idMenu = idCate;
                ViewBag.idcate = idCate;
                ViewBag.ddlMenu = carlist;
                return PartialView(ListNews.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.ddlMenu = carlist;
            }
            return PartialView(ListNews.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult UpdateNews(string idnews, string cbIsActive, string chkHome, string ordernumber, string idCate)
        {
            if (ClsCheckRole.CheckQuyen(5, 2, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                int id = int.Parse(idnews);
                var News = db.tblNews.Find(id);

                News.ViewHomes = bool.Parse(chkHome);
                News.Active = bool.Parse(cbIsActive);
                News.idCate = int.Parse(idCate);
                int Ord = int.Parse(ordernumber);
                News.Ord = Ord;
                int idCates = int.Parse(idCate);
                 var Kiemtra = db.tblNews.Where(p => p.Ord == Ord && p.idCate == idCates && p.id != id).ToList();
                if (Kiemtra.Count > 0)
                {
                    var ListNewss = db.tblNews.Where(p => p.Ord >= Ord && p.idCate == idCates).ToList();
                    for (int i = 0; i < ListNewss.Count; i++)
                    {
                        int idp = int.Parse(ListNewss[i].id.ToString());
                        var NewUpdate = db.tblNews.Find(idp);
                        NewUpdate.Ord = NewUpdate.Ord + 1;
                        db.SaveChanges();
                    }
                }
                db.SaveChanges();
                 var result = string.Empty;
                result = "Thành công";
                 
                return Json(new { result = result });
            }
            else
            {
                var result = string.Empty;
                result = "Bạn không có quyền truy cập tính năng này";
                return Json(new { result = result });
            }
        }
        public ActionResult Create(string id)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }

            if (Session["Thongbao"] != null && Session["Thongbao"] != "")
            {

                ViewBag.thongbao = Session["Thongbao"].ToString();
                Session["Thongbao"] = "";
            }
            if (ClsCheckRole.CheckQuyen(5, 1, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                var menuModel = db.tblGroupNews.Where(m => m.ParentID == null).OrderBy(m => m.id).ToList(); 
                string strReturn = "---";
                carlist.Clear();
                foreach (var item in menuModel)
                {
                    carlist.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });
                    StringClass.DropDownListNews(item.id, carlist, strReturn);
                    strReturn = "---";
                }
                if (id != "")
                {
                    int ids = int.Parse(id); 
                    var pro = db.tblNews.Where(p => p.idCate ==ids).OrderByDescending(p => p.Ord).Take(1).ToList(); 
                    ViewBag.drMenu = new SelectList(carlist, "Value", "Text", id);
                    int idcate = int.Parse(id.ToString());
                    if (pro.Count > 0)
                        ViewBag.Ord = pro[0].Ord + 1;
                    else
                        ViewBag.Ord = "1";
                }
                else
                {
                    ViewBag.drMenu = carlist;
                    var pro = db.tblNews.OrderByDescending(p => p.Ord).Take(1).ToList();
                    if (pro.Count > 0)
                        ViewBag.Ord = pro[0].Ord + 1;
                }
                //Load chức năng
                var menuModel1 = db.tblGroupProducts.Where(m => m.ParentID == null).OrderBy(m => m.id).ToList();
                carlistProduct.Clear();
                string strReturna = "---";
                foreach (var item in menuModel1)
                {
                    carlistProduct.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });
                    StringClass.DropDownListFor(item.id, carlistProduct, strReturna);
                    strReturna = "---";

                }
                ViewBag.MutilMenu = new SelectList(carlistProduct, "Value", "Text");
                return View();
            }
            else
            {
                return Redirect("/Users/Erro");

            }
        }
        [HttpPost]
        [ValidateInput(false)]

        public ActionResult Create(tblNew tblnews, FormCollection Collection, string id, int[] MutilMenu)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }


            string nidCate = Collection["drMenu"];
            if (nidCate != "")
            {
                tblnews.idCate = int.Parse(nidCate);
                int idcate = int.Parse(nidCate);
                tblnews.DateCreate = DateTime.Now;
                tblnews.Tag = StringClass.NameToTag(tblnews.Name);
                tblnews.DateCreate = DateTime.Now;
                db.tblNews.Add(tblnews);
                db.SaveChanges();
                var listprro = db.tblNews.OrderByDescending(p => p.id).Take(1).ToList();
                clsSitemap.CreateSitemap("2/" + tblnews.Tag+"-"+listprro[0].id+".aspx", listprro[0].id.ToString(), "News");
                #region[Updatehistory]
                Updatehistoty.UpdateHistory("Create News", Request.Cookies["Username"].Values["Username"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
                #endregion
                var ListNews = db.tblNews.OrderByDescending(p => p.id).Take(1).ToList();

                int idNews = int.Parse(ListNews[0].id.ToString());
                if (MutilMenu != null)
                {
                    foreach (var idCate in MutilMenu)
                    {
                        tblConnectNew tblconnectnews = new tblConnectNew();
                        tblconnectnews.idCate = idCate;
                        tblconnectnews.idNew = idNews;
                        db.tblConnectNews.Add(tblconnectnews);
                        db.SaveChanges();

                    }
                }
                if (Collection["btnSave"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info alert1\">Bạn đã thêm tinthành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                    return Redirect("/Newsad/index?idCate=" + nidCate + "");
                }
                if (Collection["btnSaveCreate"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn đã thêm tin  thành công, mời bạn thêm tin mới !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                    return Redirect("/Newsad/Create?id=" + nidCate + "");
                }
            }
            return View();




        }
        public ActionResult AutoOrd(string idCate)
        {

            int id = int.Parse(idCate);
            var ListNews = db.tblNews.Where(p => p.idCate == id).OrderByDescending(p => p.Ord).Take(1).ToList();
            var result = string.Empty;
            if (ListNews.Count > 0)
            {
                int stt = int.Parse(ListNews[0].Ord.ToString()) + 1;
                result = stt.ToString();
            }
            else
            {
                result = "0";

            }
            return Json(new { result = result });
        }
        public string CheckNews(string text)
        {
            string chuoi = "";
            var ListNews = db.tblNews.Where(p => p.Name == text).ToList();
            if (ListNews.Count > 0)
            {
                chuoi = "Tin đã bị trùng lặp !";

            }
            Session["Check"] = ListNews.Count;
            return chuoi;
        }
        public ActionResult Edit(int? id)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            if (ClsCheckRole.CheckQuyen(5, 2, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                Session["id"] = id.ToString();
                Int32 ids = Int32.Parse(id.ToString());
                tblNew tblnews = db.tblNews.Find(ids);

                if (tblnews == null)
                {
                    return HttpNotFound();
                }
                var menuModel = db.tblGroupNews.Where(m => m.ParentID == null).OrderBy(m => m.id).ToList();
                carlist.Clear();
                string strReturns = "---";
                foreach (var item in menuModel)
                {
                    carlist.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });
                    StringClass.DropDownListNews(item.id, carlist, strReturns);
                    strReturns = "---";
                }
                int idGroups = 0;
                if (tblnews.idCate != null)
                {
                    idGroups = int.Parse(tblnews.idCate.ToString());
                }
                ViewBag.drMenu = new SelectList(carlist, "Value", "Text", idGroups);

                var menuModelProduct = db.tblGroupProducts.Where(m => m.ParentID == null).OrderBy(m => m.id).ToList();
                carlistProduct.Clear();
                string strReturn = "---";
                foreach (var item in menuModelProduct)
                {
                    carlistProduct.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });
                    StringClass.DropDownListFor(item.id, carlistProduct, strReturn);
                    strReturn = "---";
                }
                var ListNews = db.tblConnectNews.Where(p => p.idNew == id).ToList();
                List<int> mang = new List<int>();
                for (int i = 0; i < ListNews.Count; i++)
                {

                    mang.Add(int.Parse(ListNews[i].idCate.ToString()));

                }
                ViewBag.MutilMenu = new MultiSelectList(carlistProduct, "Value", "Text", mang);
                return View(tblnews);
            }
            else
            {
                return Redirect("/Users/Erro");

            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(tblNew tblnews, FormCollection collection, int? id, int[] MutilMenu)
        {

            if (ModelState.IsValid)
            {
                if (collection["drMenu"] != "" || collection["drMenu"] != null)
                {
                     string idUser = Request.Cookies["Username"].Values["UserID"];
                     tblnews.idUser = int.Parse(idUser);

                    bool URL = (collection["URL"] == "false") ? false : true;
                    if (URL == true)
                    {
                        tblnews.Tag = StringClass.NameToTag(tblnews.Name);
                    }
                    else
                    {
                        tblnews.Tag = collection["NameURL"];
                    }
                    clsSitemap.CreateSitemap(tblnews.Tag, id.ToString(), "Newsad");
                    tblnews.idCate = int.Parse(collection["drMenu"]);
                    tblnews.DateCreate = DateTime.Now;
                    db.Entry(tblnews).State = EntityState.Modified;
                    db.SaveChanges();

                    if (URL == true)
                    {
                        tblnews.Tag = StringClass.NameToTag(tblnews.Name);
                        clsSitemap.UpdateSitemap("2/" + tblnews.Tag + "-" + id + ".aspx", id.ToString(), "News");

                    }
                    else
                    {
                        tblnews.Tag = collection["NameURL"];
                        clsSitemap.UpdateSitemap("2/" + tblnews.Tag + "-" + id + ".aspx", id.ToString(), "News");
                    }
                    int Ord = int.Parse(tblnews.Ord.ToString());
                    int idCate = int.Parse(collection["drMenu"]);
                    var Kiemtra = db.tblNews.Where(p => p.Ord == Ord && p.idCate == idCate && p.id != id).ToList();
                    if (Kiemtra.Count > 0)
                    {
                        var ListNewss = db.tblNews.Where(p => p.Ord >= Ord && p.idCate == idCate).ToList();
                        for (int i = 0; i < ListNewss.Count; i++)
                        {
                            int idp = int.Parse(ListNewss[i].id.ToString());
                            var NewUpdate = db.tblNews.Find(idp);
                            NewUpdate.Ord = NewUpdate.Ord + 1;
                            db.SaveChanges();
                        }
                    }
                    db.SaveChanges();
                    var ListNews = db.tblConnectNews.Where(p => p.idNew == id).ToList();
                    for (int i = 0; i < ListNews.Count; i++)
                    {
                        db.tblConnectNews.Remove(ListNews[i]);
                        db.SaveChanges();
                    }
                    if (MutilMenu != null)
                    {
                        foreach (var idCates in MutilMenu)
                        {
                            tblConnectNew tblconnectnews = new tblConnectNew();
                            tblconnectnews.idCate = idCates;
                            tblconnectnews.idNew = id;
                            db.tblConnectNews.Add(tblconnectnews);
                            db.SaveChanges();
                        }
                    }
                }
                if (collection["btnSave"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info alert1\">Bạn đã sửa tin thành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";

                    return Redirect("/Newsad/Index?idCate=" + int.Parse(collection["drMenu"]));
                }
                if (collection["btnSaveCreate"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn đã thêm tin thành công, mời bạn thêm tin mới !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                    return Redirect("/Newsad/Create?id=" + +int.Parse(collection["drMenu"]) + "");
                }
                #region[Updatehistory]
                Updatehistoty.UpdateHistory("Update News", Request.Cookies["Username"].Values["Username"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
                #endregion
            }
            return View(tblnews);
        }
        public ActionResult DeleteNews(int id)
        {
            if (ClsCheckRole.CheckQuyen(4, 3, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                tblNew tblnews = db.tblNews.Find(id);
                clsSitemap.DeteleSitemap(id.ToString(), "News");
                var result = string.Empty;
                int ord = int.Parse(tblnews.Ord.ToString());
                int idCate = int.Parse(tblnews.idCate.ToString());
                var kiemtra = db.tblNews.Where(p => p.Ord > ord && p.idCate == idCate).ToList();
                if (kiemtra.Count > 0)
                {
                    var ListNews = db.tblNews.Where(p => p.Ord > ord && p.idCate == idCate).ToList();
                    for (int i = 0; i < ListNews.Count; i++)
                    {
                        int idp = int.Parse(ListNews[i].id.ToString());
                        var NewsUpdate = db.tblNews.Find(idp);
                        NewsUpdate.Ord = NewsUpdate.Ord - 1;
                        db.SaveChanges();
                    }
                }
                db.tblNews.Remove(tblnews);
                db.SaveChanges();
                result = "Bạn đã xóa thành công.";
                return Json(new { result = result });
            }
            else
            {
                var result = string.Empty;

                result = "Bạn không có quyền thay đổi tính năng này !.";
                return Json(new { result = result });

            }

        }
        public JsonResult ListTag(string q)
        {
            var listTag = db.tblNews.Where(p => p.Active == true).ToList();
            List<string> Mang = new List<string>();
            for (int i = 0; i < listTag.Count; i++)
            {
                string[] tag = listTag[i].Keyword.Split(',');
                for (int j = 0; j < tag.Length; j++)
                {
                    if (tag[j].ToUpper().Contains(q.ToUpper()))
                        Mang.Add(tag[j].ToString());
                }
            }
            var ListName = Mang.Take(15);
            return Json(new
            {
                data = ListName,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

    }
}