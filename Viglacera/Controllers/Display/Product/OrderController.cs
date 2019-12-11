using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viglacera.Models;
using System.Net;
using System.Net.Mail;
namespace CMSCODE.Controllers.Display.Product
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        float tongtien = 0;
        //
        // GET: /Order/

        ViglaceraContext db = new ViglaceraContext();
        [HttpPost]
        public ActionResult Command(FormCollection collection, string tag)
        {
            if (collection["btnOrd"] != null)
            {
                try
                {
                    string Name = collection["Name"];
                    string Address = collection["Address"];
                    string DateByy = collection["DateByy"];
                    string Mobile = collection["Mobile"];
                    string Email = collection["Email"];
                    string Description = collection["Description"];
                    var Sopping = (clsGiohang)Session["giohang"];
                    tblOrder order = new tblOrder();
                    order.Name = Name;
                    order.Address = Address;
                    order.DateByy = DateTime.Parse(DateByy);
                    try
                    {
                        order.Mobile = Mobile;
                    }
                    catch
                    {

                        order.Mobile = "0";
                    }
                    order.Email = Email;
                    order.Description = Description;
                    order.Active = false;

                    tblOrderDetail orderdetail = new tblOrderDetail();
                    var MaxOrd = db.tblOrders.OrderByDescending(p => p.id).Take(1).ToList();
                    int idOrder = 1;
                    if (MaxOrd.Count > 0)
                        idOrder = MaxOrd[0].id;
                    for (int i = 0; i < Sopping.CartItem.Count; i++)
                    {
                        orderdetail.idProduct = Sopping.CartItem[i].id;
                        orderdetail.Name = Sopping.CartItem[i].Name;
                        orderdetail.Price = Sopping.CartItem[i].Price;
                        orderdetail.Quantily = Sopping.CartItem[i].Ord;
                        orderdetail.SumPrice = Sopping.CartItem[i].SumPrice;
                        orderdetail.idOrder = idOrder;
                        db.tblOrderDetails.Add(orderdetail);
                        db.SaveChanges();
                    }
                    tblConfig config = db.tblConfigs.First();
                    var fromAddress = config.UserEmail;
                    var toAddress = config.Email;
                    var orders = db.tblOrders.OrderByDescending(p => p.id).Take(1).ToList();
                    string fromPassword = config.PassEmail;
                    string ararurl = Request.Url.ToString();
                    var listurl = ararurl.Split('/');
                    string urlhomes = "";
                    for (int i = 0; i < listurl.Length - 2; i++)
                    {
                        if (i > 0)
                            urlhomes += "/" + listurl[i];
                        else
                            urlhomes += listurl[i];
                    }
                    string subject = "Đơn hàng mới từ " + urlhomes + "";
                    string chuoihtml = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title>Thông tin đơn hàng</title></head><body style=\"background:#f2f2f2; font-family:Arial, Helvetica, sans-serif\"><div style=\"width:750px; height:auto; margin:5px auto; background:#FFF; border-radius:5px; overflow:hidden\">";
                    chuoihtml += "<div style=\"width:100%; height:40px; float:left; margin:0px; background:#1c7fc4\"><span style=\"font-size:14px; line-height:40px; color:#FFF; margin:auto 20px; float:left\">" + DateTime.Now.Date + "</span><span style=\"font-size:14px; line-height:40px; float:right; margin:auto 20px; color:#FFF; text-transform:uppercase\">Hotline : " + config.Hotline1 + "</span></div>";
                    chuoihtml += "<div style=\"width:100%; height:auto; float:left; margin:0px\"><div style=\"width:35%; height:100%; margin:0px; float:left\"><a href=\"/\" title=\"\"><img src=\"" + urlhomes + "" + config.Logo + "\" alt=\"Logo\" style=\"margin:8px; display:block; max-height:95% \" /></a></div><div style=\"width:60%; height:100%; float:right; margin:0px; text-align:right\"><span style=\"font-size:18px; margin:20px 5px 5px 5px; display:block; color:#ff5a00; text-transform:uppercase\">" + config.Name + "</span><span style=\"display:block; margin:5px; color:#515151; font-size:13px; text-transform:uppercase\">Lớn nhất - Chính hãng - Giá rẻ nhất việt nam</span> </div>  </div>";
                    chuoihtml += "<span style=\"text-align:center; margin:10px auto; font-size:20px; color:#000; font-weight:bold; text-transform:uppercase; display:block\">Thông tin đơn hàng</span>";
                    chuoihtml += " <div style=\"width:90%; height:auto; margin:10px auto; background:#f2f2f2; padding:15px\">";
                    chuoihtml += "<p style=\"font-size:14px; color:#464646; margin:5px 20px\">Đơn hàng từ website : <span style=\"color:#1c7fc4\">" + urlhomes + "</span></p>";
                    chuoihtml += "<p style=\"font-size:14px; color:#464646; margin:5px 20px\">Ngày gửi đơn hàng : <span style=\"color:#1c7fc4\">Vào lúc " + DateTime.Now.Hour + " giờ " + DateTime.Now.Minute + " phút ( ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + ") </span></p>";
                    chuoihtml += "<p style=\"font-size:14px; color:#464646; margin:5px 20px\">Mã đơn hàng : <span style=\"color:#1c7fc4\">" + idOrder + " </span></p>";
                    chuoihtml += "<p style=\"font-size:14px; color:#1b1b1b; margin:5px 20px; text-decoration:underline; text-transform:uppercase\">Danh sách sản phẩm : </p>";
                    chuoihtml += "<table style=\"width:100%; height:auto; margin:10px auto; background:#FFF; border:1px\" border=\"0\">";
                    chuoihtml += " <tr style=\" background:#1c7fc4; color:#FFF; text-align:center; line-height:25px; font-size:12px\">";

                    chuoihtml += "<td>STT</td>";
                    chuoihtml += "<td>Tên sản phẩm</td>";
                    chuoihtml += "<td>Đơn giá (vnđ)</td>";
                    chuoihtml += "<td>Số lượng</td>";
                    chuoihtml += "<td>Thành tiền (vnđ)</td>";
                    chuoihtml += "</tr>";

                    for (int i = 0; i < Sopping.CartItem.Count; i++)
                    {
                        chuoihtml += "<tr style=\"line-height:20px; font-size:13px; color:#000; text-indent:5px; border-bottom:1px dashed #cecece; margin:1px 0px;\">";
                        chuoihtml += "<td style=\"text-align:center; width:7%\">" + i + "</td>";
                        chuoihtml += "<td style=\"width:45%\">" + Sopping.CartItem[i].Name + "</td>";
                        int gia = Convert.ToInt32(Sopping.CartItem[i].Price.ToString());
                        chuoihtml += "<td style=\"text-align:center; width:15%\">" + gia.ToString().Replace(",", "") + "</td>";
                        chuoihtml += "<td style=\"text-align:center; width:10%\">" + Sopping.CartItem[i].Ord + "</td>";

                        float thanhtien = Sopping.CartItem[i].Price * Sopping.CartItem[i].Ord;
                        chuoihtml += "<td style=\"text-align:center; font-weight:bold\">" + thanhtien.ToString().Replace(",", "") + "</td>";
                        chuoihtml += " </tr>";

                    }
                    chuoihtml += "<tr style=\"font-size:12px; font-weight:bold\">";
                    chuoihtml += "<td colspan=\"4\" style=\"text-align:right\">Tổng giá trị đơn hàng : </td>";
                    chuoihtml += "<td style=\"font-size:14px; color:#F00\">" + Sopping.CartTotal + " vnđ</td>";
                    chuoihtml += " </tr>";
                    chuoihtml += "</table>";
                    chuoihtml += "<div style=\" width:100%; margin:15px 0px\">";
                    chuoihtml += "<div style=\"width:49%; height:auto; float:left; margin:0px; border:1px solid #d5d5d5\">";
                    chuoihtml += "<div style=\" width:100%; height:30px; float:left; background:#1c7fc4; font-size:12px; color:#FFF; text-indent:15px; line-height:30px\">    	Thông tin người gửi     </div>";
                    chuoihtml += "<div style=\"width:100%; height:auto; float:left\">";
                    chuoihtml += "<p style=\"font-size:12px; margin:5px 10px\">Họ và tên :<span style=\"font-weight:bold\"> " + Name + "</span></p>";
                    chuoihtml += "<p style=\"font-size:12px; margin:5px 10px\">Địa chỉ :<span style=\"font-weight:bold\"> " + Address + "</span></p>";
                    chuoihtml += "<p style=\"font-size:12px; margin:5px 10px\">Điện thoại :<span style=\"font-weight:bold\"> " + Mobile + "</span></p>";
                    chuoihtml += "<p style=\"font-size:12px; margin:5px 10px\">Email :<span style=\"font-weight:bold\">" + Email + "</span></p>";
                    chuoihtml += "</div>";
                    chuoihtml += "</div>";
                    chuoihtml += "<div style=\"width:49%; height:auto; float:right; margin:0px; border:1px solid #d5d5d5\">";
                    chuoihtml += "<div style=\" width:100%; height:30px; float:left; background:#1c7fc4; font-size:12px; color:#FFF; text-indent:15px; line-height:30px\">   	Yêu cầu của người gửi       </div>";
                    chuoihtml += " <div style=\"width:100%; height:auto; float:left\">";
                    chuoihtml += "<p style=\"font-size:12px; margin:5px 10px; font-weight:bold; color:#F00\"> - " + Description + "</p>";
                    chuoihtml += "</div>";
                    chuoihtml += "</div>";
                    chuoihtml += "</div>";
                    chuoihtml += "<div style=\"width:100%; height:auto; float:left; margin:0px\">";
                    chuoihtml += "<hr style=\"width:80%; height:1px; background:#d8d8d8; margin:20px auto 10px auto\" />";
                    chuoihtml += "<p style=\"font-size:12px; text-align:center; margin:5px 5px\">" + config.Address1 + "</p>";
                    chuoihtml += "<p style=\"font-size:12px; text-align:center; margin:5px 5px\">Điện thoại : " + config.Mobile1 + " - " + config.Hotline1 + "</p>";
                    chuoihtml += " <p style=\"font-size:12px; text-align:center; margin:5px 5px; color:#ff7800\">Thời gian mở cửa : Từ 7h30 đến 18h30 hàng ngày (làm cả thứ 7, chủ nhật). Khách hàng đến trực tiếp xem hàng giảm thêm giá.</p>";
                    chuoihtml += "</div>";
                    chuoihtml += "<div style=\"clear:both\"></div>";
                    chuoihtml += " </div>";
                    chuoihtml += " <div style=\"width:100%; height:40px; float:left; margin:0px; background:#1c7fc4\">";
                    chuoihtml += "<span style=\"font-size:12px; text-align:center; color:#FFF; line-height:40px; display:block\">Copyright (c) 2002 – 2015 SEABIG VIET NAM. All Rights Reserved</span>";
                    chuoihtml += " </div>";
                    chuoihtml += "</div>";
                    chuoihtml += "</body>";
                    chuoihtml += "</html>";
                    string body = chuoihtml;
                    order.Tolar = Sopping.CartTotal;
                    db.tblOrders.Add(order);
                    db.SaveChanges();
                    var smtp = new System.Net.Mail.SmtpClient();
                    {
                        smtp.Host = config.Host;
                        smtp.Port = int.Parse(config.Port.ToString());
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                        smtp.Timeout = int.Parse(config.Timeout.ToString());
                    }
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true,


                    })
                    {
                        smtp.Send(message);
                    }


                    Session["Status"] = "<script>$(document).ready(function(){ alert('Bạn đã đặt hàng thành công !') });</script>";
                    return RedirectToAction("OrderIndex");
                }
                catch (Exception ex)
                {
                    Session["Status"] = "<script>$(document).ready(function(){ alert('Bạn đã đặt hàng thành công " + ex.Message + "!') });</script>";
                    return RedirectToAction("OrderIndex");
                }

            }
            return RedirectToAction("OrderIndex");
        }
        public ActionResult OrderIndex()
        {
            int id; int Ord; int idMenu;
            if (Session["idProduct"] != "" && Session["OrdProduct"] != "" && Session["idMenu"] != "")
            {
                id = int.Parse(Session["idProduct"].ToString());
                  Ord= int.Parse(Session["OrdProduct"].ToString());
                  idMenu = int.Parse(Session["idMenu"].ToString());
                  Session["idProduct"] = "";
                  Session["OrdProduct"] = "";
                  Session["idMenu"] = "";
                  int sl = 0;
                  var Sopping = (clsGiohang)Session["giohang"];
                  if (Sopping == null)
                  {
                      Sopping = new clsGiohang();
                  }
                  if (Kiemtra(id) == 1)
                  {
                      for (int i = 0; i < Sopping.CartItem.Count; i++)
                      {
                          if (Sopping.CartItem[i].id == id)
                          {
                              Sopping.CartItem[i].Ord = Sopping.CartItem[i].Ord + Ord;
                              Sopping.CartItem[i].SumPrice = Sopping.CartItem[i].Ord * Sopping.CartItem[i].Price;
                          }
                          tongtien += Sopping.CartItem[i].SumPrice;
                      }
                      Sopping.CartTotal = tongtien;
                  }
                  else
                  {
                      var Sanpham = new clsProduct();
                      Sanpham.id = id;
                      var Product = db.tblProducts.Find(id);
                      Sanpham.Price = float.Parse(Product.Price.ToString());
                      Sanpham.Ord = Ord;
                      Sanpham.Name = Product.Name;
                      Sanpham.idMenu = idMenu;
                      Sanpham.SumPrice = Sanpham.Price * Sanpham.Ord;
                      Sanpham.Tag = Product.Tag;
                      Sopping.CartItem.Add(Sanpham);
                      for (int i = 0; i < Sopping.CartItem.Count; i++)
                      {
                          tongtien += Sopping.CartItem[i].SumPrice;
                      }
                      Sopping.CartTotal = tongtien;

                  }

                  Session["giohang"] = Sopping;
                  sl = Sopping.CartItem.Count;
                  var s = (clsGiohang)Session["giohang"];


                  Session["soluong"] = sl;
            }
        
           
           
            var giohang = (clsGiohang)Session["giohang"];
            if (Session["Status"] != "")
            {
                ViewBag.Status = Session["Status"];
                Session["Status"] = "";
            }


            ViewBag.url = Session["Url"].ToString();
            ViewBag.Title = "<title>Giỏ hàng của bạn</title>";
            ViewBag.Description = "<meta name=\"description\" content=\" Giỏ hàng đặt hàng máy lọc nước Sơn Hà dành cho khách hàng mua sản phẩm\"/>";
            ViewBag.Keyword = "<meta name=\"keywords\" content=\"Giỏ hàng của bạn\" /> ";
            return View(giohang);
        }

        [HttpPost]
        public ActionResult CreateOrd(string Name,string Address,string DateByy,string Mobile,string Email,string Description)
        {
            var Sopping = (clsGiohang)Session["giohang"];
            tblOrder order = new tblOrder();
            order.Name = Name;
            order.Address = Address;
            order.DateByy = DateTime.Parse(DateByy);
            order.Mobile = Mobile;
            order.Email = Email;
            order.Description = Description;
            order.Active = false;
            order.Tolar = Sopping.CartTotal;
            db.tblOrders.Add(order);
            db.SaveChanges();

            tblOrderDetail orderdetail = new tblOrderDetail();
            var MaxOrd = db.tblOrders.OrderByDescending(p => p.id).Take(1).ToList();
            int idOrder = MaxOrd[0].id;
            for (int i = 0; i < Sopping.CartItem.Count; i++)
            {
                orderdetail.idProduct = Sopping.CartItem[i].id;
                orderdetail.Name = Sopping.CartItem[i].Name;
                orderdetail.Price = Sopping.CartItem[i].Price;
                orderdetail.Quantily = Sopping.CartItem[i].Ord;
                orderdetail.SumPrice = Sopping.CartItem[i].SumPrice;
                orderdetail.idOrder = idOrder;
                db.tblOrderDetails.Add(orderdetail);
                db.SaveChanges();
            }
            //Send mail cho khách

            tblConfig config = db.tblConfigs.First();
            // Gmail Address from where you send the mail
            var fromAddress = config.UserEmail;
            // any address where the email will be sending
            var toAddress = config.Email;
            //Password of your gmail address
            string fromPassword = config.PassEmail;
            // Passing the values and make a email formate to display
            string subject = "Đơn hàng mới từ Thietbivesinhviglacera.vn";
            string body = "From: " + Name + "\n";

            body += "Tên khách hàng: " + Name + "\n";
            body += "Địa chỉ: " + Address + "\n";
            body += "Điện thoại: " + Mobile + "\n";
            body += "Email: " + Email + "\n";
            body += "Nội dung: \n" + Description + "\n";
            body += "THÔNG TIN ĐƠN ĐẶT HÀNG \n";
            ////string OrderId = clsConnect.sqlselectOneString("select max(idOrder) as MaxID from [Order]");

            //insert vao bang OrderDetail

            for (int i = 0; i < Sopping.CartItem.Count; i++)
            {
                body += "Tên sản phẩm : " + Sopping.CartItem[i].Name + "\n";
                body += "Đơn giá  :" + Sopping.CartItem[i].Price.ToString().Replace(",", "") + "\n";
                body += "Số lượng : " + Sopping.CartItem[i].Ord + "\n";


            }
            body += "Tổng giá trị đơn hàng là " + Sopping.CartTotal;
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


        Session["Status"] = "<script>$(document).ready(function(){ alert('Bạn đã đặt hàng thành công !') });</script>";
        return RedirectToAction("OrderIndex");
        }
[HttpPost]      
        public ActionResult OrderAdd(int id, int Ord)
        {
            id = int.Parse(Session["idProduct"].ToString());
            Ord = int.Parse(Session["OrdProduct"].ToString());
            Session["idProduct"] = "";
            Session["OrdProduct"] = "";
            int sl = 0;
            var Sopping = (clsGiohang)Session["giohang"];
            if (Sopping == null)
            {
                Sopping = new clsGiohang();
            }
            if (Kiemtra(id) == 1)
            {
                for (int i = 0; i < Sopping.CartItem.Count; i++)
                {
                    if (Sopping.CartItem[i].id == id)
                    {
                        Sopping.CartItem[i].Ord = Sopping.CartItem[i].Ord + Ord;
                        Sopping.CartItem[i].SumPrice = Sopping.CartItem[i].Ord * Sopping.CartItem[i].Price;
                    }
                    tongtien += Sopping.CartItem[i].SumPrice;
                }
                Sopping.CartTotal = tongtien;
            }
            else
            {
                var Sanpham = new clsProduct();
                Sanpham.id = id;
                var Product = db.tblProducts.Find(id);
                Sanpham.Price = float.Parse(Product.Price.ToString());
                Sanpham.Ord = Ord;
                Sanpham.Name = Product.Name;
                Sanpham.SumPrice = Sanpham.Price * Sanpham.Ord;
                Sanpham.Tag = Product.Tag;
                Sopping.CartItem.Add(Sanpham);
                for (int i = 0; i < Sopping.CartItem.Count; i++)
                {
                    tongtien += Sopping.CartItem[i].SumPrice;
                }
                Sopping.CartTotal = tongtien;

            }

         Session["giohang"] = Sopping;
         sl = Sopping.CartItem.Count;
         var s = (clsGiohang)Session["giohang"];


         Session["soluong"] = sl;
         return RedirectToAction("OrderIndex", "Order");            
        }
        public int Kiemtra(int idProduct)
        {
            int so = 0;
            var Sopping =(clsGiohang) Session["giohang"];
            if (Sopping != null)
            {
                for (int i = 0; i < Sopping.CartItem.Count; i++)
                {
                    if (Sopping.CartItem[i].id == idProduct)
                    {
                        so = 1; break;
                    }



                }

            }
            return so;
        }
        public ActionResult UpdatOder(int id, int Ord)
        {
            float tt = 0;
            var tien ="";
            int sl=0;
            var s = (clsGiohang)Session["giohang"];
            if (s != null)
            {
                for (int i = 0; i < s.CartItem.Count; i++) 
                {
                    if (id == s.CartItem[i].id) {
                        s.CartItem[i].Ord = Ord;
                        s.CartItem[i].SumPrice = Ord * s.CartItem[i].Price;
                        tien = s.CartItem[i].SumPrice.ToString();
                    }

                    tt += s.CartItem[i].SumPrice;

                }

                s.CartTotal = tt;
                sl = s.CartItem.Count;
            }
            Session["giohang"] = s;
            return Json(new{gia =string.Format("{0:#,#}", tien) ,tt=string.Format("{0:#,#}",tt) ,sl=sl});
        }
        public ActionResult DeleteOrder(int id)
        {
            var s = (clsGiohang)Session["giohang"];
            int sl = 0;
            for (int i = 0; i < s.CartItem.Count; i++)
            {
                if (s.CartItem[i].id == id)
                    s.CartItem.Remove(s.CartItem[i]);
            }
            sl = s.CartItem.Count;

            for (int i = 0; i < s.CartItem.Count; i++)
            {
                tongtien += s.CartItem[i].SumPrice;
            }
            s.CartTotal = tongtien;

            Session["soluong"] = sl;
           
            return RedirectToAction("OrderIndex");
        }
        public PartialViewResult OrderPartial()
        {
            return PartialView();
        }
        public PartialViewResult InputOrder()
        {
            return PartialView();
        }
    }
}
