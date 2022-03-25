using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var _logger = LoggerFactory.Create(cnf =>
{
	cnf.AddConsole();
	cnf.AddConfiguration(builder.Configuration.GetSection("Logging"));
}).CreateLogger("Program");


var serverVersion = new MariaDbServerVersion(builder.Configuration.GetValue<string>("MariaVersion"));

//_logger.Log(LogLevel.Information, "db: server-version:" + serverVersion.ToString());
var connectionString = builder.Configuration.GetConnectionString("GameStoreContext");


builder.Services.AddDbContext<GameStoreContext>(options =>
	 options.UseMySql(connectionString, serverVersion)
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/test", () => "Hello World");
app.MapGet("/manual", (ctx) =>
{

	return ctx.Response.WriteAsync("Hello World Again");

});

app.MapRazorPages();

app.Run();
