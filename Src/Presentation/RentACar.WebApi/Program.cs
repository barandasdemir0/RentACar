using RentACar.Persistence;
using RentACar.WebApi.Extensions;
using RentACar.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApiServices();


var app = builder.Build();


app.MapGet("/", () => "🚀 RentACar Web API ve PostgreSQL Altyapısı Başarıyla Çalışıyor!");


using(var scoped = app.Services.CreateScope())
{
    var srv = scoped.ServiceProvider;
    var context = srv.GetRequiredService<CarBookContext>();
    context.Database.Migrate();
    
}

app.Run();
