# Sotsera.Blazor.Toaster
## Previous changes

__version 1.0.0
- updated to Asp.Net Core 3.0.0

__version 1.0.0-preview9.1__
- moved to 3.0.0-preview9.19424.4

__version 1.0.0-preview.8.1__
- moved to 3.0.0-preview8.19405.7 and to SemVer 2.0.0
- __Breaking changes__
    - the reference to the css file must be explicitly added also in client-side apps

__version 0.11.0__
- moved to 3.0.0-preview7.19365.7
- __Breaking changes__
    - repackaged as __Razor Component Library__: on server-side projects the css must be referenced explicitly by the host component
	- option __NewestOnTop__ defaults to false

__version 0.10.1__
- fix for bootstrap version >= 4.2
- sample updated to boostrap v4.3.1 and fix for position initial value thanks to [@peterblazejewicz]( https://github.com/sotsera/sotsera.blazor.toaster/pull/22 )

__version 0.10.0__
- update to 3.0.0-preview6.19307.2
- simplified transition management thanks to the @key binding in the toast container

__version 0.9.0-preview-3__
- fixes issue #19 - exclude razor files from the nuget package

__version 0.9.0-preview-2__
- update to 3.0.0-preview4-19216-03
- __updated instructions__ on how to [include the ToastContainer component](#main-toaster-component)

- version 0.9.0-preview-1
  - update to blazor 0.9.0-preview3-19154-02

- version 0.8.0-preview-4
  - fix for razor components

- version 0.8.0-preview-3
  - fix for razor components
  - OnClick method made async __(breaking change)__

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