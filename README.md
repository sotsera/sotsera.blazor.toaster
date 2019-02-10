# Sotsera.Blazor.Toaster

A Blazor port of [Toastr.js](https://github.com/CodeSeven/toastr/) in pure .Net. If there is any credit here it should go to the authors of the original library.

The sample project has been published [here](https://blazor-toaster.sotsera.com/).

The transitions are implemented using `System.Threading.Timer` so this library should be used only by client side blazor (webassembly).

## Changes

- version 0.8.0-preview-2 __breaking changes__
  - transitions handled with CSS animations
  - IToaster service registered as scoped service instead of singleton
  - options removed because only used by the old c# transitions
	- ShowStepDuration
	- HideStepDuration
	- ProgressBarStepDuration

- version 0.8.0-preview-1
  - upgraded to blazor 0.8.0 (0.8.0-preview-19104-04)
  - sample moved to https://blazor-toaster.sotsera.com/
  - csp headers for the sample project

- version 0.6.0
  - upgraded to blazor 0.6.0

- version 0.6.0-preview1
  - upgraded to blazor 0.6.0-preview1-final
  - css cursor forced to **pointer** on toast's outer div in order to allow them to be tappable on safari (ios)

- version 0.5.3
  - removed global.json files
  - the new **RequireInteraction** option disables the toast auto fade out

- version 0.5.2
  - upgraded to blazor 0.5.1

- version 0.5.1
  - upgraded to blazor 0.5.0 

- version 0.4.0
  - **MaxDisplayedToasts** is now an integer ranging from 0 to 100
  - The **VisibleStepDuration** option has been renamed to **ProgressBarStepDuration**

## Configuration

`Install-Package Sotsera.Blazor.Toaster`

Configure the dependency injection

```c#
services.AddToaster(config =>
{
    config.PositionClass = Defaults.Classes.Position.TopRight;
    config.PreventDuplicates = true;
    config.NewestOnTop = false;
});
```

and add the toast container to `App.cshtml` (or to another component always loaded in the application)

```c#
@addTagHelper *, Sotsera.Blazor.Toaster
<toastContainer />
```

## Usage

In a component

```c#
@inject Sotsera.Blazor.Toaster.IToaster toaster
```

In a class

```c#
[Inject] 
protected Sotsera.Blazor.Toaster.IToaster Toaster { get; set; }
```

then call one of the display methods:

```c#
toaster.Info("toast body text");
toaster.Success("toast body text");
toaster.Warning("toast body text");
toaster.Error("toast body text");
```

Each of these methods can accept a title and an action for the toast specific configuration

```c#
toaster.Info("toast body text");
toaster.Info("toast body text", "toast title");
toaster.Info("toast body text", "toast title", options =>
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
