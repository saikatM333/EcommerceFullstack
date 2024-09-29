using busnessLayer.Interface;
using busnessLayer.Interfaces;
using busnessLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Services;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddControllers();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins", builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});
 builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:3000") // Replace with your client application URL
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

// Learn more about configuring Swagger/OpenAPI at 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer",
        Type = SecuritySchemeType.Http

    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
});

var key = Encoding.ASCII.GetBytes("12333!@@9your_secret_key_here___"); // Replace with your secret key
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddAuthorization();

builder.Services.AddDbContext<EcommerceDBContext>(opts => {
    opts.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDB"),
    b => b.MigrationsAssembly("OnlineBookOrderingSystem"));
});


builder.Services.AddTransient<ICartServiceRL, CartServices>();
builder.Services.AddTransient<IProductServicesRL, ProductServices>();   
builder.Services.AddTransient<IOrderServicesRL, OrderServices>();
builder.Services.AddTransient<ICategoryServicesRL, CategoryServices>();
builder.Services.AddTransient<INotificationServices, NotificationServices>();
builder.Services.AddTransient<IPromotionServices , PromotionServices>();    
builder.Services.AddTransient<IReviewServices ,  ReviewServices>();


builder.Services.AddTransient<ICartServiceBL, CartServicesBL>();
builder.Services.AddTransient<ICategoryServicesBL, CategoryServicesBL>();
builder.Services.AddTransient<IOrderServicesBL, OrderServicesBL>();
builder.Services.AddTransient<IProductServicesBL, ProductServicesBL>();
builder.Services.AddTransient<INotificationServicesBL, NotificationServicesBL>();
builder.Services.AddTransient<IPromotionServicesBL, PromotionServicesBL>();
builder.Services.AddTransient<IReviewServicesBL, ReviewServicesBL>();






var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseStaticFiles();
app.UseAuthentication(); // Add this line

app.UseAuthorization();

app.MapControllers();

app.Run();
