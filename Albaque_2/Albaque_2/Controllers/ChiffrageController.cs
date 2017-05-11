using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Albaque_2.DAL;
using System.Net;
using Albaque_2.Models;
using Albaque_2.ViewModels;
using Albaque_2.Filters;
using System.Web.Routing;
using System.Web.Script.Services;

namespace Albaque_2.Controllers
{
    [NoCache]
    [Authorize]
    public class ChiffrageController : Controller
    {
        private DalChiffrage dal = new DalChiffrage();
        //
        // GET: /Chiffrage/
        public ActionResult Index()
        {
            var chiffrage = dal.GetListDesChiffragessWithUserIdAtt();
            return View(chiffrage);
        }

        // GET: /Chiffrage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chiffrage chiffrage = dal.GetChiffrageById(id);

            if (chiffrage == null)
            {
                return new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }

            var projet = dal.GetListDesProjets();

            var chiffrage_Tache = dal.GetListDesChiffrage_TacheById(id);

            var taches = dal.GetListDesTaches();

            var viewmodel = new ChiffrageViewModel
            {
                Chiffrage = chiffrage,
                ChiffrageTaches = chiffrage_Tache,
                taches = taches,
                projets = projet

            };
            return View(viewmodel);

        }

        // GET: /Chiffrage/Create
        public ActionResult Create()
        {
            var projets = dal.GetListDesProjets();

            var viewModel = new ChiffrageViewModel
            {
                projets = projets
            };
            return View(viewModel);
        }

        
        // POST: /Chiffrage/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public ActionResult Create([Bind(Include="Id,nom,description,charge")] Tache tache)
        //public ActionResult Create(ChiffrageViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int idChiffrage = dal.AddChiffrage(viewModel.Chiffrage);
        //        return RedirectToAction("Index");
        //    }
        //    var errors = ModelState
        //       .Where(x => x.Value.Errors.Count > 0)
        //       .Select(x => new { x.Key, x.Value.Errors })
        //       .ToArray();

        //    return View(viewModel.tache);
        //}

        public class viewmodel
        {
            public int projetId { get; set; }
            public string nomChiffrage { get; set; }
            public string versionChiffrage { get; set; }
            public string tachesIds { get; set; }
        }

        [HttpPost,ActionName("Create")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,nom,description,charge")] Tache tache)
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
        public ActionResult Createtemp(viewmodel viewmodel)
        {
            if (ModelState.IsValid)
            {
                Chiffrage chiff = new Chiffrage()
                {
                    nom = viewmodel.nomChiffrage,
                    version = viewmodel.versionChiffrage,
                    ProjetId = viewmodel.projetId

                };
                int idChiffrage = dal.AddChiffrage(chiff);

                //foreach (var id in viewmodel.tachesIds)
                //{
                //    dal.AddTachesToChiffrage(idChiffrage, id);
                //}

                string sub = viewmodel.tachesIds.Substring(0, viewmodel.tachesIds.Length - 1);
                var list = sub.Split('-').Select(Int32.Parse).ToList();

                foreach (var id in list)
                {
                    dal.AddTachesToChiffrage(idChiffrage, id);
                }

                return Json(Url.Action("Index", "Chiffrage"));
            }
            
            var errors = ModelState
               .Where(x => x.Value.Errors.Count > 0)
               .Select(x => new { x.Key, x.Value.Errors })
               .ToArray();

            return View(viewmodel);
        }


        //// GET: /Tache/Delete/5
        //public ActionResult DeleteChiffTache(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Chiffrage_Tache chiffTache = dal.GetChiffrageById(id);
        //    if (chiffTache == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(chiffTache);
        //}

        //// POST: /Tache/Delete/5
        //[HttpPost, ActionName("DeleteChiffTache")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Chiffrage_Tache chiffTache = dal.GetChiffrage_TacheById(id);
        //    var chiff = dal.GetChiffrageById(chiffTache.ChiffrageId);
        //    dal.DeleteTacheChiffrageById(id);
        //    return RedirectToAction("Details", new { id = chiff.Id });
        //}


        // GET: /Tache/DeleteDeleteChiffTache/5
        // Delete the Tache that is related to a specifique Chiffrage from the Chiffrage_Tache Table
        public ActionResult DeleteChiffTache(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chiffrage_Tache chiffTache = dal.GetChiffrage_TacheById(id);
            if (chiffTache == null)
            {
                return HttpNotFound();
            }
            dal.DeleteTacheChiffrageById(id);
            return View(chiffTache);
        }

        // POST: /Tache/Delete/5
        [HttpDelete, ActionName("DeleteChiffTache")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteChiffTacheConfirmed(int id)
        {
            Chiffrage_Tache chiffTache = dal.GetChiffrage_TacheById(id);
            var chiff = dal.GetChiffrageById(chiffTache.ChiffrageId);
            dal.DeleteTacheChiffrageById(id);
            return RedirectToAction("Details", new { id = chiff.Id });
        }

        // GET: /Tache/Delete/5
        // Delete Chiffrage
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chiffrage chiffrage = dal.GetChiffrageById(id);
            if (chiffrage == null)
            {
                return HttpNotFound();
            }
            dal.DeleteChiffrageById(id);
            return View(chiffrage);
        }

        // POST: /Tache/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dal.DeleteChiffrageById(id);
            return RedirectToAction("Index");
        }
  
        public JsonResult GetTache(string query = null)
        {
            List<Tache> tachesQuery = new List<Tache>();
            if (!String.IsNullOrWhiteSpace(query))
               tachesQuery = dal.GetTachesByName(query);
               

            return Json(tachesQuery.Select(p => new { 
                Id = p.Id,
                nom = p.nom,
                categorie = p.categorie.nom,
                description = p.description,
                technologie = p.technologie.nom,
                complexite = p.complexite.nom,
                charge = p.charge
            }), JsonRequestBehavior.AllowGet);
        }
	}
}