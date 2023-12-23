using CRUD_App.Interfaces;
using CRUD_App.Models;
using CRUD_App.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add the serilog as take the configuration as addition asettings from the appsettings
builder.Host.UseSerilog((context, configration) => configration.ReadFrom.Configuration(context.Configuration));

/*builder.Services.AddSerilog(options => {
    options.MinimumLevel.Debug()
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File(@"D:/Console Applications/CRUD App/Logs/log-.txt", rollingInterval: RollingInterval.Day, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}");
});*/

// Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(@"D:\Console Applications\CRUD App\Logs\log-.txt", rollingInterval: RollingInterval.Day).CreateLogger();

// Log.Information("Started Application {0}", typeof(Program).Namespace);

/*builder.Services.AddLogging(loggingbuilder => 
    loggingbuilder.AddSerilog()
);*/

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContextPaymentDetail>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"))
);

builder.Services.AddScoped<IPaymentService,PaymentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
