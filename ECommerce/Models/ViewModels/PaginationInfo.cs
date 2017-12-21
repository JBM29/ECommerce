using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class PaginationInfo
    {
        public int NombreProduits { get; }
        public int ProduitsParPage { get; }
        public int PageCourante { get; }

        public int GetCountOfPage()
        {
            return NombreProduits / ProduitsParPage;
        }
    }
}
