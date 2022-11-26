using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Public
{
    public class PublicAuthenticationController : Controller
    {
        UserDao userDao = new UserDao();
        // GET: PublicAuthentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
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
                    Session.Add("USER", userInformation);
                    return RedirectToAction("Index", "PublicHome");
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
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            return Redirect("/PublicHome/Index");
        }
    }
}