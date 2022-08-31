using Blog;
using Blog.Data;
using Blog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder
    .Services
    .AddControllers()
    //desabilita o modelstate autom�tico
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddDbContext<BlogDataContext>();

builder.Services.AddTransient<TokenService>(); //sempre cria uma nova inst�ncia
//builder.Services.AddScoped(); //cria uma inst�ncia por requisi��o
//builder.Services.AddSingleton(); // cria uma inst�ncia por vez que a aplica��o inicia

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();
