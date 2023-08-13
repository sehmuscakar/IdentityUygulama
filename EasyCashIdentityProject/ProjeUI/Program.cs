using DataAccessLayer.Concrete;
using DataAccessLayer.Entities;
using ProjeUI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>();//hangi tablolar� �zele�tirmi�sen onlar� buraya tan�man laz�m �dentitye ile sisteme
//AddErrorDescriber<CustomIdentityValidator>() bunu eklememizin sebebi register�n kay�t oldu�u hatalar� t�rk�ele�tirmek,CustomIdentityValidator modelimizi olu�turduk tan�mlat�k
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

app.UseAuthentication();//loginin otantike i�lemi i�in kullanacaz.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
