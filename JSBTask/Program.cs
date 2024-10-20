using FluentValidation.AspNetCore;
using JSBTask.Dto;
using JSBTask.Persistence;
using JSBTask.Services.Contract;
using JSBTask.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<AddBookDtoValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<UpdateBookDtoValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<AddCategoryDtoValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<UpdateCategoryDto>();
                });

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

app.UseAuthorization();

app.MapControllers();

app.Run();
