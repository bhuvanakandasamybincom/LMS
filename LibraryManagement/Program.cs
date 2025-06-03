using LibraryManagement.Data;
using LibraryManagement.DbContexts;
using LibraryManagement.Interface;
using LibraryManagement.Model;
using LibraryManagement.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddTransient<IAuthorData, AuthorData>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookData, BookData>();

// Adding EF Core with SQL Server connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLServerDBConnection")).EnableSensitiveDataLogging();
    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//User role to EF Core
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
}).AddEntityFrameworkStores<ApplicationDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure JWT authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var SecretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

// Adding Authentication and Authorization
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
        //ClockSkew = TimeSpan.Zero
    };
});
//Policy based role checks
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy",
         policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy("UserPolicy", policy =>
      policy.RequireRole(UserRoles.User));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller base
app.MapControllers();

app.Run();

