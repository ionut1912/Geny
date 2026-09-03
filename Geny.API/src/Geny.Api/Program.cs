using Geny.Infrastructure.Persistance;

using Microsoft.EntityFrameworkCore;

using Shared.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<GenyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MigrateServiceDatabase<GenyDbContext>();
app.UseHttpsRedirection();

app.Run();
