using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ListeProduitsViewModels
    {
        private List<Produit> produits;
        public PaginationInfo PaginationInfo;

        public ListeProduitsViewModels(PaginationInfo info)
        {
            PaginationInfo = info;
        }

        public void Update(List<Produit> p)
        {
            produits = p;
        }

        public List<Produit> GetListeProduit()
        {
            return produits;
        }
    }
}
