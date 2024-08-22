using Budget.Web.Components;
using Budget.Infra;
using Budget.Core.Interfaces.Repositories;
using Budget.Infra.Repositories;
using Budget.Application.Features.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is not null)
{
    builder.Services.AddApplicationDbContext(connectionString);
}
else
{
    throw new Exception("Connection String not found");
}

//Repositories
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IBudgetItemRepository, BudgetItemRepository>();
builder.Services.AddScoped<ICostumerRepository, CostumerRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();

//Injections
builder.Services
    .AddMediatR(cfg => cfg
        .RegisterServicesFromAssembly(typeof(CreateBudgetCommandHandler).Assembly));
        
builder.Services
    .AddMediatR(cfg => cfg
        .RegisterServicesFromAssembly(typeof(CreateProviderCommandHandler).Assembly));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
