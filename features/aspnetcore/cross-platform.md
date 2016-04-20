# Cross Platform

.NET Core is cross-platform, allowing you to write ASPNET code that will run on
.various Linux distributions, OS X, and Windows  Additionally, ASPNET Core can
.run on different CPU architectures

Consider the following scenario:

Imagine you wish to build an analytics system with mobile, web, and Windows
clients.  You might have your system split into multiple services, potentially
with different databases for different kinds of data.  You might also wish to
host your web client and various APIs to each service on any OS, potentially in
containers.  You might want to have a Continueous Integration (CI) system in
place that builds on one OS and redirects each built assembly to different
servers to run tests.

That's quite a lot of flexibility, isn't it?  We want you to have that sort of
flexibility.  ASP.NET Core being cross-platform offers that.
