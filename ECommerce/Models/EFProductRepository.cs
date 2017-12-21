using System.Linq;
using ECommerce.Models;

namespace ECommerce.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Produit> Produits => context.Produits;
    }
}
