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
                int nbPages = repos.Produits.Count() / NombreProduitParPages;
                if(numeroPage <= nbPages)
                {
                    List<Produit> produits = repos.Produits.ToList();
                    return View("ProduitView", repos.Produits.Where(p => p.ProductID >= produits[(numeroPage - 1) * NombreProduitParPages].ProductID && p.ProductID <= produits[((numeroPage - 1) * NombreProduitParPages + NombreProduitParPages) -1].ProductID).ToList());
                }
                else
                {
                    return View("404");
                }
            }
            return View("ProduitView", new List<Produit>());
        }
    }
}
