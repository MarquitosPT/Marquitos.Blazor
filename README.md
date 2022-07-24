[![NuGet Badge](https://buildstats.info/nuget/Marquitos.AspNetCore.Components)](https://www.nuget.org/packages/Marquitos.AspNetCore.Components/)

# Marquitos.Blazor
Marquitos Blazor Components is an open source library designed for WebAssembly. The main goal of this library is to create simple and usefull components. Some of them are based just on Bootstrap 5 CSS but enriched with animation motions to make a nice fluid user experience.

Marquitos Blazor Components library is composed by the following components.

## Components
- Accordion
- Breadcrumb
- Button
- Card
- Chart
- Dialog
- Grid
- [NavigationView](https://github.com/MarquitosPT/Marquitos.Blazor/wiki/NavigationView)
- SvgIcon
- TabSet

## Usage
Add the latest `Marquitos.AspNetCore.Components` nuget package to your project references:
```html
<ItemGroup>
    ...
    <PackageReference Include="Marquitos.AspNetCore.Components" Version="1.0.x" />
</ItemGroup>
```

On configure method add the `AddMarquitosComponents()` to your pipeline:
```csharp
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            ...
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
