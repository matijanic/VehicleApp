using Microsoft.EntityFrameworkCore;
using Project.DAL;

var builder = WebApplication.CreateBuilder(args);

//Konfiguracija DBContext-a

var conn = builder.Configuration.GetConnectionString("VehicleConnection");
builder.Services.AddDbContext<VehicleDbContext>(options =>
{
    options.UseSqlServer(conn);

});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// CORS - Cors politika (policy) dozvole pristupa svim metodama, izvorima i zaglavljima pristup nasem serveru-- nevazno sad za projekt Vehicle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();


