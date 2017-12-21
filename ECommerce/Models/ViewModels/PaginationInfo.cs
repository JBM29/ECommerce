using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models.ViewModels
{
    public class PaginationInfo
    {
        public int NombreProduits { get; set; }
        public int ProduitsParPage { get; set; }
        public int PageCourante { get; set; }

        public int GetCountOfPage()
        {
            return NombreProduits / ProduitsParPage;
        }
    }
}
