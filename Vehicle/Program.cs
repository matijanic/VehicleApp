using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Repository;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;
using Project.WebAPI.Mapping;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Konfiguracija DBContext-a

var conn = builder.Configuration.GetConnectionString("VehicleConnection");
builder.Services.AddDbContext<VehicleDbContext>(options =>
{
    options.UseSqlServer(conn);

});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddScoped<IVehicleModelService, VehicleModelService>();
builder.Services.AddScoped<IVehicleMakeRepository, VehicleMakeRepository>();
builder.Services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();



// CORS - Cors politika (policy) dozvole pristupa svim metodama, izvorima i zaglavljima pristup nasem serveru-- nevazno sad za projekt Vehicle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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


