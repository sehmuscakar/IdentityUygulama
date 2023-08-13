using DataAccessLayer.Concrete;
using DataAccessLayer.Entities;
using ProjeUI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();//hangi tablolarý özeleþtirmiþsen onlarý buraya tanýman lazým ýdentitye ile sisteme
//AddErrorDescriber<CustomIdentityValidator>() bunu eklememizin sebebi registerýn kayýt olduðu hatalarý türkçeleþtirmek,CustomIdentityValidator modelimizi oluþturduk tanýmlatýk
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

app.UseAuthentication();//loginin otantike iþlemi için kullanacaz.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
