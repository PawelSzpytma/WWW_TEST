using DotVVM.Core.Common;
using DotVVM.Framework.Api.Swashbuckle.AspNetCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
      .AddNewtonsoftJson(options =>
      {
          options.SerializerSettings.Converters.Add(new StringEnumConverter());
      });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.Configure<DotvvmApiOptions>(opt =>
{

    // TODO: configure DotVVM Swashbuckle options
});

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableDotvvmIntegration();
    options.UseInlineDefinitionsForEnums();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "School API",
        Description = "",
        TermsOfService = new Uri("https://dlpro.eu"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://dlpro.eu")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://dlpro.eu")
        },

    });

    List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));
});


var app = builder.Build();

var supportedCultures = new[] {
                new CultureInfo("pl-PL"),
                new CultureInfo("en-GB"),
                new CultureInfo("uk-UA"),
                new CultureInfo("ru-RU"),
                new CultureInfo("it-IT"),
                new CultureInfo("es-ES"),
                new CultureInfo("pt-PT"),
                new CultureInfo("cs-CZ"),
                new CultureInfo("sk-SK"),
                new CultureInfo("tr-TR")
            };
var lo = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pl-PL"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    //FallBackToParentCultures = false,
    //FallBackToParentUICultures = false,
    RequestCultureProviders = new List<IRequestCultureProvider>
                    {
                        new CookieRequestCultureProvider(){ CookieName="UserCultureDlPro" }
                    }
};

app.UseRequestLocalization(lo);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
