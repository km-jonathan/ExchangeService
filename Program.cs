using ExchangeService.Configuration;
using ExchangeService.Providers;
using ExchangeService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ExchangeRateApiConfig>(
    builder.Configuration.GetSection("ExchangeRate"));

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IExchangeRateApiProvider, ExchangeRateApiProvider>();
builder.Services.AddSingleton<IExchangeRateService, ExchangeRateService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
