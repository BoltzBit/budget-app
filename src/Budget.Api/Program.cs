using Budget.Application.Features.Commands;
using Budget.Application.Services;
using Budget.Core.Interfaces.Repositories;
using Budget.Core.Interfaces.Services;
using Budget.Infra;
using Budget.Infra.Repositories;

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

//Service
builder.Services.AddScoped<IProviderService, ProviderService>();

//Injections
builder.Services
    .AddMediatR(cfg => cfg
        .RegisterServicesFromAssembly(typeof(CreateBudgetCommandHandler).Assembly));
        
builder.Services
    .AddMediatR(cfg => cfg
        .RegisterServicesFromAssembly(typeof(CreateProviderCommandHandler).Assembly));

//Repositories
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IBudgetItemRepository, BudgetItemRepository>();
builder.Services.AddScoped<ICostumerRepository, CostumerRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
