using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using WebApplication4.Models;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string date)
        {
            string text = null;
            if (date==null)
            {
                date = DateTime.Now.Date.ToShortDateString();
            }
            text= Convert.ToDateTime(date).ToString("yyyy-MM-dd");

            WebClient wc = new WebClient();
            var url = "http://newsapi.org/v2/everything?q=uk" +
                                "&from=" + text +   "&to="+ text + "&sortBy=popularity&apiKey=df3685a393f046e3aa729dea77412939";
                
                var NewsString = wc.DownloadString(url);
            byte[] bytes = Encoding.Default.GetBytes(NewsString);
            NewsString = Encoding.UTF8.GetString(bytes);
            RootObject datalist = JsonConvert.DeserializeObject<RootObject>(NewsString);
           return View(datalist);
        }
    
    }
}