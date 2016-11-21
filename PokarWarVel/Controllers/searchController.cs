using MarvelApi;
using MarvelApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokarWarVel.Controllers
{
    public class searchController : Controller
    {
        // GET: search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Results(string search)
        {

            MarvelRequester r = new MarvelRequester();
            List<Characters> LAliste = r.GetCharacters(limit: 100);
            //filtre

            //List<Characters> trouve = new List<Characters>();

            //foreach (Characters Current in LAliste)
            //{
            //     if (Current.name==search)
            //     {

            //         trouve.Add(Current);

            //     }
            //}


            //return View(trouve);

            //LINQ

            return View(LAliste.Where(l => l.name.Contains(search)));


        }
    }
}