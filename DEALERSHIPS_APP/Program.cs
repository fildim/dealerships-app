using DEALERSHIPS_APP.Middlewares;
using DEALERSHIPS_APP.Models;
using DEALERSHIPS_APP.Repositories;
using DEALERSHIPS_APP.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DealershipDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DealershipDB")));

builder.Services.AddScoped<DBInitializer>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddValidatorsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());


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









builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());

builder.Services.AddControllers();


builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);

    
    //.MinimumLevel.Debug()
    //.MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
    //.WriteTo.Console()
    //.WriteTo.File(
    //    "Logs/logs.txt",
    //    rollingInterval: RollingInterval.Day,
    //    outputTemplate: "[ { TimestampAttribute: dd-MM-yyyy HH:mm:ss } { SourceContext } { level } ] " +
    //            "{ Message } { NewLine } { Exception } ",
    //    retainedFileCountLimit: null,
    //    fileSizeLimitBytes: null
    //);
    
});




var app = builder.Build();



app.Lifetime.ApplicationStarted.Register(() =>
{
    using var scope = app.Services.CreateScope();
    var dbInitializer = scope.ServiceProvider.GetRequiredService<DBInitializer>();
    
    dbInitializer.Initialize();
});

app.UseMiddleware<ExceptionHandlingMiddleware>();
 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapRazorPages();

app.Run();
