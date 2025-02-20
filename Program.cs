var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao contêiner.
builder.Services.AddControllers();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000); // Muda a porta aqui
    options.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.UseHttps();  // HTTPS na porta 5001
    });
});


var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.MapControllers(); // Mapeia os controladores da API
app.Run();
