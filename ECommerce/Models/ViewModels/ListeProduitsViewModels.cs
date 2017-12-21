using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ListeProduitsViewModels
    {
        private List<Produit> produits;
        private PaginationInfo pagination;

        public ListeProduitsViewModels(PaginationInfo info)
        {
            pagination = info;
        }

        public void Update(List<Produit> p)
        {
            produits = p;
        }

        public PaginationInfo GetPaginationInfo()
        {
            return pagination;
        }

        public List<Produit> GetListeProduit()
        {
            return produits;
        }
    }
}
