# Sotsera.Blazor.Toaster

## A Blazor port of [Toastr.js](https://github.com/CodeSeven/toastr/) to Server and Webassembly Blazor Apps.

The transitions are implemented using `System.Threading.Timer` timers so the resource usage should be closely monitored when using the server-side hosting model.

### Only for __server-side__ projects
The static assets from Razor Component Libraries are available by default [only in __Development__ mode](https://github.com/aspnet/AspNetCore/issues/13190#issuecomment-522066404). They can be enabled on __Production__  using the `UseStaticWebAssets()` method in the `Program.cs` file as in the following example:

```c#
public static IHostBuilder CreateHostBuilder(string[] args) =>
	Host.CreateDefaultBuilder(args)
		.ConfigureWebHostDefaults(webBuilder =>
		{
			webBuilder.UseStaticWebAssets();
			webBuilder.UseStartup<Startup>();
		});
```

## Sample
The client-side sample project has been published [here](https://blazor-toaster.sotsera.com/).

## Changes

__version 3.0.0
- new configuration options for styling the toast title (__ToastTitleClass__) and message (__ToastTitleClass__) and an example for aligning their text to left, center or right. Thanks to [@bholland314](https://github.com/bholland314)
- new configuration option (__EscapeHtml__) for allowing raw HTML in title and message. Thanks to [@bholland314](https://github.com/bholland314)
- __Breaking changes__
    - Options reference has been removed from the Toast class

__version 2.0.0
- update to asp.net core 3.1.100

__version 2.0.0-beta1
- thread safety controls on the Toasts list
- __Breaking changes__
    - IToaster.Toasts property removed in favor of the __ShownToasts__ property

See the [RELEASE-NOTES](https://github.com/sotsera/sotsera.blazor.toaster/blob/master/RELEASE-NOTES.md) for the previous versions.

## Configuration

### Installation

Add a reference to the library from [![NuGet Pre Release](https://img.shields.io/nuget/vpre/Sotsera.Blazor.Toaster.svg)](https://www.nuget.org/packages/Sotsera.Blazor.Toaster/)



### Dependency injection configuration

```c#
using Sotsera.Blazor.Toaster.Core.Models; // Needed for the configuration objects

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Add the library to the DI system
        services.AddToaster(config =>
        {
            //example customizations
            config.PositionClass = Defaults.Classes.Position.TopRight;
            config.PreventDuplicates = true;
            config.NewestOnTop = false;
        });
    }
}
```

### Css inclusion

Add the following reference to the toaster css in the ___Host.cshtml__ component for server side-apps or in the __index.html__ file for client side-apps:

```c#
<link href="_content/Sotsera.Blazor.Toaster/toastr.min.css" rel="stylesheet" />
```

### Main toaster component 

The toast container must be added to the `App.razor` component or to another component always loaded in the application like `MainLayout.razor`. It is important to have exactly one instance of this component rendered in the application tree at any given time.

```c#
@using Sotsera.Blazor.Toaster
<ToastContainer />
```

## Usage

In a component

```c#
@inject Sotsera.Blazor.Toaster.IToaster Toaster
```

In a class

```c#
[Inject] 
protected Sotsera.Blazor.Toaster.IToaster Toaster { get; set; }
```

then call one of the display methods:

```c#
Toaster.Info("toast body text");
Toaster.Success("toast body text");
Toaster.Warning("toast body text");
Toaster.Error("toast body text");
```

Each of these methods can accept a title and an action for the toast specific configuration

```c#
Toaster.Info("toast body text");
Toaster.Info("toast body text", "toast title");
Toaster.Info("toast body text", "toast title", options =>
{
    options.Clicked += toast => Console.WriteLine($"Toast '{toast.Message}' Clicked!");
});
```

## Credits

This is a simple attempt to port [Toastr.js](https://github.com/CodeSeven/toastr/) to Blazor.

Currently the [css styles](https://github.com/CodeSeven/toastr/blob/50092cc604850a16c985520b63df184d3e0b4086/build/toastr.min.css) used are literally COPIED from Toastr.js.

The [logo](https://www.flaticon.com/free-icon/breakfast_1381870) has been made by [Freepik](https://www.freepik.com/) from [Flaticon](https://www.flaticon.com/) and is licensed by [CC 3.0 BY](http://creativecommons.org/licenses/by/3.0/)


## License

Sotsera.Blazor.Toaster is licensed under [MIT license](http://www.opensource.org/licenses/mit-license.php)
