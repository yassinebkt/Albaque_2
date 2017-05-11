using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Albaque_2.Models;
using System.Data.Entity;

namespace Albaque_2.DAL
{
    public class DalChiffrage
    {
        private ApplicationDbContext bdd;
        
        public DalChiffrage()
        {
            bdd = new ApplicationDbContext();
        }

        public DalChiffrage(ApplicationDbContext context)
        {
            bdd = context;
        }

        //Get the user Id by Name
        public string GetUserId()
        {
          
            var id = bdd.Users.FirstOrDefault(u => u.UserName == System.Web.HttpContext.Current.User.Identity.Name).Id;
            return id;
        }

        //Get all the Chiffrage
        public List<Chiffrage> GetListDesChiffrages()
        {
            return bdd.Chiffrages.ToList();
        }
        //Get all the Chiffrage with attribute
        public List<Chiffrage> GetListDesChiffragesAtt()
        {
            return bdd.Chiffrages.Include(p => p.projet).ToList();
        }
        //Get all the Chiffrage for the user with the Id
        public List<Chiffrage> GetListDesChiffragessWithUserId()
        {
            var id = GetUserId();
            return bdd.Chiffrages.Where(n => n.UserId == id).ToList();
        }
        //Get all the Chiffrage with attribute for the user with the Id
        public List<Chiffrage> GetListDesChiffragessWithUserIdAtt()
        {
            var id = GetUserId();
            var chiffrage = bdd.Chiffrages.Where(n => n.UserId == id).Include(p => p.projet).ToList();
            return chiffrage;
        }

        //Get Chiffrage by ID
        public Chiffrage GetChiffrageById(int? id)
        {
            var iduser = GetUserId();
            var chiffrage = bdd.Chiffrages.Where(n => n.UserId == iduser).FirstOrDefault(u => u.Id == id);
            //var iduser = GetUserId();
            //if (chiffrage.UserId == iduser)
                return chiffrage;
            //else
            //    return null;
        }

        //Get Chiffrage by name
        public Chiffrage GetChiffrageByName(string name)
        {
            var chiffrage = bdd.Chiffrages.FirstOrDefault(u => u.nom == name);
            var iduser = GetUserId();
            if (chiffrage.UserId == iduser)
                return chiffrage;
            else
                return null; 
        }

        //Delete Chiffrage by ID

        public void DeleteChiffrageById(int? id)
        {
            Chiffrage chiffrage = bdd.Chiffrages.Find(id);
            bdd.Chiffrages.Remove(chiffrage);
            //foreach (var m in bdd.Chiffrages_Taches.Where(f => f.ChiffrageId == id))
            //{
            //    bdd.Chiffrages_Taches.Remove(m);
            //}
            bdd.SaveChanges();
        }

        //Delete Tache related to a Chiffrage by ID

        public void DeleteTacheChiffrageById(int? id)
        {
            Chiffrage_Tache chiffTache = bdd.Chiffrages_Taches.Find(id);
            bdd.Chiffrages_Taches.Remove(chiffTache);

            bdd.SaveChanges();
        }

        //Create new Chiffrage

        public int AddChiffrage(Chiffrage chiffrage)
        {
            chiffrage.Date_Creation = DateTime.Now;
            chiffrage.UserId = GetUserId();
            bdd.Chiffrages.Add(chiffrage);
            bdd.SaveChanges();
            return chiffrage.Id;

        }

        //Create new Chiffrage , AAdd Taches to Chiffrage

        public void AddTachesToChiffrage(int IdChffrage, int IdTache)
        {
            Chiffrage_Tache chiffTache = new Chiffrage_Tache()
            {
                ChiffrageId = IdChffrage,
                TacheId = IdTache,
                ordre = 124,
                nom = "test"
            };
            bdd.Chiffrages_Taches.Add(chiffTache);
            bdd.SaveChanges();

        }


        


        //Set Chiffrage (with new profile name)

        //Create new user

        //Delete user by ID
        //Delete user by Name


        ////
        // Tache
        /////
        //Get all the Taches
        public List<Tache> GetListDesTaches()
        {
            return bdd.Taches.ToList();
        }

        //Get all the Taches Including Categoris and Complexite and Technologies
        public List<Tache> GetListDesTachesAtt()
        {
            var tache = bdd.Taches
                .Include(com => com.complexite)
                .Include(cat => cat.categorie)
                .Include(tec => tec.technologie).ToList();

            return tache;
        }

        //Get Taches by ID
        public Tache GetTachesById(int? id)
        {
            return bdd.Taches.FirstOrDefault(u => u.Id == id);
        }

        //Get Taches by name
        public List<Tache> GetTachesByName(string name)
        {
            return bdd.Taches.Where(c => c.nom.Contains(name))
                .Include(c => c.categorie)
                .Include(c => c.complexite)
                .Include(c => c.technologie)
                .ToList();
        }


        //Delete Tache by ID

        public void DeleteTacheById(int? id)
        {
            Tache tache = bdd.Taches.Find(id);
            bdd.Taches.Remove(tache);
            bdd.SaveChanges();
        }





        ////
        // Projet
        /////
        //Get all the Projets
        public List<Projet> GetListDesProjets()
        {
            return bdd.Projets.ToList();
        }


        ////
        // Chiffrage_Tache
        /////
        //Get all the Chiffrage_Tache
        public List<Chiffrage_Tache> GetListDesChiffrage_Tache()
        {
            return bdd.Chiffrages_Taches.ToList();
        }

        //Get all the Chiffrage_Tache by Id
        public List<Chiffrage_Tache> GetListDesChiffrage_TacheById(int? id)
        {
            return bdd.Chiffrages_Taches.Where(ch => ch.ChiffrageId == id).ToList();
        }

        //Get all the Chiffrage_Tache by Id
        public Chiffrage_Tache GetChiffrage_TacheById(int? id)
        {
            return bdd.Chiffrages_Taches.Find(id);
        }

        

    }
}