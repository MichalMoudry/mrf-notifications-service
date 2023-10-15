using System.Data;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NotificationsService.Service.Commands;
using NotificationsService.Transport.Validation;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/ocr-microservice-project";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/ocr-microservice-project",
            ValidateAudience = true,
            ValidAudience = "ocr-microservice-project",
            ValidateLifetime = true
        };
    });

// MediatR & FluentValidation
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<InsertNotifCommandHandler>();
});
builder.Services.AddValidatorsFromAssemblyContaining<BatchStatRequestValidator>();

// Connect to DB.
var connectionString = builder.Environment.IsDevelopment()
    ? builder.Configuration["DbConnection"]
    : Environment.GetEnvironmentVariable("DB_CONN");
builder.Services.AddTransient<IDbConnection>(
    _ => new NpgsqlConnection(connectionString)
);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
