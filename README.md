# Avalonia Custom TitleBar Template
This is based on the Aavalonia MVVM Template, but allows for easy customization of the TitleBar, as well as Content on the whole window (e.g. also inside the non-client area).
It allows for building TitleBars such as the ones used in Visual Studio Code or in Visual Studio.

## Supported Platforms
* Windows (Fluent Light / Dark)
* MacOS (Coming soon)
* Linux (Coming soon / Will use Ubuntu styled title bar by default)

## Intended use
It is likely, that the default implementation does not fit your needs, therefore the main purpose of this project is to give an easy to follow example of how things can be implemented, so that you can implement your own custom title bar.

## Use cases
You may find this helpful, if
* you want content (for example a menu) in the title bar
* you want to change the background color of the title bar (for DarkMode, etc.)

Avalonia provides its own managed title bar, but I found it hard to customize and did not like the default implementation a lot. However it is easier to set up, so be sure to check it out first by using these attributes for your window:
```
ExtendClientAreaToDecorationsHint="True"
ExtendClientAreaChromeHints="PreferSystemChrome"
ExtendClientAreaTitleBarHeightHint="-1"
```

## Screenshots
#### Windows
![Windows Screenshot](https://raw.githubusercontent.com/FrankenApps/Avalonia-CustomTitleBarTemplate/master/Screenshots/screenshot.gif "Windows Screenshot")
