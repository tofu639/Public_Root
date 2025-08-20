var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Error handling & HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// 3. ✅ ให้โหลดไฟล์ static เช่น CSS, JS, JSON (จาก wwwroot)
app.UseStaticFiles();

// 4. ✅ Session (ต้องมาก่อน UseRouting/UseAuthorization)
app.UseRouting();
app.UseSession();

// 5. ✅ Authorization
app.UseAuthorization();




// 6. ✅ Map controller

app.UseEndpoints(static endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Authen}/{action=Login}/{id?}");
});



app.Run();
