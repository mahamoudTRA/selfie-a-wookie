using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Pomelo.EntityFrameworkCore.MySql;
using SelfieAWookie.Core.Infrastructure.Data;
using SelfieAWookie.Core.Infrastructure.Repositories;
using SelfieAWookie.Core.Domain.Repositories;
using SelfieAWookie.API.UI.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using SelfieAWookie.Core.Infrastructure.Loggers;
using SelfieAWookie.API.UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInjection();
builder.Services.AddCustomSecurity(builder.Configuration);
builder.Services.AddCustomOptions(builder.Configuration);

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    //options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<DataContext>();

var connectionString = builder.Configuration.GetConnectionString("SelfieDataBase");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Logging.AddProvider(new CustomLoggerProvider());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Staging"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<LogRequestMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(SecurityMethods.DEFAULT_POLICY);

app.MapControllers();

app.Run();

