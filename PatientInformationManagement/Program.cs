using Microsoft.EntityFrameworkCore;
using PatientInformationManagement;
using PatientInformationManagement.Data;
using PatientInformationManagement.Interfaces;
using PatientInformationManagement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<Seed>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAllergiesRepository, AllergiesRepository>();
builder.Services.AddScoped<IPatientInfoRepository, PatientInfoRepository>();
builder.Services.AddScoped<IDiseaseInfoRepository, DiseaseInfoRepository>();
builder.Services.AddScoped<INCDRepository, NCDRepository>();
builder.Services.AddScoped<IEpilepsyRepository, EpilepsyRepository>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    var seeder = services.GetRequiredService<Seed>();
    seeder.SeedDataContext();
}



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
