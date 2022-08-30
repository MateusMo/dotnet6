using Blog.Data;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services
    .AddControllers()
    //desabilita o modelstate autom�tico
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
builder.Services.AddDbContext<BlogDataContext>();
var app = builder.Build();

app.MapControllers();

app.Run();
