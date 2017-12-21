using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Models;
using ECommerce.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProduitController : Controller
    {
        private IProductRepository repos;

        public int NombreProduitParPages { get; set; } = 2;

        public ProduitController(IProductRepository r)
        {
            repos = r;
        }

        public ViewResult List(int numeroPage)
        {
            if (numeroPage != 0)
            {
                int nbPages = repos.Produits.Count() / NombreProduitParPages, i = 0, j = 0;
                List<List<Produit>> produits = new List<List<Produit>>();
                produits.Add(new List<Produit>());
                foreach (Produit p in repos.Produits)
                {
                    produits[i].Add(p);
                    j++;
                    if (j == NombreProduitParPages)
                    {
                        i++;
                        j = 0;
                        produits.Add(new List<Produit>());
                    }
                }
                return View("ProduitView", produits[numeroPage - 1]);
            }
            return View("ProduitView", repos.Produits.ToList<Produit>());
        }
    }
}
