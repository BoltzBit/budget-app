using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Budget.Infra;

public static class BudgetDbExtension
{
    public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BudgetDbContext>(options => 
        {
            options.UseNpgsql(connectionString);
        });
    }
}
