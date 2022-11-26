using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Admin
{
    public class AdminAuthenticationController : Controller
    {
        UserDao userDao = new UserDao();
        // GET: AdminAuthentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return RedirectToAction("Login", "PublicAuthentication");
        }


        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            User user = new User()
            {
                userName = form["userName"],
                password = form["password"]
            };
            bool checkLogin = userDao.checkLogin(user.userName, user.password);
            if (checkLogin)
            {
                var userInformation = userDao.getUserByUserName(user.userName);

                if (!userInformation.role.Equals("admin"))
                {
                    ViewBag.mess = "You do not have access to the admin page";
                    return View("Login");
                }
                else
                {
                    Session.Add("ADMIN", userInformation);
                    return RedirectToAction("Index", "AdminHome");
                }

            }
            else
            {
                ViewBag.mess = "Incorrect account or password information";
                return View("Login");
            }

        }
        public ActionResult Logout()
        {
            Session.Remove("ADMIN");
            return Redirect("/AdminHome/Index");
        }
    }
}