using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Rgis_V2.Data;


var builder = WebApplication.CreateBuilder(args);

// Dodajanje DbContext z SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dodajanje Razor Pages in ostalih servisov
builder.Services.AddRazorPages();

var evidencaLetov = new EvidencaLetov();
var evidencaPilotov = new EvidencaPilotov();
var evidencaLetal = new EvidencaLetal();

// Add pilots
evidencaPilotov.NovPilot("Janez", "Novak", 35);
evidencaPilotov.NovPilot("Ana", "Kovaè", 29);

// Add aircraft


// Create a flight entry window
var vnosLeta = new VnosLetaOkno(evidencaLetov, evidencaPilotov, evidencaLetal);

// Add a flight
vnosLeta.VnesiLet("Let001", "Boeing 747", "Janez Novak"); // Success
vnosLeta.VnesiLet("Let002", "Cessna 172", "Ana Kovaè");

builder.Services.AddSingleton<EvidencaLetal>();
builder.Services.AddSingleton<EvidencaPilotov>();
builder.Services.AddSingleton<EvidencaLetov>();



var app = builder.Build();

// Konfiguracija HTTP zahtevkov
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

app.MapRazorPages();

app.Run();