using GlomerularIdentifier.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCors(options => 
{
	options.AddPolicy("NewPolicy", builder =>
	builder.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


// Configure to serve static files and add a MIME type for .dzi
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true, // Allow serving files with unknown MIME types
    DefaultContentType = "application/xml", // Default MIME type for .dzi
    OnPrepareResponse = ctx =>
    {
        if (ctx.File.Name.EndsWith(".dzi"))
        {
            ctx.Context.Response.ContentType = "application/xml"; // Force .dzi to be treated as XML
        }
    }
});

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseRouting(); 
app.UseAntiforgery();
app.UseCors("NewPolicy");
app.UseAuthorization(); 
app.Run();
