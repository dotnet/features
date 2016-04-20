# Portable Class Libraries

Portable Class Libraries (PCL) is an alternate .NET profile that is compatible
with all other .NET profiles. By default, if you create a library for .NET
Framework, for example, it will not run on Windows Phone. By creating a PCL
library, you enable your library to run on multiple .NET platforms, such as any
of the .NET Framework, Windows Phone and Xamarin.iOS.

The PCL profile is really a set of profiles. Each profile models or describes
the API intersection between a particular set of platforms, like for example
.NET Framework 4.5, Windows Store 8.1 and Xamarin.Android. You get access to the
set of APIs that are shared between the platform you select. Although somewhat
unintuitive, the more platforms you pick to be compatible with, the fewer APIs
you get access to. That's how intersections work.

There are several scenarios that have been a key focus to work well in PCL
libraries:

* C# and VB language features
* Networking
* MVVM view models (ex: INotifyPropertyChanged)

PCL is a an area of frequent investment by the .NET team. You should expect to
see more scenarios being enabled over time, such as File I/O.
