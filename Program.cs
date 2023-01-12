using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using guestbook_sample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// using Microsoft.EntityFrameworkCore;
builder.Services.AddDbContext<GuestbookContext>(options =>
// using Microsoft.EntityFrameworkCore;
    options.UseSqlServer(builder.Configuration.GetConnectionString("GuestbookContext") ?? throw new InvalidOperationException("Connection string 'GuestbookContext' not found.")));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<GuestbookContext>();
Console.WriteLine(db.Database.ProviderName);
db.Database.Migrate();

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
