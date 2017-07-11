using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;

namespace Viglacera.Controllers.Display.Contact
{
    public class ContactsController : Controller
    {
        //
        // GET: /Contacts/
        ViglaceraContext db = new ViglaceraContext();
        public ActionResult Index()
        {
            if (Session["Status"] != "" && Session["Status"]!=null)
            {

                ViewBag.Lienhe = Session["Status"];
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(tblContact Contact, FormCollection collection)
        {
            tblConfig config = db.tblConfigs.First();
            // Gmail Address from where you send the mail
            var fromAddress = config.UserEmail;
            // any address where the email will be sending
            var toAddress = config.Email;
            //Password of your gmail address
            string fromPassword = config.PassEmail;
            // Passing the values and make a email formate to display
            string subject = "Bạn có liên hệ mới từ : ";
            string body = "From: " + collection["name"] + "\n";

            body += "Tên khách hàng: " + collection["Name"] + "\n";
            body += "Địa chỉ: " + collection["Address"] + "\n";
            body += "Điện thoại: " + collection["Mobile"] + "\n";
            body += "Email: " + collection["Email"] + "\n";
            body += "Nội dung: \n" + collection["Content"] + "\n";

            ////string OrderId = clsConnect.sqlselectOneString("select max(idOrder) as MaxID from [Order]");

            //insert vao bang OrderDetail


            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = config.Host;
                smtp.Port = int.Parse(config.Port.ToString());
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = int.Parse(config.Timeout.ToString());
            }
            smtp.Send(fromAddress, toAddress, subject, body);


            Contact.Active = false;
            Contact.DateCreate = DateTime.Now;
            db.tblContacts.Add(Contact);
            db.SaveChanges();
            Session["Status"] = "<script>$(document).ready(function(){ alert('Bạn đã liên hệ thành công !') });</script>";

            return View();
        }

    }
}
