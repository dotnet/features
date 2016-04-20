#SIMD (Single instruction, multiple data)#

Processor speed no longer follows Mooreout \1s law. So in order to optimize the
performance of your applications, it's increasingly important to embrace
parallelization. Or, as Herb Sutter phrased it, the free lunch is over.

You may think that task-based programming or offloading work to threads is
already the answer. While multi-threading is certainly a critical part, it's
important to realize that it's still important to optimize the code that runs on
each core. SIMD is a technology that employs data parallelization at the CPU
level. Multi-threading and SIMD complement each other: multi-threading allows
parallelizing work over multiple cores while SIMD allows parallelizing work
within a single core.

We've released a new JIT and a [NuGet package](http://www.nuget.org/packages/Microsoft.Bcl.Simd "Microsoft.Bcl.Simd")
that provide SIMD functionality. Here is an example on how you would use it:

```C#
    // Initalize some vectors

    Vector<float> values = GetValues();
    Vector<float> increment = GetIncrement();

    // The next line will leverage SIMD to perform the
    // addition of multiple elements in parallel:

    Vector<float> result = values + increment;
```
