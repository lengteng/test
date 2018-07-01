using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class UserInfoCrudController : Controller
    {
        NewsEntities myContext = new NewsEntities();
        // GET: UserInfoCrud
        public ActionResult Index()
        {

            var list = myContext.UserInfo;
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserInfo userinfo)
        {


            myContext.UserInfo.Add(userinfo);
            int result = myContext.SaveChanges();
            if (result > 0)
            { return RedirectToAction("index"); }
            else
            { return RedirectToAction("Add"); }


        }

        public ActionResult Edit(int id)
        {
            ViewData.Model = myContext.UserInfo
                 .Where(n => n.UID == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserInfo us)
        {
            UserInfo user = myContext.UserInfo.Where(n => n.UID == us.UID).First();
            user.UName = us.UName;
            int result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("index");
            else
                return RedirectToAction("Edit", "UserinfoCrud", new { id = us.UID });
        }

        public ActionResult Remove(int id)
        {
            var us = myContext.UserInfo.Where(n => n.UID == id).First();
            myContext.UserInfo.Remove(us);
            myContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}