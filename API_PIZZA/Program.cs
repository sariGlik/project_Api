using Microsoft.Extensions.DependencyInjection;
using AllModels;
using AllModels.Interfaces;
using AllService;
using Microsoft.Extensions.FileProviders;
using FileServices;
using MiddleWares.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPizza,PizzaService>();
builder.Services.AddScoped<IWorker,WorkerService>();
builder.Services.AddTransient<IOrder,OrderService>();
builder.Services.AddSingleton<IFile,FileService>();
builder.Services.AddSingleton<ILog,LogService>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(cfg =>
        {
        cfg.RequireHttpsMetadata = false;
        cfg.TokenValidationParameters = IdentityService.GetTokenValidationParameters();
         });



builder.Services.AddAuthorization(cfg =>
    {
        cfg.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));
        cfg.AddPolicy("SuperWorker", policy => policy.RequireClaim("Role", "SuperWorker"));
        // cfg.AddPolicy("ClearanceLevel1", policy => policy.RequireClaim("ClearanceLevel", "1", "2"));
        // cfg.AddPolicy("ClearanceLevel2", policy => policy.RequireClaim("ClearanceLevel", "2"));
    });

var app = builder.Build();
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseAuthorization();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseRequestCulture();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

