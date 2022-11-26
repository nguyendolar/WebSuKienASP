using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Admin
{
    public class AdminCooperativeController : Controller
    {
        CooperativeDao cooperativeDao = new CooperativeDao();
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
                ViewBag.List = cooperativeDao.getAll();
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Cooperative cooperative)
        {
            cooperativeDao.Add(cooperative);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Cooperative cooperative)
        {
            cooperativeDao.Update(cooperative);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Cooperative cooperative)
        {
            var check = eventDao.getByCooperative(cooperative.idCooperative);
            if (check.Count == 0)
            {
                cooperativeDao.Delete(cooperative.idCooperative);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}