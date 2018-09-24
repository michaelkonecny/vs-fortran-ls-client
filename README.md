# Fortran IntelliSense
This extension is a Language Server Protocol client that connects 
to [Chris Hansen's Fortran Language Server](https://github.com/hansec/fortran-language-server/) to add IntelliSense for Fortran to Visual Studio 2017.

## Requirements
Visual Studio 2017 version 15.8 or newer

## Installation
1. Install Fortran Language Server
```
pip install fortran-language-server
```

2. Download the VSIX extension file [here](https://github.com/michaelkonecny/vs-fortran-ls-client/releases/latest)
3. Install the VSIX
4. Open VS2017. Before opening any fortran files, go to Tools -> Options -> Fortran Language Client and set the path to `fortls.exe`. This is usually `[path to your python installation]/Scripts/fortls.exe`.
5. The extension should work now.


## Known issues
The extension unfortunately doesn't play nice with Intel's Fortran IDE.
In fact, having both of the extensions at the same time often causes Visual Studio to crash.
I have issued a feature request to Intel to decouple language analysis from compiler+debugger functionality, they were positive about the idea, so hopefully they will do something about it soon.
However, don't hesitate to repeat the request to them, so they have an idea about the demand.

