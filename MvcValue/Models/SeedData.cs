using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcValue.Data;
using System;
using System.Linq;

namespace MvcValue.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcValueContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcValueContext>>()))
            {
                // Look for any movies.
                if (context.Value.Any())
                {
                    return;   // DB has been seeded
                }

                context.Value.AddRange(
                    new Value
                    {
                        Title = "When Harry Met Sally",
                        Category = "Romantic Comedy",
                        Price = 7.99M
                    },

                    new Value
                    {
                        Title = "Ghostbusters ",
                        Category = "Comedy",
                        Price = 8.99M
                    },

                    new Value
                    {
                        Title = "Ghostbusters 2",
                        Category = "Comedy",
                        Price = 9.99M
                    },

                    new Value
                    {
                        Title = "Rio Bravo",
                        Category = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}