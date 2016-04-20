# Side by side installation

.NET Core allows for side-by-side installation of different versions of the
runtime.  Rather than being tied to the OS like .NET Framework, .NET Core
runtimes can be serviced individually such that only the apps which use that
particular runtime are affected.

Imagine the following scenario:

You've got an application running on a version of .NET that you do not want to
break.  At the same time, you want to run a different application on a different
version of .NET that does some things that could be potentially incompatible
with your other application.  In the past, there was no reasonable way to
rectify this situation unless you were willing to deploy the new application to
a different machine altogether.  Virtualization aided this pain, but was not the
optimal solution.

Now, this scenario is completely feasible.  .NET Core is entirely side-by-side,
with each installation completely isolated from other installations.  You can
now be even more flexible in how you deploy systems to machines, and be
reassured that introducing another version of .NET Core won't break your other
applications.  Flexibility is the name of the game here.
