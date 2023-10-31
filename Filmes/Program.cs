using System.Reflection;
using System.Text;
using Filmes.Authorization;
using Filmes.Data;
using Filmes.Models;
using Filmes.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


var MyconnectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString: MyconnectionString));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<FilmeContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuthorization>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Path.GetTempPath()));


// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x=>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Filmes", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);
});


builder.Services.AddAuthentication(opts =>
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hASFD151ASDAFA98ASD54ASDA777")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(opts => opts.AddPolicy("MinAge", policy =>
    policy.AddRequirements(new MinAge(18))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
