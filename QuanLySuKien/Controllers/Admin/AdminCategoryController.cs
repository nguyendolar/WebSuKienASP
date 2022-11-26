using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Admin
{
    public class AdminCategoryController : Controller
    {
        CategoryDao categoryDao = new CategoryDao();
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
                ViewBag.List = categoryDao.getAll();
                return View();
            }
            
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Category category)
        {
            categoryDao.Add(category);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Category category)
        {
            categoryDao.Update(category);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Category category)
        {
            var check = eventDao.getByCategory(category.idCategory);
            if (check.Count == 0)
            {
                categoryDao.Delete(category.idCategory);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}