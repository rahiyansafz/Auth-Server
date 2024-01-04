using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie")
    .AddOAuth("htgAuth",
        o =>
        {
            o.SignInScheme = "cookie";

            o.ClientId = "x";
            o.ClientSecret = "x";

            o.AuthorizationEndpoint = "https://localhost:7013/oauth/authorize";
            o.TokenEndpoint = "https://localhost:7013/oauth/token";
            o.CallbackPath = "/oauth/custom-cb";

            o.UsePkce = true;
            o.ClaimActions.MapJsonKey("sub", "sub");
            o.Events.OnCreatingTicket = async ctx => { await Task.CompletedTask; };
        });

var app = builder.Build();


app.MapGet("/login", () => Results.Ok("")).RequireAuthorization();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();