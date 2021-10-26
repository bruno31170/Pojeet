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
           // string TypeRecherche = uvm.Recherche.TypeDeRecherche;


            foreach (var item in annonce)
            {   if (MotRechercher != null && Departement != null)
                {
                    if (item.TitreAnnonce.Contains(MotRechercher) && item.Localisation.Contains(Departement) && item.TypeDeAnnonce.Equals(uvm.Recherche.TypeDeRecherche))
                        rechercheAnnonce.Add(item);
                }
                if (MotRechercher != null && Departement == null && item.TypeDeAnnonce.Equals(uvm.Recherche.TypeDeRecherche))
                {
                    if (item.TitreAnnonce.Contains(MotRechercher))
                        rechercheAnnonce.Add(item);
                }
                if (MotRechercher == null && Departement != null && item.TypeDeAnnonce.Equals(uvm.Recherche.TypeDeRecherche))
                {
                    if (item.Localisation.Contains(Departement))
                        rechercheAnnonce.Add(item);
                }
                if (MotRechercher == null && Departement == null)
                {
                    if (item.TypeDeAnnonce.Equals(uvm.Recherche.TypeDeRecherche))
                        rechercheAnnonce.Add(item);
                }

            }
            //rechercheAnnonce = this._context.Annonce.Include(m => m.profil).ToList();
            return rechercheAnnonce;

        }

        


    }
}
