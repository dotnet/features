# NGEN

The Native Image Generator (ngen.exe) is a tool that improves the performance of
.NET applications. ngen.exe creates native images, which are files containing
compiled processor-specific machine code, and installs them into the native
image cache on the local computer. The runtime can use native images from the
cache instead of using the just-in-time (JIT) compiler to compile the original
assembly.

Native images can significantly improve memory use when code is shared between
processes. Native images are Windows PE files, so a single copy of a .dll file
can be shared by multiple processes. By contrast, native code produced by the
JIT compiler is stored in private memory and cannot be shared across multiple
processes.

Precompiling assemblies with ngen.exe can improve the startup time for some
applications. In general, gains can be made when applications share component
assemblies because after the first application has been started the shared
components are already loaded for subsequent applications. Cold startup, in
which all the assemblies in an application must be loaded from the hard disk,
does not benefit as much from native images because the hard disk access time
predominates. This characteristic is improved on Solid State Disks (SSDs), since
disk access time is typically much lower.

The following command generates a native image for clientApp.exe, located in the
current directory, and installs the image in the native image cache. In
addition, native images are generated for any .dll files that clientApp.exe
references. If a configuration file exists for the assembly, ngen.exe uses it.

	ngen install clientApp.exe