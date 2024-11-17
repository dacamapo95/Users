using Users.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var baseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");

builder.Services.AddHttpClient("UsersApiClient", client =>
{
    var baseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");
    client.BaseAddress = new Uri(baseUrl!);
});

builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<NotificationHub>("/notifications");

app.Run();
