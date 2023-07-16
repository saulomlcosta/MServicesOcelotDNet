using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Data;

namespace ProductMicroservice.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                .GetService<DbContextClass>();

                serviceDb.Database.Migrate();
            }
        }
    }
}
