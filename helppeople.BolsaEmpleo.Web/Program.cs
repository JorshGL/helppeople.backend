using helppeople.BolsaEmpleo.Application.Services.implementations;
using helppeople.BolsaEmpleo.Application.Services.interfaces;
using helppeople.BolsaEmpleo.Infraestructure.Data;
using helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Implementations;
using helppeople.BolsaEmpleo.Infraestructure.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(opt =>
    opt.AddDefaultPolicy(
        policyBuilder =>
        {
            policyBuilder.WithOrigins(builder.Environment.IsDevelopment()
                ? "*"
                : builder.Configuration.GetValue<string>("AllowedOrigins", "*"));
        })
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<BolsaEmpleoDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BolsaEmpleoBD"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<ICitizensRepository, CitizensRepository>();
builder.Services.AddScoped<IVacanciesRepository, VacanciesRepository>();
builder.Services.AddScoped<IIdDocumentTypesRepository, IdDocumentTypesRepository>();
builder.Services.AddScoped<ICitizensService, CitizensService>();
builder.Services.AddScoped<IVacanciesService, VacanciesService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.MapControllers();

app.Run();