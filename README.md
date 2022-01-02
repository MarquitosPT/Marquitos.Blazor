[![NuGet Badge](https://buildstats.info/nuget/Marquitos.AspNetCore.Components)](https://www.nuget.org/packages/Marquitos.AspNetCore.Components/)

# Marquitos.Blazor
Blazor Components library is composed by the following components.

## Components
- Accordion
- Breadcrumb
- Button
- Card
- Dialog
- [NavigationView](https://github.com/MarquitosPT/Marquitos.Blazor/wiki/NavigationView)
- SvgIcon
- TabSet

## Usage
On configure method simply add the `AddMarquitosComponents()` to your pipeline and you ready to go:
```csharp
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddMarquitosComponents(o => {
                o.GlobalTheme = AspNetCore.Components.Enums.Theme.Bootstrap;
            });

            await builder.Build().RunAsync();
        }
```
On `_Imports.razor` add the following using clauses:
```html
...
@using Marquitos.AspNetCore.Components.Enums
@using Marquitos.AspNetCore.Components.Web
```

Then you are ready to go:
```html
<NavigationView IsBackButtonVisible="true">
    <MenuItems>
        <NavMenu/>
    </MenuItems>

    <Frame>
        <div class="content px-4">
            @Body
        </div>
    </Frame>
</NavigationView>
```
