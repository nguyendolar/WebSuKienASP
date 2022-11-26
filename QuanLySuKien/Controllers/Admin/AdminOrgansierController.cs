using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Admin
{
    public class AdminOrgansierController : Controller
    {
        OrgansierDao organsierDao = new OrgansierDao();
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
                ViewBag.List = organsierDao.getAll();
                return View();
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Organiser organiser)
        {
            organsierDao.Add(organiser);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Organiser organiser)
        {
            organsierDao.Update(organiser);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Delete(Organiser organiser)
        {
            var check = eventDao.getByOrgansier(organiser.idOrganiser);
            if (check.Count == 0)
            {
                organsierDao.Delete(organiser.idOrganiser);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }
    }
}