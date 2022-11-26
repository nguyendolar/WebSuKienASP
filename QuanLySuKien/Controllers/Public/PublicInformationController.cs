using QuanLySuKien.Daos;
using QuanLySuKien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySuKien.Controllers.Public
{
    public class PublicInformationController : Controller
    {
        // GET: PublicInformation
        PositionDao positionDao = new PositionDao();
        InformationDao informationDao = new InformationDao();
        public ActionResult Index(string msg)
        {
            User user = (User)Session["USER"];
            Information information = informationDao.GetInformationByIdUser(user.idUser);
            ViewBag.Msg = msg;
            ViewBag.positions = positionDao.getAll();
            if(information != null)
            {
                ViewBag.information = information;
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Information evt, FormCollection form)
        {
            User user = (User)Session["USER"];
            int idInformation = Int32.Parse(form["idInformation"]);
            evt.idInformation = idInformation;
            Information information = informationDao.GetInformationByIdUser(user.idUser);
            evt.idUser = user.idUser;
            if(information == null)
            {
                informationDao.Add(evt);
            }
            else
            {
                informationDao.Update(evt);
            }
           
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}