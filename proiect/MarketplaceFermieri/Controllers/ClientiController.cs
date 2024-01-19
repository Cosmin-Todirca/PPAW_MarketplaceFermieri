using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MarketplaceFermieri.Controllers
{
    public class ClientiController : Controller
    {
        public ActionResult Index()//pentru API ai nevoie si de asa ceva
        {
            ViewBag.Title = "Pagina clientilor";

            return View();
        }
    }
}
