using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;

namespace ECommerce.Repository
{
    public interface IProductRepository
    {
        IQueryable<Produit> Produits{ get; }
    }
}
