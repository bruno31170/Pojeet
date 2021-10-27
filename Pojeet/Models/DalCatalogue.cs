using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Pojeet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pojeet.Models
{
    public class DalCatalogue : IDalCatalogue
    {
        private BddContext _context;

        public DalCatalogue()
        {
            _context = new BddContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<Annonce> ObtientAnnonce()
        {
            List<Annonce> listeAnnonce = this._context.Annonce.Include(m => m.profil).ToList();
            return listeAnnonce;
        }

        public CompteConsumer ObtientConsumer(int id)
        {
            CompteConsumer consumer = this._context.CompteConsumer.FirstOrDefault(c => c.Id == id);
            return consumer;
        }




        public List<Annonce> RechercherAnnonce(ProfilViewModel uvm)


        {
            List<Annonce> rechercheAnnonce = new List<Annonce>();
            List<Annonce> annonce = ObtientAnnonce();

            string MotRechercher = uvm.Recherche.Rechercher;
            string Departement = uvm.Recherche.Localisation;
            string TypeRecherche = uvm.Recherche.TypeDeRecherche.ToString();
            string CategorieRecherche = uvm.Recherche.CategorieDeRecherche.ToString();
            string TriRecherche = uvm.Recherche.Tri.ToString();



            foreach (var item in annonce)
            {
                string TypeAnnonce = item.TypeDeAnnonce.ToString();
                string CategorieAnnonce = item.CategorieDeAnnonce.ToString();


                if (CategorieAnnonce == CategorieRecherche)
                {
                    if (MotRechercher != null && Departement != null && TypeAnnonce == TypeRecherche)
                    {
                        if (item.TitreAnnonce.Contains(MotRechercher) && item.Localisation.Contains(Departement))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher != null && Departement == null && TypeAnnonce == TypeRecherche)
                    {
                        if (item.TitreAnnonce.Contains(MotRechercher))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher == null && Departement != null && TypeAnnonce == TypeRecherche)
                    {
                        if (item.Localisation.Contains(Departement))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher == null && Departement == null && TypeAnnonce == TypeRecherche)
                    {
                        if (TypeAnnonce == TypeRecherche)
                            rechercheAnnonce.Add(item);
                    }
                }
                if (CategorieRecherche == null)
                {
                    if (MotRechercher != null && Departement != null && TypeAnnonce == TypeRecherche)
                    {
                        if (item.TitreAnnonce.Contains(MotRechercher) && item.Localisation.Contains(Departement))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher != null && Departement == null && TypeAnnonce == TypeRecherche)
                    {
                        if (item.TitreAnnonce.Contains(MotRechercher))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher == null && Departement != null && TypeAnnonce == TypeRecherche)
                    {
                        if (item.Localisation.Contains(Departement))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher == null && Departement == null && TypeAnnonce == TypeRecherche)
                    {
                        if (TypeAnnonce == TypeRecherche)
                            rechercheAnnonce.Add(item);
                    }
                }

            }

            if (TriRecherche.Equals("Notes"))
            {
                rechercheAnnonce = rechercheAnnonce.OrderByDescending(x => x.profil.NoteMoyenne).ToList();
            }

            if (TriRecherche.Equals("Dates"))
            {
                rechercheAnnonce = rechercheAnnonce.OrderByDescending(x => x.DateParution).ToList();
            }
            return rechercheAnnonce;
        }
    }
}
