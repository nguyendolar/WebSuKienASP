using OfficeOpenXml;
using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Admin
{
    public class AdminUserController : Controller
    {
        UserDao userDao = new UserDao();
        EventDao eventDao = new EventDao();
        // GET: AdminVoucher
        public ActionResult Index(string msg)
        {
            User user = (User)Session["ADMIN"];
            if (user == null)
            {
                return RedirectToAction("Login", "AdminAuthentication");
            }
            else
            {
                ViewBag.Msg = msg;
                ViewBag.List = userDao.getStudent();
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(User user)
        {
            var check = userDao.getUserByUserName(user.userName);
            if (check != null)
            {
                return RedirectToAction("Index", new { msg = "3" });
            }
            else
            {
                user.role = "student";
                userDao.Add(user);
                return RedirectToAction("Index", new { msg = "1" });
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(User user)
        {
            userDao.Update(user);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(User user)
        {
            var check = eventDao.getByUser(user.idUser);
            if (check.Count == 0)
            {
                userDao.Delete(user.idUser);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ReadExcel()
        {
            try
            {
                var excelFile = Request.Files["fileExcel"];
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(excelFile.InputStream))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets[0];
                    for (int rw = 2; rw <= ws.Dimension.End.Row; rw++)
                    {
                        var username = ws.Cells[rw, 1].Value;
                        var password = ws.Cells[rw, 2].Value;
                        var user = new User
                        {
                            userName = username.ToString(),
                            password = password.ToString(),
                            role = "student"
                        };
                        var check = userDao.getUserByUserName(user.userName);
                        if (check == null)
                        {
                            userDao.Add(user);
                        }
                    }
                    return RedirectToAction("Index", new { msg = "1" });
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction("Index", new { msg = "3" });
            }
        }
    }
}