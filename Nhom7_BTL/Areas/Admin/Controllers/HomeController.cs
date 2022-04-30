using Nhom7_BTL.Helper;
using Nhom7_BTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom7_BTL.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        Web_Tranh_Theu db = new Web_Tranh_Theu();
        [FilterAdmin]
        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.Count();
            ViewBag.Products = db.Products.Count();
            ViewBag.Accounts = db.Accounts.Count();
            ViewBag.Orders = db.Orders.Count();
            return View();
        }
       public ActionResult Login()
       {
            return View();
       }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account account)
        {
            Account acc = null ;
            if (ModelState.IsValid)
            {
                String passw = Encryptor.MD5Hash(account.Password);
                acc =
                (Account)(from a in db.Accounts
                              //join r in db.Roles_Account on a.Account_Id equals r.Account_Id
                              where(a.Email.Equals(account.Email) &&
                              a.Password.Equals(passw) /*&& r.Role_Id == 1*/)
                              select a).FirstOrDefault();
                if (acc != null)
                {
                    Session["idAdmin"] = acc.Account_Id;
                    Session["UserName"] = acc.Username;
                    Session["Email"] = acc.Email;
                    var url = Session["url-redirect"];
                    if (url != null)
                    {
                        Session.Remove("url-redirect");
                        return Redirect(url.ToString());

                    }
                    return RedirectToAction("Index");
                    ViewBag.error = "Đăng nhập thành công";
                }
                else
                {
                    ViewBag.error = "Đăng nhập không thành công";
                }

            }
            return View(acc);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }

}