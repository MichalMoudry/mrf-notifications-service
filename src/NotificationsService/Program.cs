using System.Data;
using FirebaseAdmin;
using FluentValidation;
using NotificationsService.Config;
using NotificationsService.Service.Commands;
using NotificationsService.Transport.Validation;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

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

FirebaseApp.Create(FirebaseConfig.GetFirebaseConfig());
var firebaseAuth = FirebaseConfig.GetFirebaseAuth();
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Trying to parse JWT.");
    await next.Invoke(context);
});

app.Run();
