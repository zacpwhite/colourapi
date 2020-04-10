using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;

namespace ColourAPI.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
            }
        }  

        public static void SeedData(ColourContext context)
        {
            Console.WriteLine("Applying Migrations...");
            context.Database.Migrate();

            if (!context.ColourItems.Any())
            {
                Console.WriteLine("Seeding Colour data...");
                context.ColourItems.AddRange(
                    new Colour() {ColourName = "Red"},
                    new Colour() {ColourName = "Orange"},
                    new Colour() {ColourName = "Yellow"},
                    new Colour() {ColourName = "Green"},
                    new Colour() {ColourName = "Blue"}
                );
                context.SaveChanges();
            }
            else 
            {
                Console.WriteLine("Colour Data already exists - Skipping seeding");
            }
        }
    }
}