var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var siteName = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME");
    var currentMachine = Environment.MachineName;
    var dotnetVer = Environment.Version;
    var isAzure = !string.IsNullOrEmpty(siteName);
    
    var htmlContent = "<!DOCTYPE html><html><head><meta charset='utf-8'><title>App Service Test</title>";
    htmlContent += "<style>";
    htmlContent += "* { margin: 0; padding: 0; box-sizing: border-box; }";
    htmlContent += "body { font-family: Arial, sans-serif; background-color: #0a0e27; color: #e0e0e0; padding: 2rem; }";
    htmlContent += ".main-card { max-width: 600px; margin: 0 auto; background: #1a1f3a; border: 2px solid #2a4f7f; border-radius: 12px; padding: 2rem; }";
    htmlContent += "h2 { color: #4a9eff; margin-bottom: 1.5rem; text-align: center; font-size: 1.8rem; }";
    htmlContent += ".data-row { margin: 1rem 0; padding: 0.75rem; background: #0f1528; border-left: 4px solid #4a9eff; }";
    htmlContent += ".data-label { font-weight: 600; color: #7aa3cc; font-size: 0.9rem; }";
    htmlContent += ".data-value { display: block; margin-top: 0.3rem; color: #ffc107; font-size: 1.1rem; }";
    htmlContent += ".footer-msg { text-align: center; margin-top: 2rem; padding-top: 1rem; border-top: 1px solid #2a4f7f; color: #52d452; }";
    htmlContent += "</style></head><body><div class='main-card'>";
    htmlContent += "<h2>Web Application Status</h2>";
    htmlContent += "<div class='data-row'><div class='data-label'>Service Name</div>";
    htmlContent += $"<div class='data-value'>{(siteName ?? "Running Locally")}</div></div>";
    htmlContent += "<div class='data-row'><div class='data-label'>Machine Identifier</div>";
    htmlContent += $"<div class='data-value'>{currentMachine}</div></div>";
    htmlContent += "<div class='data-row'><div class='data-label'>Framework Version</div>";
    htmlContent += $"<div class='data-value'>.NET {dotnetVer}</div></div>";
    htmlContent += "<div class='data-row'><div class='data-label'>Hosting Platform</div>";
    htmlContent += $"<div class='data-value'>{(isAzure ? "Azure App Service" : "Local Machine")}</div></div>";
    htmlContent += "<div class='footer-msg'>Application operational and responding</div>";
    htmlContent += "</div></body></html>";
    
    return Results.Content(htmlContent, "text/html");
});

app.Run();
