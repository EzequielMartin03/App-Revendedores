using AppRevendedores.Dtos;
using AppRevendedores.Models;
using AppRevendedores.Repository;
using AppRevendedores.Services;
using AppRevendedores.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Reemplaza con la URL de tu frontend
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Services

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddKeyedScoped<ICommonService<ProductDto,ProductUpdateDto,ProductInsertDto>,ProductService>("ProductService");


builder.Services.AddKeyedScoped<ICommonService<CategoryDto, CategoryDto, CategoryInsertDto>, CategoryService>("CategoryService");


// Repository

builder.Services.AddScoped<IRepository<Product>,ProductRepository>();

builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();


//JWT
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

// Entity Framework

builder.Services.AddDbContext<Context>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

// Validators

builder.Services.AddScoped<IValidator<ProductInsertDto>, ProductInsertValidator>();



var app = builder.Build();

app.UseCors("AllowReactApp");

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
