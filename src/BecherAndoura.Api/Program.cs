using BecherAndoura.Api.Endpoints;
using BecherAndoura.Application.Abstractions;
using BecherAndoura.Application.Contact;
using BecherAndoura.Application.Portfolio;
using BecherAndoura.Infrastructure;
using BecherAndoura.Infrastructure.Contact;
using BecherAndoura.Infrastructure.Portfolio;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>() ?? ["http://localhost:4200"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularClient", policy =>
    {
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();

builder.Services.AddScoped<IPortfolioContentService, PortfolioContentService>();
builder.Services.AddScoped<IContactRequestService, ContactRequestService>();
builder.Services.AddSingleton<IPortfolioContentRepository, InMemoryPortfolioContentRepository>();
builder.Services.AddSingleton<IContactLeadRepository, InMemoryContactLeadRepository>();
builder.Services.AddSingleton<IClock, SystemClock>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AngularClient");

app.MapPortfolioEndpoints();
app.MapContactEndpoints();

app.Run();
