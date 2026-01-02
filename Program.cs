var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//exemplo de injeção de dependência
//builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

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
        Menssagem = "API está funcionando!",
        Timestamp = DateTime.Now,
        Swagger = "https://localhost:7207/swagger",
        Ambiente = app.Environment.EnvironmentName
    });
}

app.MapStaticAssets();

app.Run();
