using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _26FebbraioEs.Controllers
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

        public ActionResult Dipendente(Models.Dipendente dipendente)
        {

            List<Models.Dipendente> ListaDipendenti = new List<Models.Dipendente>();  

            ViewBag.Nome = dipendente.Nome;
            ViewBag.Cognome = dipendente.Cognome;
            ViewBag.Indirizzo = dipendente.Indirizzo;
            ViewBag.CodiceFiscale = dipendente.CodiceFiscale;
            ViewBag.Coniugato = dipendente.Coniugato;
            ViewBag.FigliACarico = dipendente.FigliACarico;
            ViewBag.Mansione = dipendente.Mansione;

            ListaDipendenti.Add(dipendente);

            return View();
        }
    }
}