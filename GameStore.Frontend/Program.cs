var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents();
builder.Services.AddSingleton<GamesClient>();
builder.Services.AddSingleton<GenresClient>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();

app.Run();

//public static class StartUp
//{
//    public static GamesClient GamesClient { get; set; } = new();
//}
