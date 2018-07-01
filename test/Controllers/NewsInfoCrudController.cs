using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using System.Data.Entity;

namespace test.Controllers
{
    public class NewsInfoCrudController : Controller
    {
        NewsEntities myContext = new Models.NewsEntities();
        // GET: NewsInfoCrud
        public ActionResult Index()
        {
            ViewData.Model = from newsinfo in myContext.NewsInfo
                             select newsinfo;
            return View();
        }
        public ActionResult Edit(int id)
        {


            var list = (from ns in myContext.NewsInfo
                        where ns.nid == id
                        select ns).FirstOrDefault();
            var list1 = myContext.NewsType.Select(u => u);

            var selectList = new SelectList(list1, "tid", "tTitle", list.nTid);
            ViewBag.Type = selectList;
            return View(list);
        }
        [HttpPost]
        public ActionResult Edit(NewsInfo newsinfo)
        {
            NewsInfo ns = myContext.NewsInfo.Where(n => n.nid == newsinfo.nid).First();
            ns.nid = newsinfo.nid;
            ns.nTitle = newsinfo.nTitle;
            ns.nTid = newsinfo.nTid;
            myContext.SaveChanges();
            return RedirectToAction("Index");

            // 使用对象状态方式进行修改
            //myContext.NewsInfo.Attach(newsinfo);
            //myContext.Entry(newsinfo).State = EntityState.Modified;
            //myContext.SaveChanges();
            //return RedirectToAction("Index");

            ////使用属性状态方式进行修改
            //myContext.NewsInfo.Attach(newsinfo);
            //myContext.Entry(newsinfo).Property("nTitle").IsModified = true;
            //myContext.Entry(newsinfo).Property("nTitle").CurrentValue = newsinfo.nTitle;
            //myContext.SaveChanges();
            //return RedirectToAction("Index");
        }
        public ActionResult Add()
        {
            var list = myContext.NewsType.Select(u => u);

            var selectList = new SelectList(list, "tid", "tTitle", "1");

            //ViewData["Type"] = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Selected = false,Text = "北京",Value="1"},
            //    new SelectListItem(){Selected = true,Text = "上海",Value="2"},
            //    new SelectListItem(){Selected = false,Text = "广州",Value="3"}
            //};
            ViewBag.Type = selectList;

            return View();
        }
        [HttpPost]
        public ActionResult Add(NewsInfo newsinfo)
        {
            //string na = newsinfo.nTitle;
            //int i = newsinfo.nTid;
            myContext.NewsInfo.Add(newsinfo);
            int result = myContext.SaveChanges();
            if (result > 0)
            { return RedirectToAction("index"); }
            else
            { return RedirectToAction("Add"); }


        }
        public ActionResult Remove(int id)
        {
            var us = myContext.NewsInfo.Where(n => n.nid == id).First();
            myContext.NewsInfo.Remove(us);
            myContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}