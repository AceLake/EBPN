using Google.Cloud.Firestore;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using EBPN_Network.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Initialize Firebase with service account credentials
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile(@"C:\Users\ajajm\source\repos\EBPN_Network\EBPN_Network\JSON\ebpn-global-website-firebase-adminsdk-wjga1-6e40f6789f.json"),
});

// Register other services
builder.Services.AddTransient<UserDAO>();
builder.Services.AddTransient<OutreachRequestDAO>();

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure Firebase JWT Bearer authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/ebpn-global-website"; // Your Firebase project ID here
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/ebpn-global-website", // Your Firebase project ID here
            ValidateAudience = true,
            ValidAudience = "ebpn-global-website", // Your Firebase project ID here
            ValidateLifetime = true
        };
    });

// Add Authorization support
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<FirebaseAuthenticationMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
