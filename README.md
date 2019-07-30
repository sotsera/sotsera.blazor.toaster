# Sotsera.Blazor.Toaster

A Blazor port of [Toastr.js](https://github.com/CodeSeven/toastr/) in pure .Net. 

The transitions are implemented using `System.Threading.Timer` timers so the resource usage should be closely monitored when using the server-side hosting model.

## Css inclusion for Blazor Server Apps
While on client-side projects the css file is still loaded automatically, on server side projects the following reference must be added to the ___Host.cshtml__ file:

```html
<link href="_content/Sotsera.Blazor.Toaster/toastr.min.css" rel="stylesheet" />
```

The client-side sample project has been published [here](https://blazor-toaster.sotsera.com/).

## Changes

__version 0.11.0__
- moved to 3.0.0-preview7.19365.7
- __Breaking changes__
    - repackaged as __Razor Component Library__: on server-side projects the css must be referenced explicitly by the host component
	- option __NewestOnTop__ defaults to false

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

### Css inclusion

Only for Blazor Server Apps, add the following reference to the toaster css in the ___Host.cshtml__ component

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
