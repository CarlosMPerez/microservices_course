using PlatformService.Models;

namespace PlatformService.Data
{
    // Can't use DI as this is static
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
                    new Platform() { Name = "MongoDB", Publisher = "Mongoloid", Cost = "Free" },
                    new Platform() { Name = "MySQL", Publisher = "Free Software Foundation", Cost = "Free" },
                    new Platform() { Name = "Serilog", Publisher = "Serilog Inc.", Cost = "License per user" },
                    new Platform() { Name = "Node", Publisher = "Node JS Foundation", Cost = "Free" },
                    new Platform() { Name = "Bootstrap", Publisher = "CSS For Everyone Foundation", Cost = "Free" },
                    new Platform() { Name = "React", Publisher = "Facebook", Cost = "Free" },
                    new Platform() { Name = "MediatR", Publisher = "Paul Schleizing", Cost = "License per organization" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data seeded!");
            }
        }
    }
}