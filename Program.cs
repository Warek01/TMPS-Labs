using TMPS_Labs.Models;
using TMPS_Labs.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(typeof(IApiService<User>), typeof(UserService));
builder.Services.AddScoped(typeof(IApiService<IEnumerable<Repository>>), typeof(ReposService));

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
