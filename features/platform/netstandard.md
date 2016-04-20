# .NET Platform Standard

The .NET Platform Standard is an API surface for class libraries which is
guaranteed to be implemented by various implementations of .NET - .NET Core,
.NET Framework, and Mono/Xamarin.  If you write code that targets to .NET
Platform Standard (or `netstandard`), then your code is guaranteed to run on
certain platforms.

Targeting the .NET Platform Standard is a concious tradeoff between two things:
total number of APIs available, and maximum number of places the code can run.
If you want access to the most APIs, your code will run in the least number of
places.  If you want your code to run everywhere, you won't get access to the
most APIs.  The .NET Standard doesn't hide this fact from you, and allows you to
make that tradeoff in a clean manner.

In general, class libraries which target a lower .NET Platform Standard version,
like 1.0, can be loaded by the largest number of existing platforms, but will
have access to a smaller set of APIs. On the other hand, class libraries which
target a higher .NET Platform Standard version, like 1.3, can be loaded by a
smaller number of newer platforms, but will have access to a larger, more recent
set of APIs.

It is currently available as five different versions.  Here's a table which maps
.NET Standard versions to platforms:

| Target Platform Name | Alias |  |  |  |  |  | |
| :---------- | :--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |
|.NET Platform Standard | netstandard | 1.0 | 1.1 | 1.2 | 1.3 | 1.4 | 1.5 |
|.NET Core|netcoreapp|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|1.0|
|.NET Framework|net|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|4.6.2|
|||&rarr;|&rarr;|&rarr;|&rarr;|4.6.1||
|||&rarr;|&rarr;|&rarr;|4.6|||
|||&rarr;|&rarr;|4.5.2||||
|||&rarr;|&rarr;|4.5.1||||
|||&rarr;|4.5|||||
|Universal Windows Platform|uap|&rarr;|&rarr;|&rarr;|&rarr;|10.0||
|Windows|win|&rarr;|&rarr;|8.1||||
|||&rarr;|8.0|||||
|Windows Phone|wpa|&rarr;|&rarr;|8.1||||
|Windows Phone Silverlight|wp|8.1||||||
|||8.0||||||
|Mono/Xamarin Platforms||&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|*|
|Mono||&rarr;|&rarr;|*|||||
