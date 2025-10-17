using InventarioTI.Cliente.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


var builder = WebApplication.CreateBuilder(args);

// 👇 Registramos HttpClient para consumir la API en el puerto del Server (5000)
builder.Services.AddHttpClient("InventarioAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/"); // Puerto del Server (API)
});

// 👇 Esto permite inyectar HttpClient fácilmente en los componentes Blazor
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("InventarioAPI"));
// Servicios de Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
