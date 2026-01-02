using CommentActivityLog.Application.Service;
using CommentActivityLog.Infrastructure.Data;
using CommentActivityLog.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IActivityLogService, ActivityLogService>();
builder.Services.AddScoped<ICommentService, CommentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Comment Activity Log",
        Version = "v1"
    });
});


builder.Services.AddControllers();

builder.Services.AddDbContext<CommentActivityLogDbContext>(option => option.UseSqlServer("Data Source=.;Initial Catalog=CommentActivityLogDb;Trusted_Connection=True;TrustServerCertificate=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Comment Activity Log");
});

if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
