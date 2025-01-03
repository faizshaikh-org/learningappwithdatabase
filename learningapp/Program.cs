using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration.AddAzureAppConfiguration(
    options => {
        options.Connect("Endpoint=https://applicationconfig0001.azconfig.io;Id=b5oI;Secret=DwahWyYyH27n2UVuuMNGDK0Zl7UJjI8xu7WnneFBYdjAZ1FjBYKVJQQJ99BAACGhslB5oe4qAAABAZAC6VhY");
        options.UseFeatureFlags();
    });

builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
