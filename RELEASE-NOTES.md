# Sotsera.Blazor.Toaster
## Changes

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