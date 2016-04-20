# Task Parallel Library

The Task Parallel Library (TPL), as its name implies, is based on the concept of
the task. The term task parallelism refers to one or more independent tasks
running concurrently. A task represents an asynchronous operation, and in some
ways it resembles the creation of a new thread or ThreadPool work item, but at a
higher level of abstraction. Tasks provide two primary benefits:

* **More efficient and more scalable use of system resources** Behind the
  scenes, tasks are queued to the ThreadPool, which has been enhanced with
  algorithms (like hill-climbing) that determine and adjust to the number of
  threads that maximizes throughput. This makes tasks relatively lightweight,
  and you can create many of them to enable fine-grained parallelism. To
  complement this, widely-known work-stealing algorithms are employed to provide
  load-balancing.
* **More programmatic control than is possible with a thread or work item**
  Tasks and the framework built around them provide a rich set of APIs that
  support waiting, cancellation, continuations, robust exception handling,
  detailed status, custom scheduling, and more.

Tasks are the preferred API for writing multi-threaded, asynchronous, and
parallel code using the .NET Framework.
