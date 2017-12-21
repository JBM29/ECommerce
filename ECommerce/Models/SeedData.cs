using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Produits.Any())
            {
                context.Produits.AddRange(
                    new Produit
                    {
                        Nom = "Claquettes",
                        Description = "Claquettes de plage du 36 au 44.",
                        Prix = 10M,
                        Categorie = "Plage"
                    },
                    new Produit
                    {
                        Nom = "Chaussettes",
                        Description = "Chaussettes",
                        Prix = 5M,
                        Categorie = "Vetements"
                    },
                    new Produit
                    {
                        Nom = "Ballon de basket",
                        Description = "Ballon de basket",
                        Prix = 30M,
                        Categorie = "Sport"
                    },
                    new Produit
                    {
                        Nom = "Ballon de football",
                        Description = "Ballon de football",
                        Prix = 30M,
                        Categorie = "Sport"
                    },
                    new Produit
                    {
                        Nom = "Ballon de volleyball",
                        Description = "Ballon de volleyball",
                        Prix = 20M,
                        Categorie = "Sport"
                    },
                    new Produit
                    {
                        Nom = "Raquette de tennis",
                        Description = "Raquette de tennis",
                        Prix = 50M,
                        Categorie = "Sport"
                    },
                    new Produit
                    {
                        Nom = "T-Shirt rouge",
                        Description = "T-Shirt rouge ",
                        Prix = 15M,
                        Categorie = "Vetements"
                    },
                    new Produit
                    {
                        Nom = "Short rouge",
                        Description = "Short rouge",
                        Prix = 10M,
                        Categorie = "Sport"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
