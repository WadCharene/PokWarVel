using MarvelApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokarWarVel.Controllers
{
    public class FicheEvalController : Controller
    {
        // GET: FicheEval
        public ActionResult Index(long id )
        {

            EvalModel E1 = new EvalModel();
            MarvelApi.MarvelRequester communicator = new MarvelApi.MarvelRequester();
            E1.MonHero = communicator.GetCharacterById(id);


            return View(E1);
        }
        [HttpPost]

        public ActionResult Index(long id,EvalModel Ev)
        {

            Ev.IdHero = id;
            Ev.TypeHero = "Marvel";
            if (Ev.save())
            {
                ViewBag.Msg = "Enregistré";
            }
            else
            {
                ViewBag.Error = "Erreur lors de l'enregistrement";
            }
            
            MarvelApi.MarvelRequester communicator = new MarvelApi.MarvelRequester();
            Ev.MonHero = communicator.GetCharacterById(id);

            return View(Ev);
        }
    }   
}