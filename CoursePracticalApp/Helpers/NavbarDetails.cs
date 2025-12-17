using System.Security.Claims;

namespace CoursePracticalApp.Helpers
{
    public static class NavbarDetails
    {
        public static string GetFormattedName(this ClaimsPrincipal user)
        {
            var firstName = user.Claims.FirstOrDefault(c => c.Type == "FirstName")?.Value;
            var lastName = user.Claims.FirstOrDefault(c => c.Type == "LastName")?.Value;

            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
                return user.Identity?.Name ?? "Unknown";


            if (user.IsInRole(AppRoles.DOCTOR.ToString()))
                return $"Dr. {firstName} {lastName}".Trim();

            return $"{firstName} {lastName}".Trim();
        }

        public static string GetUserRole(this ClaimsPrincipal user)
        {

            if (user.IsInRole(AppRoles.APP_ADMIN.ToString()))
                return "Administrator";
            else if (user.IsInRole(AppRoles.DOCTOR.ToString()))
                return "Doctor";
            else if (user.IsInRole(AppRoles.RECEPTIONEST.ToString()))
                return "Receptionist";
            else
                return "User";
        }

    }
}
