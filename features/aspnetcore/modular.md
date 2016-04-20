# Modular from the bottom up

ASP.NET Core is a modular web framework.  At its core, it is essentially a
console application that reads and writes data from and to ports.  That's it!
Middleware and dependency injection are the two models used for layering
everything great about ASP.NET MVC, logging, security, and other features atop
this lean core.  Each of these pieces are delivered via NuGet packages that you
can include as needed.  Additionally, ASP.NET Core is based on .NET Core.

.NET Core is a modular set of runtime, library, and compiler components  You can
.compose them in various configurations to match your workloads  With NuGet as a
.vehicle for delivering  libraries, you can pull in a lean NET Standard Library
.to have a low footprint for your code

But let's take that a step further.  With ASP.NET Core, .NET Core, and the .NET
Standard Library, we've introduced a set of organized packages guaranteed to be
compatible with any consumers of the .NET Standard Library.  But what if you
wanted to be even more compatible?  With the ability to "trim" your .NET
Standard Library dependencies such that you depend *only* the packages your code
actually uses, you can write code that has an even greater reach than ever
before.

This increased flexibility, in tandem with the extent of .NET Core's cross-
platform reach and Xamarin, can allow your code to be used almost anywhere in
almost any scenario.
