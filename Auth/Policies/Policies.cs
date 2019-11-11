using System;
using Microsoft.Extensions.DependencyInjection;

public class Policies
{
    public const string CREATE_CUSTOMER = "CreateCustomer";
    public const string VIEW_CUSTOMERS = "ViewCustomers";
    public const string UPDATE_CUSTOMERS = "UpdateCustomers";
    public const string DELETE_CUSTOMERS = "DeleteCustomers";

    public static void Config(IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(VIEW_CUSTOMERS, policy =>
            {
                policy.RequireAuthenticatedUser();
            });

            options.AddPolicy(CREATE_CUSTOMER, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("Admin", "true");
            });

            options.AddPolicy(UPDATE_CUSTOMERS, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("Admin", "true");
            });

            options.AddPolicy(DELETE_CUSTOMERS, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("Admin", "true");
            });
        });
    }
}