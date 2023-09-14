using BO;
using DA;

using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


//builder.Configuration.AddJsonFile("appsettings.json");

var configuration = new Configuracion(builder.Configuration.GetConnectionString("DefaultConnection"));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton(configuration);

builder.Services.AddTransient<SqlHelper, SqlHelper>();
builder.Services.AddTransient<ClientCliente, ClientCliente>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(opts => { opts.AllowAnyHeader();
    opts.AllowAnyOrigin();
    opts.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
