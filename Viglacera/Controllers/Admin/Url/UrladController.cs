using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
using PagedList;
using PagedList.Mvc;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace Viglacera.Controllers.Admin.Url
{
    public class UrladController : Controller
    {
        // GET: Urlad
        private ViglaceraContext db = new ViglaceraContext();
        public ActionResult Index(int? page, string id, FormCollection collection)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            if (ClsCheckRole.CheckQuyen(15, 0, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                var ListUrl = db.tblUrls.ToList();

                const int pageSize = 20;
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
                                if (ClsCheckRole.CheckQuyen(3, 3, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
                                {
                                    int ids = Convert.ToInt32(key.Remove(0, 4));
                                    tblModule tblmodule = db.tblModules.Find(ids);
                                    db.tblModules.Remove(tblmodule);
                                    db.SaveChanges();
                                    return RedirectToAction("Index");
                                }
                                else
                                {
                                    return Redirect("/Users/Erro");

                                }
                            }
                        }
                    }
                }
                return View(ListUrl.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return Redirect("/Users/Erro");

            }
        }
        public ActionResult UpdateUrl(string id, string Active, string Ord)
        {
            if (ClsCheckRole.CheckQuyen(15, 2, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {

                int ids = int.Parse(id);
                var tblUrl = db.tblUrls.Find(ids);
                tblUrl.Active = bool.Parse(Active);
                tblUrl.Ord = int.Parse(Ord);
                db.SaveChanges();
                var result = string.Empty;
                result = "Thành công";
                return Json(new { result = result });
            }
            else
            {
                var result = string.Empty;
                result = "Bạn không có quyền thay đổi tính năng này";
                return Json(new { result = result });

            }

        }
        public ActionResult DeleteUrl(int id)
        {
            if (ClsCheckRole.CheckQuyen(15, 3, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                tblUrl tblurl = db.tblUrls.Find(id);
                var result = string.Empty;
                db.tblUrls.Remove(tblurl);
                db.SaveChanges();
                result = "Bạn đã xóa thành công.";
                return Json(new { result = result });
            }
            else
            {
                var result = string.Empty;
                result = "Bạn không có quyền thay đổi tính năng này";
                return Json(new { result = result });

            }
        }
        public ActionResult Create()
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
            if (ClsCheckRole.CheckQuyen(15, 1, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                var pro = db.tblUrls.OrderByDescending(p => p.Ord).ToList();
                if (pro.Count > 0)
                    ViewBag.Ord = pro[0].Ord + 1;
                else
                { ViewBag.Ord = "0"; }
                return View();
            }
            else
            {
                return Redirect("/Users/Erro");
            }
        }

        [HttpPost]
        public ActionResult Create(tblUrl tblurl, FormCollection collection)
        {

            db.tblUrls.Add(tblurl);
            db.SaveChanges();
            #region[Updatehistory]
            Updatehistoty.UpdateHistory("Add Url", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
            #endregion
            if (collection["btnSave"] != null)
            {
                Session["Thongbao"] = "<div  class=\"alert alert-info alert1\">Bạn đã thêm thành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";

                return Redirect("/Urlad/Index");
            }
            if (collection["btnSaveCreate"] != null)
            {
                Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn đã thêm thành công, mời bạn thêm danh mục  mới !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                return Redirect("/Urlad/Create");
            }
            return Redirect("Index");


        }
        public ActionResult Edit(int id = 0)
        {

            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            if (ClsCheckRole.CheckQuyen(15, 2, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                tblUrl tblurl = db.tblUrls.Find(id);
                if (tblurl == null)
                {
                    return HttpNotFound();
                }
                return View(tblurl);
            }
            else
            {
                return Redirect("/Users/Erro");


            }
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(tblUrl tblurl, int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblurl).State = EntityState.Modified;

                db.SaveChanges();
                #region[Updatehistory]
                Updatehistoty.UpdateHistory("Edit tblurl", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
                #endregion
                if (collection["btnSave"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info alert1\">Bạn đã sửa  thành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";

                    return Redirect("/urlad/Index");
                }
                if (collection["btnSaveCreate"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn đã thêm thành công, mời bạn thêm mới !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                    return Redirect("/urlad/Create");
                }
            }
            return View(tblurl);
        }

    }
}