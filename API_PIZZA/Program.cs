using Microsoft.Extensions.DependencyInjection;
using AllModels;
using AllModels.Interfaces;
using AllService;
using FileServices;
// using FileServices;
using Microsoft.Extensions.FileProviders;

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
var app = builder.Build();
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

