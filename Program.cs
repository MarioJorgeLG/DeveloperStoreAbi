using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<ISaleRepository, SaleRepository>();  // Registrar o SaleRepository
    services.AddControllers();
}
