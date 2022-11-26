using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        CategoryDao categoryDao = new CategoryDao();
        EventDao eventDao = new EventDao();
        public class StatisDto
        {
            public string categoryName { get; set; }

            public int totalEvent { get; set; }
        }
        public ActionResult Index()
        {
            User user = (User)Session["ADMIN"];
            if (user == null)
            {
                return RedirectToAction("Login", "AdminAuthentication");
            }
            else
            {
                return View();
            }

        }

        public ActionResult StatisHome()
        {
            var categoty = categoryDao.getAll();
            ViewBag.List = categoty.Select(x => new StatisDto()
            {
                categoryName = x.name,
                totalEvent = eventDao.getByCategory(x.idCategory).Count
            }).ToList();
            return View();
        }
    }
}