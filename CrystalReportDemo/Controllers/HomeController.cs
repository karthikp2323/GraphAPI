using CrystalReportDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrystalReportDemo.Controllers
{
    public class HomeController : Controller
    {
        CTLSEntities ctlsEntities = new CTLSEntities();
        public ActionResult UserList()
        {
            var userList = ctlsEntities.Inv_UserSecurities.Where(w => w.Active == true).ToList();

            var userListVM = userList.Select(x => new UserListViewModel()
            {
                UserId = x.UserId,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Active = x.Active,
                LastLogin = x.LastLogin.ToString()
            }).ToList();
            return View(userListVM);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}