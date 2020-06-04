using System.Web.Mvc;
using SignalRProgressBarSimpleExample.Util;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SignalRProgressBarSimpleExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public JsonResult LongRunningProcess(int count)
        {
            string filepath = ConfigurationManager.AppSettings["filepath"].ToString();
            string[] filecontent = System.IO.File.ReadAllLines(filepath);
            int itemsCount = filecontent.Length;
            Thread.Sleep(1000);
            Functions.SendProgress("Process in progress...", count, itemsCount);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(bool? copy, bool? move)
        {
            try
            {
                string filepath = ConfigurationManager.AppSettings["filepath"].ToString();

                string sourcepath = ConfigurationManager.AppSettings["source"].ToString();

                string destinationpath = ConfigurationManager.AppSettings["destination"].ToString();

                string[] filecontent = System.IO.File.ReadAllLines(filepath);
                List<string> files = filecontent.ToList();
                HttpContext.Application["RecordsTotal"] = filecontent.Length;
                HttpContext.Application["RecordsProcessed"] = 0;
                int count = 0;
                if (copy != null)
                {
                    foreach (string fc in filecontent)
                    {               
                        System.IO.File.Copy(sourcepath + "\\" + fc, destinationpath + "\\" + fc);
                        count++;
                        LongRunningProcess(count);
                    }
                }
                else
                {
                    foreach (string fm in filecontent)
                    {
                        System.IO.File.Move(sourcepath + "\\" + fm, destinationpath + "\\" + fm);
                        count++;
                        LongRunningProcess(count);
                    }
                }                
                return Json(new { Result = "All files Copied/moved..." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Exception = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}