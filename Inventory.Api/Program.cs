
using Inventory.Api.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => o.OperationFilter<VersionGetOperationFilter>());

builder.Services.AddScoped<Inventory.Api.Services.V1.IProductService, Inventory.Api.Services.V1.ProductService>();
builder.Services.AddScoped<Inventory.Api.Services.V2.IProductService, Inventory.Api.Services.V2.ProductService>();

builder.Services.AddApiVersioning(options =>
{
    // This option will be used to serve the request without a version. (you can see api-version as non mandatory in swagger)
    options.AssumeDefaultVersionWhenUnspecified = true;
    // set the default version
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(2, 0);
    //This option enables sending the api-supported-versions and api-deprecated-versions HTTP header in responses.
    options.ReportApiVersions = true;
    //allow media header like Accept: Application/Json;v=1.0
    // options.ApiVersionReader = new MediaTypeApiVersionReader();
    options.ApiVersionReader = Asp.Versioning.ApiVersionReader.Combine(
        new Asp.Versioning.HeaderApiVersionReader("x-api-version"),
        new Asp.Versioning.QueryStringApiVersionReader("api-version"));

    options.ApiVersionReader = Asp.Versioning.ApiVersionReader.Combine(new Asp.Versioning.MediaTypeApiVersionReader(),
    new Asp.Versioning.HeaderApiVersionReader("x-api-version"),
    new Asp.Versioning.QueryStringApiVersionReader("api-version") 
   );
})
.AddApiExplorer(options =>
{
    /*** https://github.com/dotnet/aspnet-api-versioning/wiki/Version-Format#custom-api-version-format-strings ***/
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
