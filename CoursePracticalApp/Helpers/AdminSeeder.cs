using Microsoft.AspNetCore.Identity;

namespace CoursePracticalApp.Helpers
{
    public static class AdminSeeder
    {

        public static async Task SeedAdminUser(WebApplication app)
        {
            // Implementation for seeding an admin user

            var scope = app.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();


            var adminEmail = "admin@clinic.com";
            var adminPassword = "Admin@123";


            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var newAdminUser = new IdentityUser
                {
                    UserName = adminEmail.Split("@")[0],
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newAdminUser, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Can't create admin user");
                }

                result = await userManager.AddToRoleAsync(newAdminUser, AppRoles.APP_ADMIN.ToString());
                if (!result.Succeeded)
                {
                    throw new Exception("Can't assign admin role to admin user");
                }

            }
        }



    }
}
