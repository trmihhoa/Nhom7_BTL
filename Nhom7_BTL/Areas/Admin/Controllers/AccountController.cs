using Nhom7_BTL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom7_BTL.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private Web_Tranh_Theu db = new Web_Tranh_Theu();
        // GET: Admin/Account
        public ActionResult Index()
        {
            /*var query = from ra in db.Roles_Account
                        join r in db.Roles on ra.Role_Id equals r.Role_Id
                        join a in db.Accounts on ra.Account_Id equals a.Account_Id
                        select new
                        {
                            a
                        };
            var result = query.ToList();*/
            var roles = db.Roles.ToList();
            ViewData["RoleName"] = roles;
            var result2 = db.Accounts.Include(x=>x.Roles_Account).ToList();
            return View(result2);
        }
        [HttpPost]
        public ActionResult EditStatus(int id)
        {
            bool result = false;
            var u = db.Accounts.Where(x => x.Account_Id == id).FirstOrDefault();
            if (u != null)
            {
                if (u.Active)
                {
                    u.Active = false;
                }
                else
                {
                    u.Active = true;
                }
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add_Account()
        {
            ViewBag.RoleID = db.Roles.Select(dm => dm).Distinct();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Account([Bind(Include = "Account_Id,Username,Password,Customer_Name,Email,Roles_Account")] Account account)
        {
            try
            {
                ViewBag.RoleID = db.Roles.Select(dm => dm).Distinct();
                if (ModelState.IsValid)
                {
                    string password = account.Password;
                    account.Password = Encryptor.MD5Hash(password);
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    int tenDM = Convert.ToInt32(Request.Form["tenDM"]);
                    Roles_Account ra = new Roles_Account();
                    ra.Role_Id = tenDM;
                    ra.Account_Id = account.Account_Id;

                    db.Roles_Account.Add(ra);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
            }

            return View(account);
        }
        [HttpPost]
        public JsonResult DeleteAccount(int id)
        {
            bool result = false;
            var u = db.Accounts.Find(id);
            var l = db.Roles_Account.Where(a => a.Account_Id == id).ToList();
            if (u != null)
            {
                foreach (var item in l)
                {
                    db.Roles_Account.Remove(item);

                }
                db.SaveChanges();
                db.Accounts.Remove(u);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}