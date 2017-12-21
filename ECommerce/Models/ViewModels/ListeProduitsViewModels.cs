using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class ListeProduitsViewModels
    {
        private List<List<Produit>> pages;
        private PaginationInfo paginationInfo;

        public ListeProduitsViewModels(List<Produit> produits, PaginationInfo info)
        {
            int i = 0, j = 0;
            pages = new List<List<Produit>>();
            paginationInfo = info;
            pages.Add(new List<Produit>());
            foreach(Produit p in produits)
            {
                pages[i].Add(p);
                j++;
                if(j == paginationInfo.ProduitsParPage)
                {
                    i++;
                    j = 0;
                    pages.Add(new List<Produit>());
                }
            }
        }

        public List<Produit> GetPage(int index)
        {
            if(index < pages.Count())
            {
                paginationInfo.PageCourante = index;
                return pages[index];
            }
            return new List<Produit>();
        }
    }
}
