# Sotsera.Blazor.Toaster

A Blazor port of [Toastr.js](https://github.com/CodeSeven/toastr/) in pure .Net. 

The transitions are implemented using `System.Threading.Timer` so this library __should be used only by client side blazor (webassembly)__.

__Razor components__ currently [cannot reference static assets from component libraries](https://blogs.msdn.microsoft.com/webdev/2019/01/29/aspnet-core-3-preview-2/#sharing-component-libraries).
As a temporary workaround the [css](https://raw.githubusercontent.com/sotsera/sotsera.blazor.toaster/master/src/Sotsera.Blazor.Toaster/Content/toastr.min.css)
can be saved into the server project wwwroot and loaded by the index.html with something like `<link href="toastr.min.css" rel="stylesheet"/>`.

The sample project has been published [here](https://blazor-toaster.sotsera.com/).

## Changes

__version 0.10.1__
- fix for bootstrap version >= 4.2
- sample updated to boostrap v4.3.1 and fix for position initial value thanks to [@peterblazejewicz]( https://github.com/sotsera/sotsera.blazor.toaster/pull/22 )

__version 0.10.0__
- update to 3.0.0-preview6.19307.2
- simplified transition management thanks to the @key binding in the toast container

See the [RELEASE-NOTES](https://github.com/sotsera/sotsera.blazor.toaster/blob/master/RELEASE-NOTES.md) for the previous versions.

## Configuration

### Installation

`Install-Package Sotsera.Blazor.Toaster`

### Dependency injection configuration

```c#
services.AddToaster(config =>
{
    //example customizations
    config.PositionClass = Defaults.Classes.Position.TopRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = false;
});
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
