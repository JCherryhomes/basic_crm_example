namespace CRM_Example.Models
{
    // Using const allows the roles to be used in the Authorize attribute on the api controllers
    public static class Roles
    {
        public const string User = "User";
        public const string Admin = "Admin";
    }
}
