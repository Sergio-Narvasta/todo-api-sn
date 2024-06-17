using Microsoft.EntityFrameworkCore;
using ToDo.Infraestructure.Data;
using ToDo.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureSQLDatabaseConnection"), sqlServerOptions =>
    sqlServerOptions.EnableRetryOnFailure(
        maxRetryCount: 5,
        maxRetryDelay: TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null));
});

builder.Services.AddCors(
    options => options.AddPolicy("AllowCors",
        builder => {
            builder 
                .AllowAnyOrigin() 
                .AllowAnyMethod() 
                .AllowAnyHeader(); 
        })
);

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
