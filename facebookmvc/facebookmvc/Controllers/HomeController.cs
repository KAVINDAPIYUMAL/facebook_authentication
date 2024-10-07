using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace facebookmvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id= "3935738490038324",
                redirect_uri= "https://localhost:44309/Home/FaceBookRedirect",
                scope= "public_profile,email"

            });


            ViewBag.Url = loginUrl; 


            return View();
        }


        public ActionResult FaceBookRedirect(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("/oauth/access_token", new
            {
                client_id = "3935738490038324",
                client_secret = "e9c5f6af58e6d805296553760824865c",
                redirect_uri = "https://localhost:44309/Home/FaceBookRedirect",
                code = code
            });
            fb.AccessToken = result.access_tocken;
            dynamic me = fb.Get("/me?fields=name, email");
            string name = me.name;
            string email = me.email;
            return RedirectToAction("Index");
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