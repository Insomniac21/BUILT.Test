using BUILT.Test.RestApi.DbContexts;
using BUILT.Test.RestApi.ExceptionHandlers;
using BUILT.Test.RestApi.Repositories;
using BUILT.Test.RestApi.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(x => new BlogDbContext(connectionString: builder.Configuration.GetConnectionString("BUILTTestDatabase")!));
builder.Services.AddTransient<BlogPostService>();
builder.Services.AddTransient<BlogPostCategoryService>();
builder.Services.AddTransient<BlogPostCategoryRepository>();
builder.Services.AddTransient<BlogPostRepository>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandler();

app.MapControllers();

app.Run();
