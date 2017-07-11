using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
using System.Data.Entity;

namespace Viglacera.Controllers.Admin.Config
{
    public class ConfigController : Controller
    {
        // GET: Config
        private ViglaceraContext db = new ViglaceraContext();
        public ActionResult Index()
        {

            if ((Request.Cookies["Username"] == null))
            {

                return RedirectToAction("LoginIndex", "Login");
            }
 
            if (ClsCheckRole.CheckQuyen(1, 0, int.Parse(Request.Cookies["Username"].Values["UserID"])) == true)
            {

                tblConfig tblconfig = db.tblConfigs.First();


                if (tblconfig == null)
                {
                    return HttpNotFound();
                }
                if (Session["Thongbao"] != "")
                {
                    ViewBag.thongbao = Session["Thongbao"];
                    Session["Thongbao"] = "";
                }
                return View(tblconfig);
            }
            else
            {
               Session["Role"] = "<script>$(document).ready(function(){ alert('Bạn không có quyền truy cập vào tính năng này !') });</script>";

            }
            return Redirect("/Users/Erro");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(tblConfig tblconfig, int id = 1)
        {
            if (ModelState.IsValid)
            {

                tblconfig.ID = id;

                #region[Updatehistory]
                Updatehistoty.UpdateHistory("Config Website", Request.Cookies["Username"].Values["FullName"].ToString(), Request.Cookies["Username"].Values["UserID"].ToString());
                #endregion
                db.Entry(tblconfig).State = EntityState.Modified;
                db.SaveChanges();
                Session["Thongbao"] = "<div  class=\"alert alert-info\">Bạn cập nhật thành công !<button class=\"close\" data-dismiss=\"alert\">×</button></div>";
                return RedirectToAction("Index");
            }
            return View(tblconfig);
        }
    }
}