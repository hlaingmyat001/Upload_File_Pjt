using Microsoft.EntityFrameworkCore;
using Upload_File_Pjt;
using Upload_File_Pjt.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UploadContext>(options =>
{
    // TODO: REPLACE THIS LATER WHEN ADDING KUBERNETES AND DOCKER.
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UploadRepository, UploadRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
