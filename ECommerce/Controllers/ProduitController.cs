using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using ECommerce.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProduitController : Controller
    {
        private IProductRepository repos;

        private ListeProduitsViewModels model;

        public ProduitController(IProductRepository r)
        {
            repos = r;
            PaginationInfo info = new PaginationInfo
            {
                NombreProduits = r.Produits.Count(),
                PageCourante = 1,
                ProduitsParPage = 2
            };
            model = new ListeProduitsViewModels(info);
        }

        public ViewResult List(int numeroPage)
        {
            if (numeroPage != 0)
            {
                int nbPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(repos.Produits.Count()) / Convert.ToDouble(model.GetPaginationInfo().ProduitsParPage)));
                if(numeroPage <= nbPages)
                {
                    List<Produit> produits = repos.Produits.ToList();
                    model.GetPaginationInfo().PageCourante = numeroPage;
                    model.Update(repos.Produits.Where(p => p.ProductID >= produits[(numeroPage - 1) * model.GetPaginationInfo().ProduitsParPage].ProductID && p.ProductID <= produits[((numeroPage - 1) * model.GetPaginationInfo().ProduitsParPage + model.GetPaginationInfo().ProduitsParPage) - 1].ProductID).ToList());
                    return View("ProduitView", model);
                }
                else
                {
                    return View("404");
                }
            }
            return View("ProduitView", null);
        }
    }
}
