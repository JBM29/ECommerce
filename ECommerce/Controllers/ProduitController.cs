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

        public ViewResult List()
        {
                int numeroPage = Convert.ToInt32(HttpContext.Request.Query["productPage"]);
                int nbPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(repos.Produits.Count()) / Convert.ToDouble(model.PaginationInfo.ProduitsParPage)));
                if (numeroPage == 0)
                {
                    numeroPage = 1;
                }
                if (numeroPage <= nbPages)
                {
                    List<Produit> produits = repos.Produits.ToList();
                    model.PaginationInfo.PageCourante = numeroPage;
                    model.Update(repos.Produits.Where(p => p.ProductID >= produits[(numeroPage - 1) * model.PaginationInfo.ProduitsParPage].ProductID && p.ProductID <= produits[((numeroPage - 1) * model.PaginationInfo.ProduitsParPage + model.PaginationInfo.ProduitsParPage) - 1].ProductID).ToList());
                    return View("ProduitView", model);
                }
                else
                {
                    return View("404");
                }
        }
    }
}
