using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using MultiLanguage.Api;
using MultiLanguage.Library;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddLocalization();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

//builder.Services.AddMvc()
//    .AddDataAnnotationsLocalization(options =>
//    {
//        options.DataAnnotationLocalizerProvider = (type, factory) =>
//            factory.Create(typeof(JsonStringLocalizerFactory));
//    });

builder.Services.AddMvc()
    .AddDataAnnotationsLocalization(options =>
    {
        options.DataAnnotationLocalizerProvider = (_, factory) => factory.Create(typeof(UIMessages));
    });


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("az-Latn"),
        new CultureInfo("en-US"),
    };

    options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);
    options.SupportedCultures = supportedCultures;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SwaggerLocalizationOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
var factory = app.Services.GetService<IStringLocalizerFactory>();
UIMessages.Configure(factory);

var supportedCultures = new[] { "az-Latn", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

app.MapControllers();

app.Run();
