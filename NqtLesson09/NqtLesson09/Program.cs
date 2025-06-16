using Microsoft.EntityFrameworkCore;
using NqtLesson09.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 👉 Thêm dòng này TRƯỚC khi gọi builder.Build()
var connectionString = builder.Configuration.GetConnectionString("BookStoreConnectionSring");
builder.Services.AddDbContext<NqtBookStoreBookStoreContext>(options =>
    options.UseSqlServer(connectionString));

// 🚀 Xây dựng ứng dụng sau khi cấu hình xong services
var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=NqtHome}/{action=NqtIndex}/{id?}");

app.Run();
