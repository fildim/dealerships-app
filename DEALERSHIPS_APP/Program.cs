using DEALERSHIPS_APP.Middlewares;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;
using DEALERSHIPS_APP.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DealershipDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DealershipDB")));

builder.Services.AddScoped<DBInitializer>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddValidatorsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

builder.Services.AddCors(x =>
{
    x.AddPolicy("policy", x =>
    {
        x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IGarageService, GarageService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDBTransactionService, DBTransactionService>();






builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IGarageRepository, GarageRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IOwnershipHistoryRepository, OwnershipHistoryRepository>();
builder.Services.AddScoped<IOwnershipRepository, OwnershipRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<ILoginCredentialRepository, LoginCredentialRepository>();




builder.Services.AddHostedService<AddVehiclesBackgroundHostedService>();




builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

builder.Services.AddControllers();


builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});


builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:5161",
            ValidAudience = "https://localhost:5161",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
    });




var app = builder.Build();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    var dbInitializer = scope.ServiceProvider.GetRequiredService<DBInitializer>();
    
    await dbInitializer.Initialize();
});

app.UseMiddleware<ExceptionHandlingMiddleware>();
 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseRouting();

app.UseCors("policy");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
