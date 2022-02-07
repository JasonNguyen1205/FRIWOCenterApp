using System;
using System.Linq;
using System.Text;
using FRIWOCenter.WebHost.Hubs;
using FRIWOCenter.WebHost.Logging;
using FRIWOCenter.WebHost.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

#region ConfigureServices
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
            builder =>
            {
                builder.WithOrigins(
                            "https://localhost:7214",
                            "https://localhost:7004",
                            "https://localhost:5000",
                            "https://localhost:5001",
                            "wss://localhost:50238",
                            "wss://localhost:50401",
                            "https://localhost:44322",
                            "https://localhost:44323",
                            "https://www.blazingchat.com/")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
            });
});

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlazorWASM.WebAPI", Version = "v1" });
});

builder.Services.AddSignalR();

builder.Services.AddDbContext<BlazorWASMContext>(options => options.UseSqlite("Name=BlazorWASM"));
builder.Services.AddDbContextFactory<LoggingBlazorWASMContext>(options => options.UseSqlite("Name=BlazorWASM"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtBearerOptions =>
{
    jwtBearerOptions.RequireHttpsMetadata = true;
    jwtBearerOptions.SaveToken = true;
    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTSettings:SecretKey"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddHttpClient();

builder.Services.AddSingleton<ILoggerProvider, ApplicationLoggerProvider>();
#endregion

var app = builder.Build();

#region ConfigureApp
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorWASM.WebAPI v1"));
}

app.UseResponseCompression();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chathub");
});
#endregion

Console.WriteLine("Application has started");

app.Run();
