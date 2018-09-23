# Fortran IntelliSense
This extension is a Language Server Protocol client that connects 
to [Chris Hansen's Fortran Language Server](https://github.com/hansec/fortran-language-server/) to add IntelliSense for Fortran to Visual Studio 2017.

I haven't been able to make configuration work yet, so you must build the extension yourself and change the path to fortls.exe in FortranLanguageClient.cs.

Also, this doesn't play nice with Intel Fortran IDE extension so far (see below).

## Requirements
Visual Studio 2017 version 15.8 or newer

## Installation
1. Install Fortran Language server
```
pip install fortran-language-server
```

2. Clone or fork this repo
3. Change `programPath` in FortranLanguageClient.cs to point to your fortls.exe.
4. Build
5. Install the VSIX

## Known issues
The extension unfortunately doesn't play nice with Intel's Fortran IDE.
In fact, having both of the extensions at the same time often makes Visual Studio crash.
I have issued a feature request to Intel to decouple language analysis from compiler+debugger functionality, they were positive about the idea, so hopefully they will do something about it soon.
However, don't hesitate to make the same request to them, so they know this is what people want.

