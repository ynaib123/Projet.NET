using HotelReservationBackend.Services;
using Microsoft.EntityFrameworkCore;
using HotelReservationBackend.Data;

var builder = WebApplication.CreateBuilder(args);

// Ajouter DbContext avec la chaîne de connexion à la base de données
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajouter les services
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<ChambreService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<PaiementService>();

// Ajouter les contrôleurs
builder.Services.AddControllers();

// Ajouter Swagger/OpenAPI pour la documentation
builder.Services.AddEndpointsApiExplorer();  // Necessary for OpenAPI generation
builder.Services.AddSwaggerGen();  // This will generate the OpenAPI specification

var app = builder.Build();

// Utilisation de la redirection HTTPS
app.UseHttpsRedirection();

// Utilisation de Swagger/OpenAPI si en développement
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();  // To provide a UI for Swagger
}

// Map les contrôleurs
app.MapControllers();

app.Run();
