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
namespace Viglacera.Controllers.Admin.Product
{
    public class ProductSYNadController : Controller
    {
        //
        // GET: /ProductSYNad/
        private ViglaceraContext db = new ViglaceraContext();
        public ActionResult Index(int? page, string id, FormCollection collection)
        {
            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            if (ClsCheckRole.CheckQuyen(6, 0, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                var ListProductsyn = db.tblProductSyns.ToList();

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
                                if (ClsCheckRole.CheckQuyen(6, 3, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
                                {
                                    int ids = Convert.ToInt32(key.Remove(0, 4));
                                    tblProductSyn tblproductsyn = db.tblProductSyns.Find(ids);
                                    db.tblProductSyns.Remove(tblproductsyn);
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
                return View(ListProductsyn.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return Redirect("/Users/Erro");

            }
        }
        public ActionResult UpdateProductsyn(string id, string Active, string Ord)
        {
            if (ClsCheckRole.CheckQuyen(6, 2, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {

                int ids = int.Parse(id);
                var tblProductsyn = db.tblProductSyns.Find(ids);
                tblProductsyn.Active = bool.Parse(Active);
                tblProductsyn.Ord = int.Parse(Ord);
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
        public ActionResult DeleteProductsyn(int id)
        {
            if (ClsCheckRole.CheckQuyen(6, 3, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                tblProductSyn tblProductsyn = db.tblProductSyns.Find(id);
                var result = string.Empty;
                db.tblProductSyns.Remove(tblProductsyn);
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
            if (ClsCheckRole.CheckQuyen(10, 1, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                var pro = db.tblProductSyns.OrderByDescending(p => p.Ord).ToList();
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
        public ActionResult Create(tblProductSyn tblProductsyn, FormCollection collection)
        {
            string[] listarray = tblProductsyn.ImageLinkDetail.Split('/');
            string ImageLinkDetail = collection["ImageLinkDetail"];
            string imagethum = listarray[listarray.Length - 1];
            tblProductsyn.ImageLinkThumb = "/Images/_thumbs/Images/" + imagethum;
            tblProductsyn.Tag = StringClass.NameToTag(tblProductsyn.Name);
            db.tblProductSyns.Add(tblProductsyn);
            db.SaveChanges();
            var lisstch = db.tblProductSyns.OrderByDescending(p => p.id).Take(1).First();
            int id = lisstch.id;
            clsSitemap.CreateSitemap("syn/" + StringClass.NameToTag(tblProductsyn.Name), id.ToString(), "ProductSYN");
            #region[Updatehistory]
            Updatehistoty.UpdateHistory("Add tblProductsyn", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
            #endregion
            if (collection["btnSave"] != null)
            {
                Session["Thongbao"] = "<div  class=\"alert alert-info alert1\">Bạn đã thêm thành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";

                return Redirect("/ProductSYNad/Index");
            }
            if (collection["btnSaveCreate"] != null)
            {
                Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn đã thêm thành công, mời bạn thêm mới !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                return Redirect("/ProductSYNad/Create");
            }
            string Chuoisyn = tblProductsyn.CodeSyn;
            string[] Mang = Chuoisyn.Split(',');
            ProductConnect productconnect = new ProductConnect();
            var listproductSyn = db.tblProductSyns.OrderByDescending(p => p.id).Take(1).ToList();
            int idsyn = int.Parse(listproductSyn[0].id.ToString());
            for (int i = 0; i < Mang.Length; i++)
            {
                productconnect.idSyn = idsyn;
                string idpd = Mang[i].ToString();
                productconnect.idpd = idpd;
                db.ProductConnects.Add(productconnect);
                db.SaveChanges();

            }
            return Redirect("Index");


        }
        public ActionResult Edit(int id = 0)
        {

            if ((Request.Cookies["Username"] == null))
            {
                return RedirectToAction("LoginIndex", "Login");
            }
            if (ClsCheckRole.CheckQuyen(6, 2, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {
                tblProductSyn tblProductsyn = db.tblProductSyns.Find(id);
                if (tblProductsyn == null)
                {
                    return HttpNotFound();
                }
                return View(tblProductsyn);
            }
            else
            {
                return Redirect("/Users/Erro");


            }
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(tblProductSyn tblProductsyn, int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                tblProductsyn.Tag = StringClass.NameToTag(tblProductsyn.Name);

                string[] listarray = tblProductsyn.ImageLinkDetail.Split('/');
                string ImageLinkDetail = collection["ImageLinkDetail"];
                string imagethum = listarray[listarray.Length - 1];
                tblProductsyn.ImageLinkThumb = "/Images/_thumbs/Images/" + imagethum;
                db.Entry(tblProductsyn).State = EntityState.Modified;

                db.SaveChanges();
                var listsyn = db.ProductConnects.Where(p => p.idSyn == id).ToList();
                if (listsyn.Count > 0)
                {
                    for (int i = 0; i < listsyn.Count; i++)
                    {
                        Int32 idpp = listsyn[i].id;
                        var listchld = db.ProductConnects.First(p => p.id == idpp);
                        db.ProductConnects.Remove(listchld);
                        db.SaveChanges();
                    }
                }
                string Chuoisyn = collection["CodeSyn"];
                string[] Mang = Chuoisyn.Split(',');
                ProductConnect productconnect = new ProductConnect();
                var listproductSyn = db.tblProductSyns.OrderByDescending(p => p.id).Take(1).ToList();
                int idsyn = int.Parse(listproductSyn[0].id.ToString());
                for (int i = 0; i < Mang.Length; i++)
                {
                    productconnect.idSyn = id;
                    string idpd = Mang[i].ToString();
                    productconnect.idpd = idpd;
                    db.ProductConnects.Add(productconnect);
                    db.SaveChanges();

                }
                clsSitemap.UpdateSitemap("syn/" + StringClass.NameToTag(tblProductsyn.Name), id.ToString(), "ProductSYN");
                #region[Updatehistory]
                Updatehistoty.UpdateHistory("Edit tblProductsyn", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
                #endregion
                if (collection["btnSave"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info alert1\">Bạn đã sửa  thành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";

                    return Redirect("/ProductSYNad/Index");
                }
                if (collection["btnSaveCreate"] != null)
                {
                    Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn đã thêm thành công, mời bạn thêm mới !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                    return Redirect("/ProductSYNad/Create");
                }
               

            }
            return View(tblProductsyn);
        }
	}
}