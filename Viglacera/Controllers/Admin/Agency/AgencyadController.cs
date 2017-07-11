﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
using PagedList;
using PagedList.Mvc;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using System.Xml;
using System.Data.Entity;
namespace Viglacera.Controllers.Admin.Agency
{
    public class AgencyadController : Controller
    {
        ViglaceraContext db = new ViglaceraContext();
        // GET: Capacityad
        public ActionResult Index(int? page, string id, FormCollection collection)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            if (ClsCheckRole.CheckQuyen(15, 0, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                var ListAgency = db.tblAgencies.ToList();

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
                                if (ClsCheckRole.CheckQuyen(14, 3, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
                                {
                                    int ids = Convert.ToInt32(key.Remove(0, 4));
                                    tblAgency tblagency = db.tblAgencies.Find(ids);
                                    db.tblAgencies.Remove(tblagency);
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
                return View(ListAgency.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return Redirect("/Users/Erro");

            }
        }
        public ActionResult UpdateAgency(string id, string Active, string Ord)
        {
            if (ClsCheckRole.CheckQuyen(15, 2, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {

                int ids = int.Parse(id);
                var tblAgency = db.tblAgencies.Find(ids);
                tblAgency.Active = bool.Parse(Active);
                tblAgency.Ord = int.Parse(Ord);
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
        public ActionResult DeleteAgency(int id)
        {
            if (ClsCheckRole.CheckQuyen(15, 3, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                tblAgency tblagency = db.tblAgencies.Find(id);
                var result = string.Empty;
                db.tblAgencies.Remove(tblagency);
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
                var pro = db.tblAgencies.OrderByDescending(p => p.Ord).ToList();
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
        [ValidateInput(false)]
        public ActionResult Create(tblAgency tblagency, FormCollection collection)
        {
            tblagency.DateCreate = DateTime.Now;
            string idUser = Request.Cookies["Username"].Values["UserID"];
            tblagency.idUser = int.Parse(idUser);
            tblagency.Tag = StringClass.NameToTag(tblagency.Name);
            db.tblAgencies.Add(tblagency);
            db.SaveChanges();
            #region[Updatehistory]
            var Groups = db.tblAgencies.Where(p => p.Active == true).OrderByDescending(p => p.id).Take(1).ToList();
            string id = Groups[0].id.ToString();
            clsSitemap.CreateSitemap("NhaPhanPhoi/" + StringClass.NameToTag(tblagency.Name)+"-"+tblagency.id+".aspx", id, "Agency");
            Updatehistoty.UpdateHistory("Add tblagency", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
            #endregion
            if (collection["btnSave"] != null)
            {
                Session["Thongbao"] = "<div  class=\"alert alert-info alert1\">Bạn đã thêm thành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";

                return Redirect("/Agencyad/Index");
            }
            if (collection["btnSaveCreate"] != null)
            {
                Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn đã thêm thành công, mời bạn thêm danh mục  mới !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                return Redirect("/Agencyad/Create");
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
                tblAgency tblagency = db.tblAgencies.Find(id);
                if (tblagency == null)
                {
                    return HttpNotFound();
                }
                return View(tblagency);
            }
            else
            {
                return Redirect("/Users/Erro");


            }
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(tblAgency tblagency, int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                string idUser = Request.Cookies["Username"].Values["UserID"];
                tblagency.idUser = int.Parse(idUser);
                bool URL = (collection["URL"] == "false") ? false : true;
                if (URL == true)
                {
                    tblagency.Tag = StringClass.NameToTag(tblagency.Name);
                }
                else
                {
                    tblagency.Tag = collection["NameURL"];
                }

                tblagency.DateCreate = DateTime.Now;
                db.Entry(tblagency).State = EntityState.Modified;

                db.SaveChanges();
                clsSitemap.UpdateSitemap("NhaPhanPhoi/" + StringClass.NameToTag(tblagency.Name) + "-" + tblagency.id + ".aspx", id.ToString(), "Capacity");

                #region[Updatehistory]
                Updatehistoty.UpdateHistory("Edit Agency", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
                #endregion
                if (collection["btnSave"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info alert1\">Bạn đã sửa  thành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";

                    return Redirect("/Agencyad/Index");
                }
                if (collection["btnSaveCreate"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn đã thêm thành công, mời bạn thêm mới !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                    return Redirect("/Agencyad/Create");
                }
            }
            return View(tblagency);
        }
    }
}