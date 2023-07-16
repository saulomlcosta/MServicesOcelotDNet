using Microsoft.EntityFrameworkCore;
using UserMicroservice.Data;

namespace UserMicroservice.Services
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
