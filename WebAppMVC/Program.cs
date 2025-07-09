using SistemaCliente.Application.Interface;
using SistemaCliente.Application.Service;
using SistemaCliente.Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//get url from appsettings.json
builder.Services.AddHttpClient("ApiClient", c =>
{
    c.BaseAddress = new Uri("https://localhost:7287/"); // Make sure this matches your API
    c.DefaultRequestHeaders.Add("Accept", "application/json");
});


builder.Services.AddScoped<ITipoTelefoneApiService, TipoTelefoneApiService>();
builder.Services.AddScoped<IClienteApiService, ClienteApiService>();
builder.Services.AddScoped<ITelefoneApiService, TelefoneApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cliente}/{action=Index}/{id?}");

app.Run();
