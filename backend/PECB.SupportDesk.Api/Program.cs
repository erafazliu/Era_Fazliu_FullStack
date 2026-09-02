using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PECB.SupportDesk.Api.Data;
using PECB.SupportDesk.Api.Middleware;
using PECB.SupportDesk.Api.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "PECB Support Desk API", Version = "v1", Description = "Ticket and agent workflow API for PECB Support Desk." });
});
builder.Services.AddDbContext<SupportDeskDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SupportDesk")));
builder.Services.AddScoped<ITicketWorkflowService, TicketWorkflowService>();
builder.Services.AddCors(o => o.AddPolicy("Angular", p => p.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>(); app.UseCors("Angular");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "PECB Support Desk API v1");
        options.DocumentTitle = "PECB Support Desk API";
    });
}
app.MapControllers();
if (!app.Environment.IsEnvironment("Testing")) { using var scope = app.Services.CreateScope(); var db = scope.ServiceProvider.GetRequiredService<SupportDeskDbContext>(); await db.Database.MigrateAsync(); }
app.Run();
public partial class Program;
