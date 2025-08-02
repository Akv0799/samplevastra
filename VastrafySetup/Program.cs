using VastrafySetup.Data;
using VastrafySetup.Interfaces;
using VastrafySetup.Models;
using VastrafySetup.Services;
using Microsoft.EntityFrameworkCore;
using VastrafySetup.Services.Interfaces;
using VastrafySetup.Repositories.Interfaces;
using VastrafySetup.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Added...........................
builder.Services.AddScoped(typeof(ICustomerDAL), typeof(CustomerXmlDAL));
builder.Services.AddSingleton<AppConfigService>();
//builder.Services.AddScoped(typeof(ICuttingEntryService), typeof(CuttingEntryService));
builder.Services.AddScoped<ICuttingEntryService, CuttingEntryService>();
builder.Services.AddScoped<ICuttingEntryRepository, CuttingEntryRepository>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),sqlOptions =>
       sqlOptions.EnableRetryOnFailure()));
//.........................................

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Added...............................
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
//........................................
app.MapControllers();

app.Run();
