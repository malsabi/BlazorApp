# BlazorApp
Multi Platform Application (Web, Desktop, Mobile) that uses one UI Component shared across all platforms, all of the logical code is stored in a core library

Target Framework: .NET 6.0

Project Structure

1. BlazorApp.Components: Contains all of the UI blazor components in razor syntax.
2. BlazorApp.NativeClient: .NET MAUI Blazor project for targetting Desktop/Mobile that are based on blazor components.
3. BlazorApp.Server: ASP WEB API project for creating an endpoints to test if both NativeClient and WebClient will be equal in performance.
4. BlazorApp.WebClient: Blazor Server project for creating a web application that are based on blazor components.
5. BlazorApp.Shared: Contains all of the models/services/database that will be shared with NativeClient and WebClient.
