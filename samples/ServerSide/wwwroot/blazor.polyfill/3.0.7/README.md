# Blazor.Polyfill

Polyfills for Blazor and fixes for Internet Explorer 11 support with server-side mode.

### NOTICE

Since **Blazor 3.1.0-preview3.19555.2**, including the polyfill on a **Blazor WebAssembly** project can cause some break, especially on **Edge**.
As the current library is only aimed for the **Blazor server-side** project and only for **Internet Explorer 11**, you must include this polyfill only on this browser.

See the updated documentation.

# ABOUT

This are the required polyfills and fixes in order to launch Blazor from Internet Explorer 11.

This project is using the following polyfills internally:

- [*core-js*](https://github.com/zloirock/core-js)
- [*fetch*](https://github.com/github/fetch)
- [webcomponents/template](https://github.com/webcomponents/template)
- [miguelmota/Navigator.sendBeacon](https://github.com/miguelmota/Navigator.sendBeacon)

# INSTALLATION

The easiest way to install is to download the [*latest release*](https://github.com/Daddoon/Blazor.Polyfill/releases) and include the **blazor.polyfill.js** or **blazor.polyfill.min.js** file before the **blazor.server.js** (server-mode) script tag in your **wwwroot\index.html** or **_Host.cshtml** file like:

```html
<script type="text/javascript">
    if (/MSIE \d|Trident.*rv:/.test(navigator.userAgent)) {
        document.write('<script src="js/blazor.polyfill.min.js"><\/script>');
    }
</script>
<script type="text/javascript" src="blazor.polyfill.min.js"></script>
<script src="_framework/blazor.server.js"></script>
```

...considering you have copied the file in a **wwwroot/js** folder.
