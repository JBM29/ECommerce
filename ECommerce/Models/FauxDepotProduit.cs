using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;

namespace ECommerce.Repository
{
    public class FauxDepotProduit : IProductRepository
    {
        public IQueryable<Produit> Produits => new List<Produit>() {
            new Produit()
            {
                Nom = "Claquette",
                Description = "Claquette de plage",
                Prix = 10M,
                ProductID = 5674343,
                Categorie = "Article de plage",
            },
            new Produit()
            {
                Nom = "Chaussette",
                Description = "Chaussette de sport",
                Prix = 5M,
                ProductID = 3892430,
                Categorie = "Vetements",
            }
        }.AsQueryable<Produit>();
    }
}
