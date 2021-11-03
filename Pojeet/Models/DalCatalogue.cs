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
            List<Annonce> listeAnnonce = this._context.Annonce.Include(m => m.profil).OrderByDescending(c=> c.DateParution).ToList();
            return listeAnnonce;
        }

        public CompteConsumer ObtientConsumer(int id)
        {
            CompteConsumer consumer = this._context.CompteConsumer.FirstOrDefault(c => c.Id == id);
            return consumer;
        }


        public List<CompteConsumer> ProfilsMieuxNotes()
        {
            List<Profil> Liste = this._context.Profil.Where(c=>c.NoteMoyenne!=0).OrderByDescending(c => c.NoteMoyenne).ToList();
            List<CompteConsumer> liste = new List<CompteConsumer>();
            foreach (var profil in Liste)
            {
                CompteConsumer compte = this._context.CompteConsumer.Where(c => c.ProfilId == profil.Id).Include(c=> c.Profil.ListeAvis).FirstOrDefault();

                liste.Add(compte); }
            return liste;
        }
        public List<Annonce> RechercherAnnonce(ProfilViewModel uvm)


        {
            List<Annonce> rechercheAnnonce = new List<Annonce>();
            List<Annonce> annonce = ObtientAnnonce();
            string MotRechercher = "";
            string Departement = "";
            if (uvm.Recherche.Rechercher != null)
            {
                MotRechercher = uvm.Recherche.Rechercher.ToLower();
            }
            else
            {
                MotRechercher = uvm.Recherche.Rechercher;
            }
            if (uvm.Recherche.Localisation != null)
            {
                Departement = uvm.Recherche.Localisation.ToString();
            }
            else
            {
                Departement = uvm.Recherche.Localisation;
            }
            
            string TypeRecherche = uvm.Recherche.TypeDeRecherche.ToString();
            string CategorieRecherche = uvm.Recherche.CategorieDeRecherche.ToString();
            string TriRecherche = uvm.Recherche.Tri.ToString();



            foreach (var item in annonce)
            {
                string TypeAnnonce = item.TypeDeAnnonce.ToString();
                string CategorieAnnonce = item.CategorieDeAnnonce.ToString();
                string TitreAnnonce = item.TitreAnnonce.ToString().ToLower();
                string DepartementRecherche = item.Localisation.ToString();

                if (TypeRecherche.Equals("Type")) 
                { 
                    if (CategorieAnnonce == CategorieRecherche)
                {
                    if (MotRechercher != null && Departement != null)
                    {
                        if (TitreAnnonce.Contains(MotRechercher) && item.Localisation.Contains(Departement))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher != null && Departement == null)
                    {
                        if (TitreAnnonce.Contains(MotRechercher))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher == null && Departement != null)
                    {
                        if (item.Localisation.Contains(Departement))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher == null && Departement == null)
                    {
                        if (TypeAnnonce == TypeRecherche)
                            rechercheAnnonce.Add(item);
                    }
                }
                    if (CategorieRecherche.Equals("Catégorie"))
                {
                    if (MotRechercher != null && Departement != null)
                    {
                        if (TitreAnnonce.Contains(MotRechercher) && item.Localisation.Contains(Departement))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher != null && Departement == null)
                    {
                        if (TitreAnnonce.Contains(MotRechercher))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher == null && Departement != null)
                    {
                        if (item.Localisation.Contains(Departement))
                            rechercheAnnonce.Add(item);
                    }
                    if (MotRechercher == null && Departement == null)
                    {
                        rechercheAnnonce.Add(item);
                    }
                }
                }
                else
                {
                    if (CategorieAnnonce == CategorieRecherche)
                    {
                        if (MotRechercher != null && Departement != null && TypeAnnonce == TypeRecherche)
                        {
                            if (TitreAnnonce.Contains(MotRechercher) && item.Localisation.Contains(Departement))
                                rechercheAnnonce.Add(item);
                        }
                        if (MotRechercher != null && Departement == null && TypeAnnonce == TypeRecherche)
                        {
                            if (TitreAnnonce.Contains(MotRechercher))
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
                    if (CategorieRecherche.Equals("Catégorie"))
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
            }

            if (TriRecherche.Equals("Notes"))
            {
                rechercheAnnonce = rechercheAnnonce.OrderBy(x => x.profil.NoteMoyenne!=0).ThenByDescending(x => x.profil.NoteMoyenne).ToList();
            }

            if (TriRecherche.Equals("Dates"))
            {
                rechercheAnnonce = rechercheAnnonce.OrderByDescending(x => x.DateParution).ToList();
            }
            return rechercheAnnonce;
        }

        public Conversation Contact(int id1, int id2)
        {
            Conversation conversation = _context.Conversation.Where(c => c.Auteur_Message.ProfilId == id1 && c.Annonce.Id == id2).FirstOrDefault();
            return conversation;
        }
    }
}
