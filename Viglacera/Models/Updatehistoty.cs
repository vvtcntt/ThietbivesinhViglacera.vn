using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Viglacera.Models;
namespace Viglacera.Models
{
    public class Updatehistoty
    {
        public ViglaceraContext db = new ViglaceraContext();
        public static void UpdateHistory(string task,string FullName,string UserID)
        {

            ViglaceraContext db = new ViglaceraContext();
            tblHistoryLogin tblhistorylogin = new tblHistoryLogin();
            tblhistorylogin.FullName = FullName;
            tblhistorylogin.Task = task;
            tblhistorylogin.idUser = int.Parse(UserID);
            tblhistorylogin.DateCreate = DateTime.Now;
            tblhistorylogin.Active = true;
            
            db.tblHistoryLogins.Add(tblhistorylogin);
            db.SaveChanges();
           
        }
    }
}