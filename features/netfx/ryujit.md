# RyuJIT Next Generation JIT #

RyuJIT is the code name for the modern unified CLR JIT compiler that helps drive
innovation faster, improve throughput, and improve code quality while providing
consistent, predictable performance across architectures.  While consistency
across architectures is driven by using a single code base, substantial
investments in modernizing the compiler enables powerful optimizations  (e.g.,
SSA based Value Numbering) while dramatically improving the throughput.  RyuJIT
is also the enabler for the new BCL SIMD types – providing access to SIMD
hardware with .NET managed types.  RyuJIT has been made available to customers
through 4 CTP releases, with some great feedback, and we are continuing to
incorporate customer feedback.  Get the latest [RyuJIT
update](http://aka.ms/RyuJIT), and read more on the [.NET Framework
blog](http://blogs.msdn.com/b/dotnet/). RyuJIT is helping us bring up support
for a new architecture with greater agility, and promises the same agility for
future innovation.

Code generation terms explained:

* **Throughput**: How fast does the compiler generate code.
* **Code** quality: How fast does the generated code execute.
* **Consistency**: How does the generated code differ across architectures.
* **Predictability**: How do throughput/code quality vary with different inputs
  to the compiler.
