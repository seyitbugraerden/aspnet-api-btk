using AIBlog.WebApi.Context;
using AIBlog.WebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogAIContext>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<BlogAIContext>();
//Swagger Günceller
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    // Swagger UI ile uyumlu tek tip parametre şemaları üretir.
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // dotnet add package Swashbuckle.AspNetCore.SwaggerUI
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "AIBlog API v1");
    });
}

app.UseHttpsRedirection();
// Swagger günceller.
app.MapControllers();

app.Run();
