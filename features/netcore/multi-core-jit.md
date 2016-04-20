# Multicore JIT

Multi-core JIT improves the performance of apps by Just-In-Time (JIT) compiling
IL code on multiple cores. By default, the JIT compiles code on the same core
that code is executing on, and the app must wait for that execution to complete,
one method at a time. Multi-core JIT is intended to compile code faster than an
app can execute code, such that the JIT gets ahead of app execution, allowing
the app to execute without waiting for the JIT.

The JIT determines the most optimum order to compile methods in the app, based
on profile data collected from previous runs of the app. This information
enables the JIT to compile app code before it is needed, while not slowing down
the app. Once the JIT has completed compiling all of the methods recorded in the
profile data, multi-core JIT disables itself, returning to regular single-core
mode.

Multi-Core JIT typically has the most significant benefit to startup time. It's
typically the most critical user experience for performance. You can record any
aspect of your app experience in a profile. It might be the case that you record
startup and then another part of your app than can have perf hicups without
Multi-Core JIT.

You'll need to enable multi-core JIT to turn it on. If you're using Silverlight
5 or ASP.NET, multi-core JIT has already been turned on for you.
