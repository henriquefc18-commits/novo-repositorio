using Microsoft.EntityFrameworkCore;
using produtoapi2.Data;
using produtoapi2.Interfaces;
using produtoapi2.Repository;
using produtoapi2.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseInMemoryDatabase("ProdutoDb"));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();


// “Como o EF Core InMemory não usa migrations, foi necessário chamar
// EnsureCreated() para executar o seed definido no OnModelCreating.”
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    context.Database.EnsureCreated();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();

// Rota de teste simples
if (app.Environment.IsDevelopment())
{
    app.MapGet("/teste", () => new
    {
        Menssagem = "API est� funcionando!",
        Timestamp = DateTime.Now,
        Swagger = "https://localhost:7207/swagger",
        Ambiente = app.Environment.EnvironmentName
    });
}

app.MapStaticAssets();

app.Run();
