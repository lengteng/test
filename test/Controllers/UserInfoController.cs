using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            NewsEntities myContext = new NewsEntities();
            //查询语法
            // var list = from n in myContext.UserInfo
            //           select n;
            //单条件查询
            //var list = from n in myContext.UserInfo
            //           where n.UID >2
            //           select n;
            //多条件查询
            //var list = from n in myContext.UserInfo
            //           where n.UID > 2 && n.UName.Length >5
            //           select n;
            //var list = from n in myContext.UserInfo
            //           where n.UID > 2 && n.UName.Contains ("a")
            //           select n;
            //查询单列
            //var list = from n in myContext.UserInfo
            //         select n.UID;
            //查询多列
            //var list = from n in myContext.UserInfo
            //           select new UserInfoViewModel
            //           { Uid = n.UID,
            //             UName=n.UName 
            //           };
            //分页
            var list = from n in myContext.UserInfo
                       select n;
            list = list.OrderByDescending(n => n.UID).Skip(2).Take(2);//注意这里必须要排序
            //方法语法
            //var list = myContext.UserInfo.Select(u=>u);

            return View(list);
        }

        public ActionResult Index1()
        {
            NewsEntities myContext = new Models.NewsEntities();
            //基本查询
            // var list = myContext.UserInfo.Select(n=>n);

            //单条件查询
            //list = list.Where(n=>n.UID >2);

            //多条件查询
            // list = list.Where(n =>( n.UID > 2) &&(n.UName .Contains ("ai")));
            //list = list.Where(n => n.UID > 2)
            //    .Where(n => n.UName.Contains("ai"));
            //条件或的时候只能用第一种，与的时候两种都可以

            //查询单列
            //  var list = myContext.UserInfo.Select(n => n.UID ) ;

            //查询多列
            var list = myContext.UserInfo.Select(n =>
              new UserInfoViewModel
              {
                  Uid = n.UID,
                  UName = n.UName
              }
                );
            return View(list);
        }
    }
}