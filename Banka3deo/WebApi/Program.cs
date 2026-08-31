using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using BankaLibrary.Entiteti; 
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CORS", options =>
    {
        options.AllowAnyHeader()
               .AllowAnyMethod()
               .WithOrigins("http://127.0.0.1:5555",
                            "https://127.0.0.1:5555",
                            "http://localhost:5555",
                            "https://localhost:5555",
                            "http://127.0.0.1:5500",
                            "https://127.0.0.1:5500",
                            "http://localhost:5500",
                            "https://localhost:5500",
                            "http://127.0.0.1:5500");
    });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ========================================================================
// NHIBERNATE I ORACLE KONFIGURACIJA
// ========================================================================
var connectionString = builder.Configuration.GetConnectionString("OracleBanka");

var sessionFactory = Fluently.Configure()
    // Korišćenje ispravnog Managed drajvera (Oracle12c umesto Oracle10)
    .Database(OracleManagedDataClientConfiguration.Oracle10
        .ConnectionString(connectionString)
        .ShowSql())
    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Klijent>())
    // Zaobilaženje .NET 10 baga sa MemberwiseClone i internal klasama
    .ExposeConfiguration(cfg => cfg.SetProperty(NHibernate.Cfg.Environment.UseProxyValidator, "false"))
    .BuildSessionFactory();

// Registrovanje sesije u Dependency Injection sistem (da bi kontroler mogao da je koristi)
builder.Services.AddSingleton(sessionFactory);
builder.Services.AddScoped<ISession>(factory => sessionFactory.OpenSession());
// ========================================================================

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();