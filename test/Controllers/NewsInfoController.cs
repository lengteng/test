using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class NewsInfoController : Controller
    {
        // GET: NewsInfo
        public ActionResult Index()
        {
            NewsEntities myContext = new Models.NewsEntities();

            //var list = from n in myContext.NewsInfo join m in myContext.NewsType
            //           on n.nTid equals m.tid 
            //select new
            //           {  Ntitle=m.nTitle,
            //              Ttitle=n.tTitle 
            //           } ;

            ////多from语句in后面一定要是一个集合类型的对象才可以连接
            //var list = from n in myContext.NewsType
            //           from m in n.NewsInfo
            //           select new
            //           {  Ntitle=m.nTitle,
            //              Ttitle=n.tTitle 
            //           };

            var list = from n in myContext.NewsInfo
                       select new NewsTypeViewModel
                       {
                           Ntitle = n.nTitle,
                           Ttitle = n.NewsType.tTitle
                       };
            return View(list);
        }
    }
}